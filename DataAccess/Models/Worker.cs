using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
