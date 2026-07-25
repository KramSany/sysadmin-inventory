namespace SudInfo.Avalonia.Services;

public class MonitorService(
    SudInfoDatabaseContext context) : BaseService<Monitor>(context)
{
    public async Task<Result> Remove(int id)
    {
        try
        {
            var monitor = await context.Monitors
                .FirstAsync(x => x.Id == id);
            context.Entry(monitor).State = EntityState.Deleted;
            context.Monitors.Remove(monitor);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public override async Task<Result> Add(Monitor monitor)
    {
        try
        {
            if (monitor.Computer != null)
                monitor.Computer = await context.Computers
                    .FirstAsync(x => x.Id == monitor.Computer.Id);
            context.Entry(monitor).State = EntityState.Added;
            await context.Monitors.AddAsync(monitor);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public override async Task<Result> Update(Monitor rutoken)
    {
        try
        {
            var entity = await context.Monitors.Include(x => x.Computer)
                .FirstAsync(x => x.Id == rutoken.Id);
            entity.Computer = rutoken.Computer;
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result
            {
                Message = ex.Message
            };
        }
    }

    public async Task<Result> AddRange(IEnumerable<Monitor> monitor)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var monitors in monitor)
            {
                if (monitors.Computer != null)
                    monitors.Computer = await context.Computers.AsNoTracking()
                        .SingleOrDefaultAsync(x => x.Id == monitors.Computer.Id);
            }
            await context.Monitors.AddRangeAsync(monitor);
            await context.SaveChangesAsync();
            return new Result(true);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void ClearTracker()
    {
        context.ChangeTracker.Clear();
    }

    #region Get Methods

    public async Task<IReadOnlyCollection<Monitor>> Get()
    {
        return await context.Monitors.AsNoTracking()
            .Include(static x => x.Computer)
            .ThenInclude(static x => x.User)
            .ToListAsync();
    }

    public async Task<Result<Monitor>> Get(int id)
    {
        try
        {
            var monitor = await context.Monitors.Include(x => x.Computer)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            return monitor == null ? throw new Exception("Computer not Found") : new Result<Monitor>(monitor, true);
        }
        catch (Exception ex)
        {
            return new Result<Monitor>(null, message: ex.Message);
        }
    }

    #endregion
}