using Dodayi.Services.BapAPI.Abstract;
using Dodayi.Services.BapAPI.Models;
using Dodayi.Services.BapAPI.Repository.IRepository;

namespace Dodayi.Services.BapAPI.Concrete
{
    public class ArbisKeywordManager : IArbisKeywordService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ArbisKeywordManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ArbisKeyword entity)
        {
            throw new NotImplementedException();
        }

        public ArbisKeyword GetArbisKey(int id)
        {
            //kendisine parametre olarak gonderılen arbis keyword ıdsıne gore 
            // ılgılı objeyı donderıyor.
            return _unitOfWork.ArbisKeyword.GetKeyword(x => x.Id == id);
        }

        public List<ArbisKeyword> GetArbisKeys(int id)
        {
            //parametre olarak arbis keyword ıdsı gonderıoz.
            //bize parentid si id ye esıt olan elemanların lıstesını donderıyor.
            return _unitOfWork.ArbisKeyword.GetListByFilter(a => a.ParentId == id).OrderBy(a => a.Turkish).ToList();
        }
        public decimal GetId()
        {
            throw new NotImplementedException();
        }

        public decimal GetIdTableName(string tableName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArbisKeyword> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(ArbisKeyword entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ArbisKeyword entity)
        {
            throw new NotImplementedException();
        }
    }
}
