using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.EntityFramework.Abstract;
using Dodayi.Services.BapAPI.Models;
using Dodayi.Services.BapAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.EntityFramework.Concrete
{
    public class ArbisKeywordDal : Repository<ArbisKeyword>, IArbisKeywordDal
    {
        public ArbisKeywordDal(ModelContext db) : base(db)
        {
        }

        public ArbisKeyword GetKeyword(Expression<Func<ArbisKeyword, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }
    }
}
