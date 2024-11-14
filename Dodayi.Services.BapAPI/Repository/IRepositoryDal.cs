using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.Repository
{
    public interface IRepositoryDal<TEntity>
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
