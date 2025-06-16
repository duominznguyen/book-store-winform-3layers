using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbConnect
    {
        private readonly string _connectionString;

        public DbConnect()
        {
            _connectionString = @"Data Source=DUOMINZ\SQLEXPRESS;Initial Catalog=BookstoreDB_final;Integrated Security=True;TrustServerCertificate=True";
        }

        protected DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            //string query = "SELECT * FROM Books";
            //ExecuteQuery(query)

            return dataTable;
        }

        protected int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        protected object ExecuteScalar(string query)
        {
            object result = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }



    }
}