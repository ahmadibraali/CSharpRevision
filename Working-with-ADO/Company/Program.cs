using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=;Initial Catalog=;User ID = ;password=;");
            
            //SqlConnection sqlConnection = new SqlConnection("");

            // Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            ///
            ////////////////////////////////////////////////
            #region Connected Mode
            /// Step(1) Open Connection
            //sqlConnection.Open();

            /// Step(2) Retreive Records One By One Using Data Reader
            #region Execute Query
            //sqlCommand.CommandText = "select * from Employee";

            /*SqlDataReader reader = sqlCommand.ExecuteReader();

            /// ├ Important Functions in Data Reader ┤


            //while (reader.NextResult())
            while (reader.Read())
            {
                int id = (int)reader["SSN"];
                string name = (string)reader["Fname"] + " " + (string)reader["Lname"];
                int depno = reader["Dno"] is DBNull ? 0 : (int)reader["Dno"];
                string address = (string)reader["Address"];



                Console.WriteLine($"├ID:{id} ┤ \t ├Name: {name}┤ \t ├Dep No: {depno}┤ \t ├Address: {address}┤");

            }*/
            #endregion


            #region Executed Scalar 
            /*
                        sqlCommand.CommandText = "Select count(*) from Employee";
                        int count = (int)sqlCommand.ExecuteScalar();
                        Console.WriteLine($"├ Count :  {count}┤");*/
            #endregion


            #region Execute Non Query
            /*
                sqlCommand.CommandText = "Delete Departments where ID>85";
                int rowAffectedCount = (int)sqlCommand.ExecuteNonQuery();
    */

            #endregion
            #region Stored Procedures 

            //int salary = 1000;
            /*sqlCommand.CommandText = "[dbo].[ProcGetEmployee]";
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@sal", salary);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["SSN"];
                string name = (string)reader["Fname"] + " " + (string)reader["Lname"];
                int depno = reader["Dno"] is DBNull ? 0 : (int)reader["Dno"];
                string address = (string)reader["Address"];



                Console.WriteLine($"├ID:{id} ┤ \t ├Name: {name}┤ \t ├Dep No: {depno}┤ \t ├Address: {address}┤");

            }
                        */

            /* sqlCommand.CommandText = $"exec [dbo].[ProcGetEmployee] {salary}";
             SqlDataReader reader = sqlCommand.ExecuteReader();
             while (reader.Read())
             {
                 int id = (int)reader["SSN"];
                 string name = (string)reader["Fname"] + " " + (string)reader["Lname"];
                 int depno = reader["Dno"] is DBNull ? 0 : (int)reader["Dno"];
                 string address = (string)reader["Address"];



                 Console.WriteLine($"├ID:{id} ┤ \t ├Name: {name}┤ \t ├Dep No: {depno}┤ \t ├Address: {address}┤");

             } */
            #endregion
            //sqlConnection.Close();
            #endregion


            #region Disconnected Mode 
           /* sqlCommand.CommandText = "Select * from Employee";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach(DataRow row in  dataTable.Rows)
            {
                int id = (int)row["SSN"];
                string name = (string)row["Fname"]+" "+(string)row["Lname"];

                Console.WriteLine($"├ Name : {name} ┤\t├ SSN : {id} ┤");
            }*/




            #endregion

            Console.ReadKey();
        }
    }
} 