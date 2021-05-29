using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class CustomerViewModel
    {
        public int customerId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }
        public string phone { get; set; }
    }
}
