using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class UserClaim : IdentityUserClaim<int>
{
    public User User { get; set; }
}
