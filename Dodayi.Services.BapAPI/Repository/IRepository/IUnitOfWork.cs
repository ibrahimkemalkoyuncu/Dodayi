using Dodayi.Services.BapAPI.EntityFramework.Abstract;

namespace Dodayi.Services.BapAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IArbisKeywordDal ArbisKeyword { get; }
       


        void Save();
    }
}
