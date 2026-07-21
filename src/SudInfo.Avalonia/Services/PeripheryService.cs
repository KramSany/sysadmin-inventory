namespace SudInfo.Avalonia.Services;

public class PeripheryService(
    SudInfoDatabaseContext context) : BaseService<Periphery>(context)
{
    public override async Task<Result> Add(Periphery periphery)
    {
        try
        {
            if (periphery.Computer != null)
                periphery.Computer = await context.Computers.AsNoTracking()
                    .FirstAsync(x => x.Id == periphery.Computer.Id);
            context.Entry(periphery).State = EntityState.Added;
            await context.Peripheries.AddAsync(periphery);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<Periphery> peripherys)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var periphery in peripherys)
            {
                if (periphery.Computer != null)
                    periphery.Computer = await context.Computers.AsNoTracking()
                        .SingleOrDefaultAsync(x => x.Id == periphery.Computer.Id);
            }

            await context.Peripheries.AddRangeAsync(peripherys);
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
            var periphery = await context.Peripheries
                .FirstAsync(x => x.Id == id);
            context.Entry(periphery).State = EntityState.Deleted;
            context.Peripheries.Remove(periphery);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get Methods

    public async Task<Result<Periphery>> Get(int id)
    {
        try
        {
            var periphery = await context.Peripheries.Include(x => x.Computer)
                .ThenInclude(x => x.User)
                .FirstAsync(x => x.Id == id);
            return new Result<Periphery>(periphery, true);
        }
        catch (Exception ex)
        {
            return new Result<Periphery>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Periphery>> Get()
    {
        return await context.Peripheries.Include(static x => x.Computer)
            .ThenInclude(static x => x.User)
            .ToListAsync();
    }

    #endregion
}