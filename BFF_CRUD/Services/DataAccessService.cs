using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BFF_CRUD.Services
{
    public class DataAccessService
    {
        private static string connectionString = @"Data Source=DESKTOP-NUEI16L\SQDSC001;" +
            "Initial Catalog=DB001;" +
            "User ID=admin;" +
            "Password=123;";

        public static string performQuery(string statement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(statement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return JsonConvert.SerializeObject(dataTable);
                }
                catch (Exception ex)
                {
                    return "Falha na execução: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public static string performNonQuery(string statement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(statement, connection);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return "O comando foi executado com sucesso. " + rowsAffected.ToString() + " registros afetados.";
                }
                catch (Exception ex)
                {
                    return "Falha na execução: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
