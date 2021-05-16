using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class OrderItemBaseModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
