using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DataHelper
    {

        static SqlConnection sqlConnection = new SqlConnection("Data Source=;Initial Catalog=;Integrated Security=;");

        public static DataTable GetDepartements()
        {
            SqlCommand sqlCommand = new SqlCommand("Select Dname,Dnum,MGRSSN from Departments", sqlConnection);
            //sqlCommand.Connection = sqlConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public static DataTable GetDepartementEmployees(int depID)
        {
            SqlCommand sqlCommand = new SqlCommand($"Select * from Employee where Dno={depID}", sqlConnection);
            //sqlCommand.Connection = sqlConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

    }
}