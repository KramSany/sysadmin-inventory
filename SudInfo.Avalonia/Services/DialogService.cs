namespace SudInfo.Avalonia.Services;

public static class DialogService
{
    public static async Task ShowErrorMessageBox(string message)
    {
        await MessageBoxManager.GetMessageBoxStandard("Ошибка",
                message,
                icon: Icon.Error)
            .ShowAsync();
    }

    public static async Task<ButtonResult> ShowQuestionMessageBox(string message)
    {
        return await MessageBoxManager.GetMessageBoxStandard("Сообщение",
                message,
                ButtonEnum.YesNo,
                Icon.Question)
            .ShowAsync();
    }
}