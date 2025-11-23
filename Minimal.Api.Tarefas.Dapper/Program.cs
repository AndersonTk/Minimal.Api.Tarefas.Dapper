using Microsoft.AspNetCore.Authorization;
using Minimal.Api.Tarefas.Dapper.Endpoints;
using Minimal.Api.Tarefas.Dapper.Extentions;
using Minimal.Api.Tarefas.Dapper.Extentions.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

builder.Services.AddAuthenticationJwt(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();

var app = builder.Build();

app.MapTarefasEndpoints();

app.UseAuthentication();
app.UseAuthorization();
app.Run();