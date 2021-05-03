using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
