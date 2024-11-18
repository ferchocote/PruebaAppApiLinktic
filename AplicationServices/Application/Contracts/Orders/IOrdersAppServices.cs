using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Orders;
using Microsoft.AspNetCore.Mvc;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Orders
{
    public interface IOrdersAppServices
    {
        Task<RequestResult<List<GetOrdersDto>>> GetOrders();
        Task<RequestResult<Guid?>> CreateOrder(CreateOrderDto createOrderDto);
    }
}
