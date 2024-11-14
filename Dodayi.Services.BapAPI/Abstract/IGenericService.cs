namespace Dodayi.Services.BapAPI.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        decimal GetId();
        decimal GetIdTableName(string tableName);
        IEnumerable<T> GetList();
    }
}
