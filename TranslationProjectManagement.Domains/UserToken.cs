using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class UserToken: IdentityUserToken<int>
{
    public User User { get; set; }
}
