using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Minimal.Api.Tarefas.Dapper.Extentions.Authorization;

public class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public const string PolicyPrefix = "tarefas:";

    public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        : base(options) { }

    public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase))
        {
            var permission = policyName.Substring(PolicyPrefix.Length);

            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new PermissionRequirement(permission))
                .Build();

            return Task.FromResult<AuthorizationPolicy?>(policy);
        }

        return base.GetPolicyAsync(policyName);
    }
}
