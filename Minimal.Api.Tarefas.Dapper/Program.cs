using Minimal.Api.Tarefas.Dapper.Endpoints;
using Minimal.Api.Tarefas.Dapper.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

var app = builder.Build();

app.MapTarefasEndpoints();

app.Run();