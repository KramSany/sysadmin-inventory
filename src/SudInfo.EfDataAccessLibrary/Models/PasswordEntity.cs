namespace SudInfo.EfDataAccessLibrary.Models;

public class PasswordEntity : BaseModel
{
    [XLColumn(Header = "Описание")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(200, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Description { get; set; }

    [XLColumn(Header = "Ссылка на сайт")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Link { get; set; }

    [XLColumn(Header = "Логин")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Login { get; set; }

    [XLColumn(Header = "Пароль")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Password { get; set; }
}