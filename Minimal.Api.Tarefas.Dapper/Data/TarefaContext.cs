using System.Data;

namespace Minimal.Api.Tarefas.Dapper.Data;

public class TarefaContext
{
    public delegate Task<IDbConnection> GetConnection();
}
