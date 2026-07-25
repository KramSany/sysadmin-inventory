namespace SudInfo.Avalonia.Services;

public class RutokenService(
    SudInfoDatabaseContext context) : BaseService<Rutoken>(context)
{
    public async Task<Result> Remove(int id)
    {
        try
        {
            var rutoken = await context.Rutokens
                .FirstAsync(x => x.Id == id);
            context.Entry(rutoken).State = EntityState.Deleted;
            context.Rutokens.Remove(rutoken);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public override async Task<Result> Update(Rutoken rutoken)
    {
        int? selectedComputerId = rutoken.User?.Id;
        
        rutoken.User = null;
        rutoken.UserId = selectedComputerId;
        
        context.ChangeTracker.Clear();
        context.Rutokens.Update(rutoken);
        
        await context.SaveChangesAsync();
        return new Result(true);
       
    }

    public override async Task<Result> Add(Rutoken rutoken)
    {
        try
        {
            if (rutoken.User != null)
                rutoken.User = await context.Users
                    .FirstAsync(x => x.Id == rutoken.User.Id);
            context.Entry(rutoken).State = EntityState.Added;
            await context.Rutokens.AddAsync(rutoken);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<Rutoken> rutokens)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var rutoken in rutokens)
            {
                if (rutoken.UserId.HasValue && rutoken.UserId.Value > 0)
                {
                    rutoken.User = null;
                }
                else if (rutoken.User != null)
                {
                    rutoken.UserId = rutoken.User.Id;
                    rutoken.User = null;
                }
            }
            await context.Rutokens.AddRangeAsync(rutokens);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get Methods

    public async Task<Result<Rutoken>> Get(int id)
    {
        try
        {
            var rutoken = await context.Rutokens.Include(x => x.User)
                .FirstAsync(x => x.Id == id);
            return rutoken == null ? throw new Exception("ЭЦП не найден") : new Result<Rutoken>(rutoken, true);
        }
        catch (Exception ex)
        {
            return new Result<Rutoken>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Rutoken>> Get()
    {
        context.ChangeTracker.Clear();
        return await context.Rutokens
            .Include(static x => x.User)
            .ToListAsync();
    }

    #endregion
}