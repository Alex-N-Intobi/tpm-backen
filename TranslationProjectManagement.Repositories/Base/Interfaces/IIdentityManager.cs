using System.Security.Claims;

namespace TranslationProjectManagement.Repositories.Base.Interfaces;

public interface IIdentityManager
{
    int GetCurrentApplicationUserId();

    IEnumerable<Claim> GetCurrentApplicationUserClaims();

    Task<string> GetCurrentApplicationUserAccessToken();

    string GetCurrentApplicationUserEmail();
}
