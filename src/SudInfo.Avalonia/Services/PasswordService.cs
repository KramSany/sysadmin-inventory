namespace SudInfo.Avalonia.Services;

public class PasswordService(
    SudInfoDatabaseContext context) : BaseService<PasswordEntity>(context)
{
    public async Task<Result> Remove(int id)
    {
        try
        {
            var passwordEntity = await context.Passwords.AsNoTracking()
                .FirstAsync(x => x.Id == id);
            context.Entry(passwordEntity).State = EntityState.Deleted;
            context.Passwords.Remove(passwordEntity);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(message: ex.Message);
        }
    }

    #region Get Methods

    public async Task<IReadOnlyCollection<PasswordEntity>> Get()
    {
        return await context.Passwords.AsNoTracking().ToListAsync();
    }

    public async Task<Result<PasswordEntity>> Get(int id)
    {
        try
        {
            var server = await context.Passwords.FirstAsync(x => x.Id == id);
            return new Result<PasswordEntity>(server, true);
        }
        catch (Exception ex)
        {
            return new Result<PasswordEntity>(null, message: ex.Message);
        }
    }

    #endregion
}