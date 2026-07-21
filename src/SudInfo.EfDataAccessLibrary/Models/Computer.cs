namespace SudInfo.EfDataAccessLibrary.Models;

public class Computer : BaseModel
{
    [XLColumn(Header = "IP адрес")]
    [StringLength(15)]
    [RegularExpression(Const.Ip4RegularExpression, ErrorMessage = Const.NotValidIp4Message)]
    public string? Ip { get; set; }

    [XLColumn(Header = "Наименование")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? Name { get; set; }

    [XLColumn(Header = "Операционная система")]
    public OS OS { get; set; } = OS.Windows7;

    [XLColumn(Header = "Процессор")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? CPU { get; set; }

    [XLColumn(Header = "Видеокарта")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? GPU { get; set; }

    [XLColumn(Header = "Диск")]
    public int ROM { get; set; } = 120;

    [XLColumn(Header = "Оперативная память")]
    public int RAM { get; set; } = 1;

    [XLColumn(Ignore = true)]
    public int NumberCabinet { get; set; } = 1;

    [XLColumn(Header = "Серийный номер")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? SerialNumber { get; set; }

    [XLColumn(Header = "Инвентарный номер")]
    [StringLength(50)]
    public string? InventarNumber { get; set; }

    [XLColumn(Header = "Год производства")]
    public int YearRelease { get; set; } = 2019;

    [XLColumn(Header = "Тип диска")]
    public TypeROM TypeROM { get; set; } = TypeROM.HDD;

    [XLColumn(Header = "Сломан")]
    public bool IsBroken { get; set; }

    [XLColumn(Header = "На складе")]
    public bool IsStock { get; set; }

    [XLColumn(Header = "Описание поломки")]
    [StringLength(200)]
    public string? BreakdownDescription { get; set; }

    [XLColumn(Header = "ВКС")]
    public bool IsVks { get; set; }

    [XLColumn(Header = "Списан")]
    public bool IsDecommissioned { get; set; }

    [XLColumn(Ignore = true)]
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    [XLColumn(Header = "ID Пользователя")]
    public int? UserId { get; set; }

    [XLColumn(Header = "Личное")]
    public bool IsPersonal { get; set; }

    #region Not mapped properties

    [XLColumn(Header = "Номер кабинета")]
    [NotMapped]
    public int Cabinet { get => User?.NumberCabinet ?? NumberCabinet; set => NumberCabinet = value; }

    [XLColumn(Ignore = true)]
    [NotMapped]
    public string ComputerNameWithUserSurFirstName => Name + " - " + User?.LastName + " " + User?.FirstName;

    [XLColumn(Ignore = true)]
    [NotMapped]
    public bool IsSelected { get; set; }

    #endregion

    #region Collections

    [XLColumn(Ignore = true)]
    public ICollection<Periphery>? Peripheries { get; set; }

    [XLColumn(Ignore = true)]
    public ICollection<Monitor>? Monitors { get; set; }

    [XLColumn(Ignore = true)]
    public ICollection<Printer>? Printers { get; set; }

    [XLColumn(Ignore = true)]
    public ICollection<AppEntity>? Apps { get; set; }

    #endregion
}

public enum OS
{
    Windows7, Windows10, Linux, WindowsXP
}

public enum TypeROM
{
    HDD, SSD
}