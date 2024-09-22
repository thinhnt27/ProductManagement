
using Microsoft.EntityFrameworkCore;
using SWP.ProductManagement.Repository.Models;
using System.Linq.Expressions;

namespace SWP.ProductManagement.Repository;

public class GenericRepository<TEntity>
    where TEntity : class
{
    internal ProductManagementContext context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(ProductManagementContext context)
    {
        this.context = context;
        dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(object id) => await dbSet.FindAsync(id);

    public virtual async Task InsertAsync(TEntity entity) => await dbSet.AddAsync(entity);

    public virtual void Delete(object id)
    {
        TEntity? entityToDelete = dbSet.Find(id);
        if (entityToDelete is not null)
            Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual async Task<bool> IsExist(object id)
    {
        return (await GetByIdAsync(id)) is not null;
    }
}

