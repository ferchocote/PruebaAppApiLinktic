using AplicationServices.Application.Contracts.Orders;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Orders;
using AutoMapper;
using DomainServices.Domain.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Orders
{
    public class OrdersAppServices : IOrdersAppServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly IOrdersDomain _ordersDomain;
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        public OrdersAppServices(IOrdersDomain ordersDomain, IMapper mapper)
        {
            _ordersDomain = ordersDomain;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta las ordenes creadas
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<List<GetOrdersDto>>> GetOrders()
        {
            try
            {

                var process = await _ordersDomain.GetOrders();
                var resultadoDto = _mapper.Map<List<Order>, List<GetOrdersDto>>(process);
                return RequestResult<List<GetOrdersDto>>.CreateSuccessful(resultadoDto);


            }
            catch (Exception ex)
            {
                return RequestResult<List<GetOrdersDto>>.CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Crea una orden
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<RequestResult<Guid?>> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                Order order = _mapper.Map<CreateOrderDto, Order>(createOrderDto);
                List<OrderItem> orderItem = _mapper.Map<List<OrderItemDto>, List<OrderItem>>(createOrderDto.orderItems);
                orderItem.ForEach(f => f.Order = order.ID);
                order.OrderItem = orderItem;

                Guid? IDOrder = await _ordersDomain.CreateOrder(order);
                return RequestResult<Guid?>.CreateSuccessful(IDOrder);

            }
            catch (Exception ex)
            {
                return RequestResult<Guid?>.CreateError(ex.Message);
            }
        }


    }
}
