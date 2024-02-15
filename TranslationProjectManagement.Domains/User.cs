using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class User: IdentityUser<int>
{
    public string FullName { get; set; }

    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserRole> Roles { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
}
