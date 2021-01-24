using BFF_CRUD.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BFF_CRUD.Services
{
    public class DataAccessService
    {

        public static string performStatement(DynamicStatement dynSt, string verb, IConfiguration _configuration)
        {
            string dataSource = _configuration["DataAccess:" + dynSt.environment.ToLower() + ":data_source"];
            string userid = _configuration["DataAccess:" + dynSt.environment.ToLower() + ":user_id"];
            string password = _configuration["DataAccess:" + dynSt.environment.ToLower() + ":password"];
            string connectionString = $"Data Source={dataSource};Initial Catalog={dynSt.database};User ID={userid};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(dynSt.statement, connection);
                try
                {
                    connection.Open();
                    if (String.Equals(verb, "SELECT"))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        return JsonConvert.SerializeObject(dataTable);
                    }
                    else
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            return "O comando foi executado, mas nenhum registro foi afetado.";
                        else
                            return "O comando foi executado com sucesso. " + rowsAffected.ToString() + " registros afetados.";
                    }
                }
                catch (Exception ex)
                {
                    return "Falha na execução: " + ex.Message;
                }
            }
        }
    }
}
