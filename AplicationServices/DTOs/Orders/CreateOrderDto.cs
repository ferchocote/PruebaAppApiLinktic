using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Orders
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public int Number {  get; set; }
        public Guid User {  get; set; }
        public List<OrderItemDto> orderItems { get; set; }
    }

    public class OrderItemDto
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
