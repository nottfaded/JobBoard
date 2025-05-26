using System.Security.Claims;

namespace JobBoard.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetAccountId(this ClaimsPrincipal user)
    {
        var idStr = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(idStr, out var id))
            throw new UnauthorizedAccessException($"Invalid or missing account ID[{idStr}] claim");

        return id;
    }
}