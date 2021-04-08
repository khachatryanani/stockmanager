using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public static class Extensions
    {
        public static DataTable ConvertToProductsDataTable(this List<Product> list) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productId");
            dt.Columns.Add("quantity");
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                row["productId"] = item.ProductId;
                row["quantity"] = item.Quantity;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
