namespace SudInfo.Avalonia.Services;

public class PrinterService(
    SudInfoDatabaseContext context) : BaseService<Printer>(context)
{
    public override async Task<Result> Add(Printer printer)
    {
        try
        {
            if (printer.Computer != null)
            {
                printer.ComputerId = printer.Computer.Id;
                printer.Computer = null;
            }
            
            context.Entry(printer).State = EntityState.Added;
            await context.AddAsync(printer);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public async Task<Result> AddRange(IEnumerable<Printer> printers)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var printer in printers)
            {
                if (printer.ComputerId.HasValue && printer.ComputerId.Value > 0)
                {
                    printer.Computer = null;
                }
                else if (printer.Computer != null)
                {
                    printer.ComputerId = printer.Computer.Id;
                    printer.Computer = null;
                }
            }
            await context.Printers.AddRangeAsync(printers);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public async Task<Result> Remove(int id)
    {
        try
        {
            var printer = await context.Printers.AsNoTracking()
                .FirstAsync(x => x.Id == id);
            context.Entry(printer).State = EntityState.Deleted;
            context.Printers.Remove(printer);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public override async Task<Result> Update(Printer printer)
    {
        /*        try
                {*/
        var entity = await context.Printers.Include(x => x.Computer)
            .FirstAsync(x => x.Id == printer.Id);
        entity.Computer = printer.Computer;
        await context.SaveChangesAsync();
        return new Result(true);
        /*        }
                catch (Exception ex)
                {
                    return new()
                    {
                        Message = ex.Message
                    };
                }*/
    }

    #region Get Methods

    public async Task<Result<Printer>> Get(int id)
    {
        try
        {
            var printer = await context.Printers.Include(x => x.Computer)
                .FirstOrDefaultAsync(x => x.Id == id);
            return printer == null ? throw new Exception("Принтер не найден.") : new Result<Printer>(printer, true);
        }
        catch (Exception ex)
        {
            return new Result<Printer>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Printer>> Get()
    {
        return await context.Printers.AsNoTracking()
            .Include(static x => x.Computer)
            .ThenInclude(static x => x.User)
            .ToListAsync();
    }

    #endregion
}