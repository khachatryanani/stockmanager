using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public char Category { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return this.Name + " "+ this.Unit;
        }
    }
}
