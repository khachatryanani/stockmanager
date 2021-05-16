using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
 
namespace WebApi.Models
{
    public class WorkerModel
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
    }
}
