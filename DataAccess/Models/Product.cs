using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public char Category { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public string Unit { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }
    }
}
