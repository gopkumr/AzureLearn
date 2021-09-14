using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Order
    {
        public Guid id { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
    }
}
