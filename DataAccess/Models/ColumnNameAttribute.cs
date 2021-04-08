using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ColumnNameAttribute : System.Attribute
    {
        public ColumnNameAttribute(string Name) { this.Name = Name; }
        public string Name { get; set; }
    }
}
