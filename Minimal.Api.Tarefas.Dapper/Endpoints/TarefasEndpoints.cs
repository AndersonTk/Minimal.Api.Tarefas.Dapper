using AuthService.Client.Extensions;
using Dapper.Contrib.Extensions;
using Minimal.Api.Tarefas.Dapper.Models;
using System;
using static Minimal.Api.Tarefas.Dapper.Data.TarefaContext;

namespace Minimal.Api.Tarefas.Dapper.Endpoints;

public static class TarefasEndpoints
{
    public static void MapTarefasEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => $"Bem vindo a API de Tarefas {DateTime.Now}").RequirePermission("owner");

        app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var tarefas = con.GetAll<Tarefa>().ToList();

            if (tarefas is null)
                return Results.NoContent();

            return Results.Ok(tarefas);
        }).RequirePermission("view");

        app.MapGet("/tarefas/{id}", async (int id, GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();

            return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound("Tarefa não encontrada"); ;
        }).RequirePermission("view");

        app.MapPost("/tarefas", async (Tarefa tarefa, GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var id = con.Insert(tarefa);

            return Results.Created($"/tarefas/{id}", tarefa);
        }).RequirePermission("create");

        app.MapPut("/tarefas", async (Tarefa tarefa, GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var id = con.Update(tarefa);

            return Results.Ok();
        }).RequirePermission("update");

        app.MapDelete("/tarefas/{id}", async (int id, GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var tarefa = con.Get<Tarefa>(id);

            if (tarefa is null)
                return Results.NotFound("Tarefa não encontrada");

            con.Delete<Tarefa>(tarefa);

            return Results.Ok(tarefa);
        }).RequirePermission("delete");
    }
}