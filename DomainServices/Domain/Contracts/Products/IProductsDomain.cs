using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Contracts.Products
{
    public interface IProductsDomain
    {
        Task<List<Product>> GetProducts();
        Task<Guid?> CreateProduct(Product product);
        Task<Guid?> UpdateProduct(Guid id, Product product);
        Task<Guid?> DeleteProduct(Guid id);
    }
}
