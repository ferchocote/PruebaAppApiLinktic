using DomainServices.Domain.Contracts.Products;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Products
{
    public class ProductsDomain : IProductsDomain
    {
        private readonly LinkticEcomerceContext _linkticEcomerceContext;

        public ProductsDomain(LinkticEcomerceContext linkticEcomerceContext)
        {
            _linkticEcomerceContext = linkticEcomerceContext;
        }

        /// <summary>
        /// Consulta todos los productos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<List<Product>> GetProducts()
        {
            return await _linkticEcomerceContext.Product
                                .Where(w => w.State)
                                .AsNoTracking()
                                .ToListAsync();
        }

        /// <summary>
        /// Crea un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<Guid?> CreateProduct(Product product)
        {
            await _linkticEcomerceContext.Product.AddAsync(product);
            await _linkticEcomerceContext.SaveChangesAsync();
            return product.ID;

        }

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<Guid?> UpdateProduct(Guid id, Product product)
        {
            Product? productExist = await _linkticEcomerceContext.Product
                                .FirstOrDefaultAsync(f => f.ID.Equals(id));
            if (productExist != null)
            {
                _linkticEcomerceContext.Entry(productExist).CurrentValues.SetValues(product);
                await _linkticEcomerceContext.SaveChangesAsync();
                return product.ID;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<Guid?> DeleteProduct(Guid id)
        {
            Product? product = await _linkticEcomerceContext.Product
                                .AsNoTracking()
                                .FirstOrDefaultAsync(f => f.ID.Equals(id));
            if (product != null)
            {
                _linkticEcomerceContext.Product.Remove(product);
                await _linkticEcomerceContext.SaveChangesAsync();
                return product.ID;
            }
            else
            {
                return null;
            }
        }
    }
}
