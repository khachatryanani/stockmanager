using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public char Category { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }


        public ProductModel(Product product)
        {
            this.ProductId = product.ProductId;
            this.Name = product.Name;
            this.Category = product.Category;
            this.Type = product.Type;
            this.Unit = product.Unit;
        }

        public override string ToString()
        {
            return this.Name + " "+ this.Unit;
        }

    }
}
