using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengoDotNetCore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
