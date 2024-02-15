using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class RoleClaim : IdentityRoleClaim<int>
{
    public Role Role { get; set; }
}
