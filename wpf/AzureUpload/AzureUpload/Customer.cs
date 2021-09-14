using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureUpload
{
    public class Customer:TableEntity
    {
        public string Name { get; set; }
    }
}
