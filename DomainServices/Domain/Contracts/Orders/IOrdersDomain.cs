using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Contracts.Orders
{
    public interface IOrdersDomain
    {
        Task<List<Order>> GetOrders();
        Task<Guid?> CreateOrder(Order order);   
    }
}
