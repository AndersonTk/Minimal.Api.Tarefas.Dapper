using System.Data.SqlClient;
using static Minimal.Api.Tarefas.Dapper.Data.TarefaContext;

namespace Minimal.Api.Tarefas.Dapper.Extentions;

public static class ServiceCollectionExtentions
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DbConnection");

        builder.Services.AddScoped<GetConnection>(sp => 
        async () =>
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        });

        return builder;
    }
}
