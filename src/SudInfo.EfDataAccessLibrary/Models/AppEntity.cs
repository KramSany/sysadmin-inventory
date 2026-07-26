namespace SudInfo.EfDataAccessLibrary.Models;

public class AppEntity : BaseModel
{
    [XLColumn(Header = "Название")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(50, ErrorMessage = Const.LengthMore2, MinimumLength = 2)]
    public string? Name { get; set; }

    [XLColumn(Header = "Версия")]
    [Required(ErrorMessage = Const.FieldRequired)]
    [StringLength(20, ErrorMessage = Const.LengthMore2, MinimumLength = 2)]
    public string? Version { get; set; }

    [XLColumn(Ignore =  true)]
    public ICollection<Computer>? Computers { get; set; } = [];

    [NotMapped]
    [XLColumn(Header = "ID Компьютеров")]
    public string? ComputerId
    {
        get
        {
            if (Computers == null || !Computers.Any()) return string.Empty;
            return string.Join(",", Computers.Select(x => x.Id));
        }
        set
        {
            Computers = new List<Computer>();
            if (string.IsNullOrWhiteSpace(value)) return;

            var ids = value.Split(',')
                .Select(x => x.Trim())
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse);

            foreach (var id in ids)
            {
                Computers.Add(new Computer { Id = id });
            }
        }
    }
}