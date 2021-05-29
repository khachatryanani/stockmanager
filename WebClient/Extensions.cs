using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public static class Extensions
    {
        public static int AddToCollection(this List<OrderItemBaseViewModel> list, OrderItemBaseViewModel orderItem) 
        {
            list.Add(orderItem);
            return list.Count;
        }
    }
}
