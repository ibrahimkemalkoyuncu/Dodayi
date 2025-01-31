﻿using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;

namespace Dodayi.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetProductAsync(string productCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.ProductAPIBase + "/GetProduct/" + productCode,
                //Url = SD.ProductAPIBase + "/api/products/" + productCode,
                Url = SD.ProductAPIBase + "/api/product/GetByCode/" + productCode,
            });
        }

        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.ProductAPIBase + "/GetAllProducts",
                //Url = SD.ProductAPIBase + "/api/products",
                Url = SD.ProductAPIBase + "/api/product",
            });
        }
        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                //Url = SD.ProductAPIBase + "/api/product/GetById/" + id,
                Url = SD.ProductAPIBase + "/api/product/" + id,
            });
        }
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.ProductAPIBase + "/api/product",
                Data = productDto
            });
        }
        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + "/api/product",
                Data = productDto,
                //ContentType = SD.ContentType.MultipartFormData


            });
        }
        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                //Url = SD.ProductAPIBase + "/api/product/Delete/" + id,
                Url = SD.ProductAPIBase + "/api/product/" + id,
            });
        }
    }
}
