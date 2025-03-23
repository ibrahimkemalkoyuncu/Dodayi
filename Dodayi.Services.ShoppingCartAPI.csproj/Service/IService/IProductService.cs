using Dodayi.Services.ShoppingCartAPI.Dto;

namespace Dodayi.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
