using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class UserLogin : IdentityUserLogin<int>
{
    public User User { get; set; }
}
