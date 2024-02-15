using System.Security.Claims;

namespace TranslationProjectManagement.RestAPI.Extensions;

public static class IHttpContextAccessorExtensions
{
    public const string ApplicationUserIdClaimType = "ApplicationUserId";

    public static int GetCurrentApplicationUserId(this IHttpContextAccessor httpContextAccessor)
    {
        _ = int.TryParse(httpContextAccessor.HttpContext?.User?.Claims?
            .FirstOrDefault(c => c.Type == ApplicationUserIdClaimType)?.Value, out int applicationUserId);

        return applicationUserId;
    }

    public static string GetCurrentApplicationUserNameIdentifier(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }

    public static string GetCurrentApplicationUserFullName(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
    }

    public static string GetCurrentApplicationUserEmail(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    }

    public static string GetCurrentApplicationUserClaimByType(this IHttpContextAccessor httpContextAccessor, string type)
    {
        type = type ?? throw new ArgumentNullException(nameof(type));

        return httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
    }

    public static IEnumerable<Claim> GetCurrentApplicationUserClaims(this IHttpContextAccessor httpContextAccessor)
    {
        httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        return httpContextAccessor.HttpContext?.User?.Claims;
    }

    public static string GetBaseUrl(this IHttpContextAccessor httpContextAccessor)
    {
        HttpContext httpContext = httpContextAccessor.HttpContext;
        return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.PathBase}";
    }
}
