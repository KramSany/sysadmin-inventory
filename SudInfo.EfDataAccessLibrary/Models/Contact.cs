namespace SudInfo.EfDataAccessLibrary.Models;

public class Contact : BaseModel
{
    [XLColumn(Header = "Имя/Наименование контакта")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(100, ErrorMessage = Const.LengthMore2, MinimumLength = 2)]
    public string? Name { get; set; }

    [XLColumn(Header = "Номер телефона")]
    [RegularExpression("[7-8][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = Const.NotValidPhoneMessage)]
    [StringLength(11)]
    public string? Phone { get; set; }

    [XLColumn(Header = "Электронная почта")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Email { get; set; }

    [XLColumn(Header = "Описание")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(500, ErrorMessage = Const.LengthMore2, MinimumLength = 2)]
    public string? Description { get; set; }
}