using System.Reflection;
using ClosedXML.Attributes;

namespace SudInfo.Avalonia.Services;

public static class ExcelService
{
    public static async Task CreateExcelTableFromEntity<T>(IReadOnlyCollection<T> entity)
    {
        if (App.MainWindow == null)
            return;
        using XLWorkbook wb = new();
        

        var ws = wb.Worksheets.Add(nameof(entity));
        ws.Cell(1, 1).InsertTable(entity);
        ws.Columns().AdjustToContents();

        var storageProvider = App.MainWindow.StorageProvider;
        if (storageProvider == null)
            return;

        var saveFilePickerOptions = new FilePickerSaveOptions
        {
            Title = "Выберите путь сохранения",
            SuggestedFileName = "Table.xlsx",
            FileTypeChoices =
            [
                new FilePickerFileType("Excel")
                {
                    Patterns = ["*.xlsx"]
                }
            ]
        };

        var fileResult = await storageProvider.SaveFilePickerAsync(saveFilePickerOptions);
        if (fileResult != null)
        {
            await using var stream = await fileResult.OpenWriteAsync();
            wb.SaveAs(stream);
        }
    }

    public static async Task<List<T>?> ReadExcelTableFromFile<T>() where T : new()
    {
        if (App.MainWindow == null) return null;

        var storageProvider = App.MainWindow.StorageProvider;
        if (storageProvider == null) return null;

        var filePickerOptions = new FilePickerOpenOptions
        {
            Title = "Выберите файл Excel для импорта",
            AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("Excel") { Patterns = ["*.xlsx"] }]
        };

        var fileResult = await storageProvider.OpenFilePickerAsync(filePickerOptions);
        if (fileResult == null || fileResult.Count == 0) return null;

        await using var stream = await fileResult.First().OpenReadAsync();
        using var wb = new XLWorkbook(stream);

        var ws = wb.Worksheets.First();
        var range = ws.RangeUsed();

        if (range == null) return null;

        var list = new List<T>();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var headerRow = range.FirstRow();
        var headerMap = new Dictionary<string, int>();

        for (var col = 1; col <= headerRow.CellCount(); col++)
        {
            var headerValue = headerRow.Cell(col).GetString().Trim();
            if (!string.IsNullOrEmpty(headerValue)) headerMap[headerValue] = col;
        }

        var dataRows = range.RowsUsed().Skip(1);

        foreach (var row in dataRows)
        {
            var item = new T();
            var hasData = false;

            foreach (var prop in properties)
            {
                var xlAttr = prop.GetCustomAttribute<XLColumnAttribute>();

                var headerName = xlAttr?.Header ?? prop.Name;

                if (xlAttr != null && xlAttr.Ignore) continue;

                if (headerMap.TryGetValue(headerName, out var colIndex))
                {
                    var cell = row.Cell(colIndex);
                    if (cell.IsEmpty()) continue;

                    hasData = true;
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    try
                    {
                        object? value = null;

                        if (targetType.IsEnum)
                        {
                            var stringValue = cell.GetString();
                            if (Enum.TryParse(targetType, stringValue, true, out var enumResult))
                                value = enumResult;
                            else if (int.TryParse(stringValue, out var intEnum))
                                value = Enum.ToObject(targetType, intEnum);
                        }
                        else if (targetType == typeof(bool))
                        {
                            value = cell.GetBoolean();
                        }
                        else if (targetType == typeof(int))
                        {
                            value = (int)cell.GetDouble();
                        }
                        else if (targetType == typeof(double))
                        {
                            value = cell.GetDouble();
                        }
                        else if (targetType == typeof(string))
                        {
                            value = cell.GetString();
                        }
                        else
                        {
                            value = Convert.ChangeType(cell.Value.ToString(), targetType);
                        }

                        prop.SetValue(item, value);
                    }
                    catch
                    {
                    }
                }
            }

            if (hasData) list.Add(item);
        }

        return list;
    }
}