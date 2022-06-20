using System.Data.SqlClient;

namespace TestProjectWithDB.SQLUtils
{
    public static class DBRequest
    {
        public static SqlConnection ConnectionToDB()
        {
            SqlConnection cn = new();
            cn.ConnectionString = @"Data Source=CMDB-132042\SQLEXPRESS;Database=CurrencyDB;Integrated Security=True";
            cn.Open();
            return cn;
        }

        public static void ExecuteCommand(string command)
        {
            SqlCommand cmd = new(command, ConnectionToDB());
            cmd.ExecuteNonQuery();
        }
    }
}
