using AplicationServices.Application.Contracts.Orders;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Orders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Orders")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly IOrdersAppServices _ordersAppServices;

        public OrdersController(IOrdersAppServices ordersAppServices)
        {
            _ordersAppServices = ordersAppServices;
        }

        /// <summary>
        /// Consulta las ordenes creadas
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpGet("GetOrders")]
        public async Task<RequestResult<List<GetOrdersDto>>> GetOrders() => await _ordersAppServices.GetOrders();

        /// <summary>
        /// Crea una orden
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        [HttpPost("CreateOrder")]
        public async Task<RequestResult<Guid?>> CreateOrder(CreateOrderDto createOrderDto) => await _ordersAppServices.CreateOrder(createOrderDto);
    }
}
