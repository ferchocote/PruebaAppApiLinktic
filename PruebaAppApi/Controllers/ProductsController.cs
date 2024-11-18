using AplicationServices.Application.Contracts.Orders;
using AplicationServices.Application.Contracts.Products;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Products")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : Controller
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly IProductsAppServices _ProductsAppServices;

        public ProductsController(IProductsAppServices productsAppServices)
        {
            _ProductsAppServices = productsAppServices;
        }

        /// <summary>
        /// Consulta todos los productos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpGet]
        public async Task<RequestResult<List<GetProductsDto>>> GetProducts() => await _ProductsAppServices.GetProducts();

        /// <summary>
        /// Crea un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpPost]
        public async Task<RequestResult<Guid?>> AddProduct(AddProductDto addProductDto) => await _ProductsAppServices.AddProduct(addProductDto);

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpPut("{id}")]
        public async Task<RequestResult<Guid?>> UpdateProduct(Guid id, UpdateProductDto updateProductDto) => await _ProductsAppServices.UpdateProduct(id, updateProductDto);

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpDelete("{id}")]
        public async Task<RequestResult<Guid?>> DeleteProduct(Guid id) => await _ProductsAppServices.DeleteProduct(id);
    }
}
