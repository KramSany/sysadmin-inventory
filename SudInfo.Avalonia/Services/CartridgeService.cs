namespace SudInfo.Avalonia.Services;

public class CartridgeService(
    SudInfoDatabaseContext context) : BaseService<Cartridge>(context)
{
    
    public override async Task<Result> Add(Cartridge cartridge)
    {
        try
        {
            context.ChangeTracker.Clear();
            context.Entry(cartridge).State = EntityState.Added;
            await context.AddAsync(cartridge);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<Cartridge> catridges)
    {
        try
        {
            context.ChangeTracker.Clear();
            await context.Cartridges.AddRangeAsync(catridges);
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
            
            var cartridge = await context.Cartridges
                .FirstAsync(x => x.Id == id);
            context.Cartridges.Remove(cartridge);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get Methods

    public async Task<Result<Cartridge>> Get(int id)
    {
        try
        {
            var cartridge = await context.Cartridges.FirstAsync(x => x.Id == id);
            return new Result<Cartridge>(cartridge, true);
        }
        catch (Exception ex)
        {
            return new Result<Cartridge>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Cartridge>> Get()
    {
        return await context.Cartridges.AsNoTracking()
            .ToListAsync();
    }
    
    public void ClearTracker()
    {
        context.ChangeTracker.Clear();
    }


    #endregion
}