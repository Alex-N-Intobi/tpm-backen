using Microsoft.AspNetCore.Identity;

namespace TranslationProjectManagement.Domains;

public class Role : IdentityRole<int>
{
    public ICollection<RoleClaim> Claims { get; set; }

    public ICollection<UserRole> Users { get; set; }
}
