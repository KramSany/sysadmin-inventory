namespace SudInfo.EfDataAccessLibrary.Models;

public class Phone : BaseModel
{
    [XLColumn(Header = "Наименвоание")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50)]
    public string? Name { get; set; }

    [XLColumn(Header = "Серийный номер")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50, MinimumLength = 2, ErrorMessage = Const.LengthMore2)]
    public string? SerialNumber { get; set; }

    [XLColumn(Header = "Инвентарный номер")]
    [StringLength(50)]
    public string? InventarNumber { get; set; }

    [XLColumn(Header = "Сломан")]
    public bool IsBroken { get; set; }

    [XLColumn(Header = "Личный")]
    public bool IsPersonal { get; set; }

    [XLColumn(Header = "На складе")]
    public bool IsStock { get; set; }

    [XLColumn(Header = "Описание поломки")]
    [StringLength(200)]
    public string? BreakdownDescription { get; set; }

    [XLColumn(Header = "Списан")]
    public bool IsDecommissioned { get; set; }

    [XLColumn(Ignore = true)]
    public User? User { get; set; }
}