using Microsoft.EntityFrameworkCore;

namespace Logcast.Recruitment.DataAccess.Repositories.Base
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
