using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class NewOrder
    {
        public int CustomerId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int ReceivedBy { get; set; }
        public List<Product> ProductList { get; set; }

    }
}
