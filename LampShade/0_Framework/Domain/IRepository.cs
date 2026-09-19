using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
