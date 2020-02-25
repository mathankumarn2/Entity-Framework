using System.Configuration;
using System.Data.SqlClient;

namespace OnlineCollegeAdmission.DAL
{
    public static class DButils
    {
        public static SqlConnection GetDbconnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Online-College-Admission"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

    }
}
