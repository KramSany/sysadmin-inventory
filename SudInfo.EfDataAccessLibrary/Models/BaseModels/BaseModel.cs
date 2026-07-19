namespace SudInfo.EfDataAccessLibrary.Models.BaseModels;

public abstract class BaseModel
{
    [XLColumn(Ignore = true)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}