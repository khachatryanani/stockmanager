using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
