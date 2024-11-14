using Dodayi.Services.BapAPI.Models;
using Dodayi.Services.BapAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace Dodayi.Services.BapAPI.EntityFramework.Abstract
{
    public interface IArbisKeywordDal : IRepository<ArbisKeyword>
    {
        ArbisKeyword GetKeyword(Expression<Func<ArbisKeyword, bool>> filter);
    }
}
