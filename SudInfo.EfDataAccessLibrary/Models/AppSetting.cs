namespace SudInfo.EfDataAccessLibrary.Models;

public class AppSetting : BaseModel
{
    [StringLength(10)]
    public string Theme { get; set; } = "Light";
}