using AplicationServices.Application.Contracts.Products;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Orders;
using AplicationServices.DTOs.Products;
using AutoMapper;
using DomainServices.Domain.Contracts.Orders;
using DomainServices.Domain.Contracts.Products;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Products
{
    public class ProductsAppServices : IProductsAppServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly IProductsDomain _productsDomain;
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        public ProductsAppServices(IProductsDomain productsDomain, IMapper mapper)
        {
            _productsDomain = productsDomain;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta todos los productos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<List<GetProductsDto>>> GetProducts()
        {
            try
            {

                var process = await _productsDomain.GetProducts();
                var resultadoDto = _mapper.Map<List<Product>, List<GetProductsDto>>(process);
                return RequestResult<List<GetProductsDto>>.CreateSuccessful(resultadoDto);

            }
            catch (Exception ex)
            {
                return RequestResult<List<GetProductsDto>>.CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Crea un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<Guid?>> AddProduct(AddProductDto addProductDto)
        {
            try
            {
                Product product = _mapper.Map<AddProductDto, Product>(addProductDto);
                Guid? IDProduct = await _productsDomain.CreateProduct(product);
                return RequestResult<Guid?>.CreateSuccessful(IDProduct);

            }
            catch (Exception ex)
            {
                return RequestResult<Guid?>.CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<Guid?>> UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            try
            {
                Product product = _mapper.Map<UpdateProductDto, Product>(updateProductDto);
                Guid? IDProduct = await _productsDomain.UpdateProduct(id, product);
                return RequestResult<Guid?>.CreateSuccessful(IDProduct);

            }
            catch (Exception ex)
            {
                return RequestResult<Guid?>.CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<Guid?>> DeleteProduct(Guid id)
        {
            try
            {
                Guid? IDProduct = await _productsDomain.DeleteProduct(id);
                return RequestResult<Guid?>.CreateSuccessful(IDProduct);

            }
            catch (Exception ex)
            {
                return RequestResult<Guid?>.CreateError(ex.Message);
            }
        }
    }
}
