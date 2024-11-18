using DomainServices.Domain.Contracts.Orders;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Orders
{
    public class OrdersDomain : IOrdersDomain
    {
        private readonly LinkticEcomerceContext _linkticEcomerceContext;

        public OrdersDomain(LinkticEcomerceContext linkticEcomerceContext)
        {
            _linkticEcomerceContext = linkticEcomerceContext;
        }

        /// <summary>
        /// Consulta las ordenes creadas
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<List<Order>> GetOrders()
        {
            return await _linkticEcomerceContext.Order
                                .Include(i => i.UserNavigation)
                                .AsNoTracking()
                                .ToListAsync();
        }

        /// <summary>
        /// Crea una orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <author>Diego Molina</author>
        public async Task<Guid?> CreateOrder(Order order)
        {
            await _linkticEcomerceContext.Order.AddAsync(order);
            await _linkticEcomerceContext.SaveChangesAsync();
            return order.ID;

        }
    }
}
