using Dodayi.Services.BapAPI.Models;

namespace Dodayi.Services.BapAPI.Abstract
{
    public interface IArbisKeywordService : IGenericService<ArbisKeyword>
    {
        List<ArbisKeyword> GetArbisKeys(int id);
        ArbisKeyword GetArbisKey(int id);
    }
}
