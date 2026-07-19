namespace SudInfo.EfDataAccessLibrary.Models;

public class User : BaseModel
{
    [XLColumn(Header = "Имя")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(20, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? FirstName { get; set; }

    [XLColumn(Header = "Фамилия")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(20, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? LastName { get; set; }

    [XLColumn(Header = "Отчество")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(20, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? MiddleName { get; set; }

    [XLColumn(Ignore = true)]
    [NotMapped]
    public string FIO => LastName + Const.EmptyWithSpaceString + FirstName + Const.EmptyWithSpaceString + MiddleName;

    [XLColumn(Header = "Номер кабинета")]
    public int NumberCabinet { get; set; }

    [XLColumn(Header = "Личный телефон")]
    [StringLength(11)]
    public string? PersonalPhone { get; set; }

    [XLColumn(Header = "Рабочий телефон")]
    [StringLength(11)]
    public string? WorkPhone { get; set; }

    [XLColumn(Header = "Внутренний телефон")]
    [StringLength(3)]
    public string? LocalPhone { get; set; }

    public ICollection<Computer> Computers { get; set; } = [];
}