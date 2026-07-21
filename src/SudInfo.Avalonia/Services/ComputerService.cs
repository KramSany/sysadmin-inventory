namespace SudInfo.Avalonia.Services;

public class ComputerService(
    SudInfoDatabaseContext context) : BaseService<Computer>(context)
{
    public override async Task<Result> Add(Computer computer)
    {
        try
        {
            if (computer.User != null)
            {
                computer.UserId = computer.User.Id;
                computer.User = null;
            }
            
            context.Entry(computer).State = EntityState.Added;
            await context.AddAsync(computer);
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
            var computer = await context.Computers
                .SingleOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Computer not found");
            context.Remove(computer);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<Computer> computers)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var computer in computers)
            {
                if (computer.UserId.HasValue && computer.UserId.Value > 0)
                {
                    
                    computer.User = null;
                }
                else if (computer.User != null)
                {
                    computer.UserId = computer.User.Id;
                    computer.User = null;
                }
            }

            await context.Computers.AddRangeAsync(computers);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }


    #region Get Methods

    public async Task<Result<Computer>> Get(int id)
    {
        try
        {
            var computer = await context.Computers.Include(x => x.User)
                .FirstAsync(x => x.Id == id);
            return computer == null ? throw new Exception("Computer not Found") : new Result<Computer>(computer, true);
        }
        catch (Exception ex)
        {
            return new Result<Computer>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Computer>> Get()
    {
        return await context.Computers.AsNoTracking()
            .Include(static x => x.User)
            .ToListAsync();
    }

    #endregion

    /*   public override async Task<Result> Update(Computer computer)
       {
           try
           {
               var computerFromDatabase = await context.Computers.Include(x => x.User).FirstAsync(x => x.Id == computer.Id);
               computerFromDatabase.User = computer.User;
               await context.SaveChangesAsync();
               return new()
               {
                   Success = true
               };
           }
           catch (Exception ex)
           {
               return new()
               {
                   Message = ex.Message
               };
           }
       }*/
}