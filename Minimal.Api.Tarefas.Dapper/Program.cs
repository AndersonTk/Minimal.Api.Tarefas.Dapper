using AuthService.Client.Extensions;
using Minimal.Api.Tarefas.Dapper.Endpoints;
using Minimal.Api.Tarefas.Dapper.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

builder.Services.AddAuthServiceAuthentication(builder.Configuration);

var app = builder.Build();

app.MapTarefasEndpoints();

app.UseAuthentication();
app.UseAuthorization();
app.Run();