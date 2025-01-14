using System.ComponentModel.DataAnnotations.Schema;

namespace Minimal.Api.Tarefas.Dapper.Models;

[Table("Tarefa")]
public record Tarefa(int Id, string Atividade, string Status);
