using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public static class Extensions
    {
        public static DataTable ConvertToProductsDataTable(this List<OrderItem> list) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productId");
            dt.Columns.Add("quantity");
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                row["productId"] = item.OrderedProduct.ProductId;
                row["quantity"] = item.Quantity;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString) 
        {
            services.AddScoped<IDataRepository, DataRepository>(dt => new DataRepository(connectionString));
            return services;
        }
    }
}
