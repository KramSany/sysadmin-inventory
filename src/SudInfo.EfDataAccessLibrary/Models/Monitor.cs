namespace SudInfo.EfDataAccessLibrary.Models;

public class Monitor : BaseModel
{
    [XLColumn(Header = "Наименование")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Name { get; set; }

    [XLColumn(Header = "Размер экрана")]
    public int ScreenSize { get; set; } = 24;

    [XLColumn(Ignore = true)]
    public int ScreenResolutionWidth { get; set; } = 1920;

    [XLColumn(Ignore = true)]
    public int ScreenResolutionHeight { get; set; } = 1080;

    [XLColumn(Header = "Разрешение экрана")]
    [NotMapped]
    public string ScreenResolution => $"{ScreenResolutionWidth}x{ScreenResolutionHeight}";

    [XLColumn(Header = "Серийный номер")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? SerialNumber { get; set; }

    [XLColumn(Header = "Инвентарный номер")]
    [StringLength(50)]
    public string? InventarNumber { get; set; }

    [XLColumn(Header = "Сломан")]
    public bool IsBroken { get; set; }

    [XLColumn(Header = "Описание поломки")]
    [StringLength(200)]
    public string? BreakdownDescription { get; set; }

    [XLColumn(Header = "На складе")]
    public bool IsStock { get; set; }

    [XLColumn(Header = "Списан")]
    public bool IsDecommissioned { get; set; }

    [XLColumn(Header = "Год производства")]
    public int YearRelease { get; set; } = 2019;

    public Computer? Computer { get; set; }
}