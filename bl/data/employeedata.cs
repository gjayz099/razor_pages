using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace bl;

public class employeedata
{ 

    public static async Task<(string err, List<bl.employee> data)> GetAllDataAsync()
    {


        string connectionString = $"Server=DESKTOP-79JOQKV;Database=PracticeData;User=user01;Password=admin;Trusted_Connection=false;TrustServerCertificate=True;";

        List<bl.employee> ret = new List<bl.employee>();

        string sql = "Select * From Employee";

        string error = "";

        try
        {
            using(SqlConnection connection = new SqlConnection(connectionString)){
                await connection.OpenAsync();


                using(SqlCommand command = new SqlCommand(sql, connection))
                {

                   SqlDataReader reader =  await command.ExecuteReaderAsync();
              
                    while (await reader.ReadAsync())
                    {
                        ret.Add(new employee{ id = reader.GetGuid(0), name = reader.GetString(1), department = reader.GetString(2), salary = reader.GetString(3)});
                    }    
                };
                await connection.CloseAsync();
            }
          
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }

        return (error, ret);
    }
}
