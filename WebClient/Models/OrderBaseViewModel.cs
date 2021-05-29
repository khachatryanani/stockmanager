using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderBaseViewModel
    {
        public int customerId { get; set; }

        [Required]
        public string receivedDate { get; set; }
        public int receiverId { get; set; }
        public List<OrderItemBaseViewModel> orderItems { get; set; }
       
        public OrderBaseViewModel()
        {
            orderItems = new List<OrderItemBaseViewModel> { new OrderItemBaseViewModel() };
        }
    }
}
