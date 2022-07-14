using Core.Entities;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFrameworkCore
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter=null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
