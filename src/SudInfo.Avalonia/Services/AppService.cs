namespace SudInfo.Avalonia.Services;

public class AppService(
    SudInfoDatabaseContext context) : BaseService<AppEntity>(context)
{
    public async Task<Result> Remove(int id)
    {
        try
        {
            var entity = await context.Apps
                .Include(x => x.Computers)
                .FirstAsync(x => x.Id == id);
            entity.Computers!.Clear();
            context.Entry(entity).State = EntityState.Deleted;
            context.Apps.Remove(entity);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public override async Task<Result> Update(AppEntity rutoken)
    {
        context.ChangeTracker.Clear();
        try
        {
            var app = await context.Apps.Include(x => x.Computers)
                .FirstAsync(x => x.Id == rutoken.Id);
            app.Name = rutoken.Name;
            app.Version = rutoken.Version;
            if (rutoken.Computers!.Count == 0)
            {
                app.Computers = null;
            }
            else
            {
                app.Computers = [];
                foreach (var computer in rutoken.Computers)
                    app.Computers.Add(await context.Computers.FindAsync(computer.Id));
            }

            context.Update(app);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public override async Task<Result> Add(AppEntity entity)
    {
        try
        {
            var computers = entity.Computers;
            entity.Computers = [];
            foreach (var computer in computers) entity.Computers.Add(await context.Computers.FindAsync(computer.Id));
            context.Entry(entity).State = EntityState.Added;
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<AppEntity> appEntities)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var app in appEntities)
            {
                if (app.Computers != null && app.Computers.Any())
                {
                    var computerIds = app.Computers.Select(c => c.Id).Where(id => id > 0).ToList();
                    
                    app.Computers = new List<Computer>();
                    
                    foreach (var id in computerIds)
                    {
                        var existingComputer = await context.Computers.FindAsync(id);
                        if (existingComputer != null)
                        {
                            app.Computers.Add(existingComputer);
                        }
                    }
                }
            }

            await context.Apps.AddRangeAsync(appEntities);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get Methods

    public async Task<IReadOnlyCollection<AppEntity>> Get()
    {
        return await context.Apps.AsNoTracking()
            .Include(static x => x.Computers)
            .ThenInclude(static x => x.User)
            .ToListAsync();
    }

    public async Task<Result<AppEntity>> Get(int id)
    {
        try
        {
            var server = await context.Apps
                .Include(x => x.Computers)
                .FirstAsync(x => x.Id == id);
            return new Result<AppEntity>(server, true);
        }
        catch (Exception ex)
        {
            return new Result<AppEntity>(null, message: ex.Message);
        }
    }

    #endregion
}