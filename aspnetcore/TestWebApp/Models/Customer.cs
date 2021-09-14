using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Customer : TableEntity
    {    
        public string Name { get; set; }
        public string City { get; set; }
    }
}
