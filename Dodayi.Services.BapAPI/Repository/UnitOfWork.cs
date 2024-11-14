using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.EntityFramework.Abstract;
using Dodayi.Services.BapAPI.EntityFramework.Concrete;
using Dodayi.Services.BapAPI.Repository.IRepository;

namespace Dodayi.Services.BapAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext _db;
        public UnitOfWork(ModelContext db)
        {
            _db = db;

            ArbisKeyword = new ArbisKeywordDal(_db);
           
        }


        public IArbisKeywordDal ArbisKeyword { get; set; }
      

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
