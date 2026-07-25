namespace SudInfo.Avalonia.Services;

public class BaseService<T>(
    SudInfoDatabaseContext context) where T : class
{
    #region Private variables

    protected readonly SudInfoDatabaseContext context = context;

    #endregion

    #region Methods

    public virtual async Task<Result> Update(T rutoken)
    {
        try
        {
            context.Entry(rutoken).State = EntityState.Modified;
            context.Update(rutoken);
            await context.SaveChangesAsync();
            return new Result(true);
        }
        catch (DbUpdateException ex)
        {
            return new Result
            {
                Message = ex.InnerException.Message
            };
        }
    }

    public virtual async Task<Result> Add(T entity)
    {
        try
        {
            context.Entry(entity).State = EntityState.Added;
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return new Result
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new Result
            {
                Message = ex.Message
            };
        }
    }

    #endregion
}