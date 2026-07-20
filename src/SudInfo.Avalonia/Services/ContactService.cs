namespace SudInfo.Avalonia.Services;

public class ContactService(
    SudInfoDatabaseContext context) : BaseService<Contact>(context)
{
    public async Task<Result> Remove(int id)
    {
        try
        {
            var entity = await context.Contacts
                .FirstAsync(x => x.Id == id);
            context.Entry(entity).State = EntityState.Deleted;
            context.Contacts.Remove(entity);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public async Task<Result> AddRange(IEnumerable<Contact> contacts)
    {
        try
        {
            context.ChangeTracker.Clear();
            await context.Contacts.AddRangeAsync(contacts);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }
    
    public void ClearTracker()
    {
        context.ChangeTracker.Clear();
    }
    
    

    #region Get Methods

    public async Task<IReadOnlyCollection<Contact>> Get()
    {
        return await context.Contacts.AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result<Contact>> Get(int id)
    {
        try
        {
            var entity = await context.Contacts.FirstAsync(x => x.Id == id);
            return new Result<Contact>(entity, true);
        }
        catch (Exception ex)
        {
            return new Result<Contact>(null, message: ex.Message);
        }
    }

    #endregion
}