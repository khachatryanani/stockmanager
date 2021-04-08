using System.Data.SqlClient;

namespace DataAccess
{
    public static class ConnectionManager
    {
        public static SqlConnection ConnectToDb(string connectionString) 
        {
            return new SqlConnection(connectionString);
        }
    }
}
