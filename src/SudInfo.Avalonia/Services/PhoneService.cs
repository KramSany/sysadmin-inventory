namespace SudInfo.Avalonia.Services;

public class PhoneService(
    SudInfoDatabaseContext context) : BaseService<Phone>(context)
{
    public override async Task<Result> Add(Phone phone)
    {
        try
        {
            if (phone.User != null)
            {
                phone.UserId = phone.User.Id;
                phone.User = null;
            }
            
            context.Entry(phone).State = EntityState.Added;
            await context.AddAsync(phone);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    public async Task<Result> AddRange(IEnumerable<Phone> phones)
    {
        try
        {
            context.ChangeTracker.Clear();
            foreach (var phone in phones)
            {
                if (phone.UserId.HasValue && phone.UserId.Value > 0)
                {
                    
                    phone.User = null;
                }
                else if (phone.User != null)
                {
                    phone.UserId = phone.User.Id;
                    phone.User = null;
                }
            }

            await context.Phones.AddRangeAsync(phones);
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
            var phone = await context.Phones
                .FirstAsync(x => x.Id == id);
            context.Entry(phone).State = EntityState.Deleted;
            context.Remove(phone);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get methods

    public async Task<Result<Phone>> Get(int id)
    {
        try
        {
            var phone = await context.Phones.Include(x => x.User)
                .FirstAsync(x => x.Id == id);
            return phone == null ? throw new Exception("Телефон не найден") : new Result<Phone>(phone, true);
        }
        catch (Exception ex)
        {
            return new Result<Phone>(null, message: ex.Message);
        }
    }

    public async Task<IReadOnlyCollection<Phone>> Get()
    {
        return await context.Phones.AsNoTracking()
            .Include(static x => x.User)
            .ToListAsync();
    }

    #endregion
}