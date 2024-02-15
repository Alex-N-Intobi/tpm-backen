using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.RestAPI.Extensions;

namespace TranslationProjectManagement.RestAPI;

public class HttpIdentityService : IIdentityManager
{
    private const string ACCESS_TOKEN_KEY = "access_token";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpIdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentApplicationUserId()
    {
        return _httpContextAccessor.GetCurrentApplicationUserId();
    }

    public IEnumerable<Claim> GetCurrentApplicationUserClaims()
    {
        return _httpContextAccessor.GetCurrentApplicationUserClaims();
    }

    public string GetCurrentApplicationUserEmail()
    {
        return _httpContextAccessor.GetCurrentApplicationUserEmail();
    }

    public async Task<string> GetCurrentApplicationUserAccessToken()
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            return default;
        }

        return await _httpContextAccessor.HttpContext.GetTokenAsync(ACCESS_TOKEN_KEY);
    }
}
