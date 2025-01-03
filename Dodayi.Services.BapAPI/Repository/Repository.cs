using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelContext _db;
        internal DbSet<T> dbSet;
        public Repository(ModelContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);

        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            //dbSet.Update(entity);
            var updatedEntity = _db.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _db.SaveChanges();
        }
        public IEnumerable<T> GetList()
        {
            return dbSet.ToList();
        }
        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList(); //şartlı listeleme repository.
        }
        public T GetByID(int? id)
        {
            return dbSet.Find(id)!;
        }

        // oracle veritabanı ıcın gecerlı.
        // tablo adı ve seq adı aynı ıse bu metot kullanılcak

        public decimal GetId()
        {
            var command = _db.Database.GetDbConnection().CreateCommand();

            var tableName = _db.TableName(typeof(T));

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = $"SELECT SEQ_{tableName}.NEXTVAL FROM DUAL";

            _db.Database.OpenConnection();

            try
            {
                var result = (decimal?)command.ExecuteScalar();

                return result.Value;
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        // oracle veritabanı ıcın gecerlı.
        // tablo adı ve seq adı farklı ıse bu metot kullanılcak

        public decimal GetIdTableName(string tableName)
        {
            var command = _db.Database.GetDbConnection().CreateCommand();


            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = $"SELECT SEQ_{tableName}.NEXTVAL FROM DUAL";

            _db.Database.OpenConnection();

            try
            {
                var result = (decimal?)command.ExecuteScalar();

                return result.Value;
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }
    }
}
