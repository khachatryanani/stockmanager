using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Order
    {
        [ColumnName("ID")]
        public int OrderId { get; set; }

        [ColumnName("Name")]
        public string CustomerName { get; set; }

        [ColumnName("Address")]
        public string CustomerAddress { get; set; }

        [ColumnName("Total Price")]
        public double TotalPrice { get; set; }

        [ColumnName("Received On")]
        public DateTime ReceivedDate { get; set; }

        [ColumnName("Received By")]
        public string ReceivedBy { get; set; }

        [ColumnName("Status")]
        public string Status { get; set; }

        [ColumnName("Delivered On")]
        public DateTime DeliveryDate { get; set; }

        [ColumnName("Delivered By")]
        public string DeliveredBy { get; set; }
    }
}
