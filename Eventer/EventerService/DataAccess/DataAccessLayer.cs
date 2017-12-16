using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EventerService.DataAccess
{
    public class DataAccessLayer
    {
        string connectionString = @"Data Source=MITKOPC;Initial Catalog=EventerDB;Persist Security Info=True;User ID=sa;password=123456";
            //ConfigurationManager.ConnectionStrings["EventerDB"].ConnectionString;

        public DataSet ExecuteDataSet(string procedureName)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return ds;
            }
        }

        public DataSet ExecuteDataSet(string procedureName, List<SqlParameter> parameters)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return ds;
            }
        }

        public int ExecuteNonQueryData(string procedureName, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(parameters.ToArray());

                int changedRows = command.ExecuteNonQuery();

                return changedRows;

            }
        }
    }
}