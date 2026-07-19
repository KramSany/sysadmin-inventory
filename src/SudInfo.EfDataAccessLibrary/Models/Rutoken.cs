namespace SudInfo.EfDataAccessLibrary.Models;

public class Rutoken : BaseModel
{
    [XLColumn(Header = "Серийный номер рутокен")]
    [StringLength(30)]
    public string? SerialNumberRutoken { get; set; }

    [XLColumn(Header = "Номер сертификата")]
    [StringLength(100)]
    public string? NumberCertificate { get; set; }

    [XLColumn(Header = "Дата окончания действия сертификата")]
    public DateTime? EndDateCertificate { get; set; } = DateTime.Now.AddYears(1);

    public User? User { get; set; }
}