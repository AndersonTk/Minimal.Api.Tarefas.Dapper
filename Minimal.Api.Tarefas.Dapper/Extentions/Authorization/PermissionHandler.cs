using Microsoft.AspNetCore.Authorization;

namespace Minimal.Api.Tarefas.Dapper.Extentions.Authorization;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement
    )
    {
        if (!context.User.Identity?.IsAuthenticated ?? true)
            return Task.CompletedTask;

        var userPerms = context
            .User.FindAll("perm")
            .Select(c => c.Value)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (userPerms.Contains("owner") || userPerms.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
