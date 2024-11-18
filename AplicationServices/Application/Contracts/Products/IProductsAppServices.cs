using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Products
{
    public interface IProductsAppServices
    {
        Task<RequestResult<List<GetProductsDto>>> GetProducts();
        Task<RequestResult<Guid?>> AddProduct(AddProductDto addProductDto);
        Task<RequestResult<Guid?>> UpdateProduct(Guid id, UpdateProductDto updateProductDto);
        Task<RequestResult<Guid?>> DeleteProduct(Guid id);
    }
}
