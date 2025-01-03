using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.EntityFramework.Abstract;
using Dodayi.Services.BapAPI.Models;
using Dodayi.Services.BapAPI.Repository;
using Dodayi.Services.BapAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.EntityFramework.Concrete
{
    public class ArbisKeywordDal : Repository<ArbisKeyword>, IArbisKeywordDal
    {
        public ArbisKeywordDal(ModelContext db) : base(db)
        {
        }

        public ArbisKeyword? GetKeyword(Expression<Func<ArbisKeyword, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        ArbisKeyword? IRepository<ArbisKeyword> .GetByID(int? id)
        {
            return dbSet.Find(id);
        }
    }
}
