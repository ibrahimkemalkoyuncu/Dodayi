using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

        IEnumerable<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        T GetByID(int? id);
        decimal GetId();
        decimal GetIdTableName(string tableName);
    }
}
