using Microsoft.AspNetCore.Authorization;

namespace Minimal.Api.Tarefas.Dapper.Extentions.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }

    public PermissionRequirement(string permission) => Permission = permission;
}
