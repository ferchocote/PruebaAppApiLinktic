using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Orders
{
    public class GetOrdersDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Number {  get; set; }
        public string User {  get; set; }
    }
}
