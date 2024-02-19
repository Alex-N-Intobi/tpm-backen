using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Services.Dtos.Requests;
using TranslationProjectManagement.Services.Dtos.Responses;
using TranslationProjectManagement.Services.Interface;
using Microsoft.Extensions.Configuration;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.Services.Dtos;

namespace TranslationProjectManagement.Services;

public class UserService : IUserService
{
    public const string ApplicationUserIdClaimType = "ApplicationUserId";

    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IIdentityManager _identityManager;

    public UserService(UserManager<User> userManager, IConfiguration configuration, IIdentityManager identityManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _identityManager = identityManager;
    }

    public async Task<User> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        string userId = _identityManager.GetCurrentApplicationUserId().ToString();
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<IList<LookupFieldDto>> GetLookupFieldsAsync(string role, CancellationToken cancellationToken = default)
    {
        IList<User> users = await _userManager.GetUsersInRoleAsync(role);
        return users.Select(x => new LookupFieldDto() 
        {
            Id = x.Id,
            Name = x.FullName,
            Description = x.Email
        }).ToList();
    }

    public async Task<TokenResponse> LoginAsync(LoginRequest model, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(model);

        User? user = await _userManager.FindByNameAsync(model.Username);
        if (user is null)
        {
            throw new InvalidOperationException("Authorization failed.");
        }

        if (!await _userManager.CheckPasswordAsync(user, model.Password))
        {
            throw new InvalidOperationException("Authorization failed.");
        }

        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        List<Claim> authClaims =
        [
            new(ApplicationUserIdClaimType, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ];

        foreach (string userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        JwtSecurityToken token = GetToken(authClaims);

        return new TokenResponse()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:SecurityKey"]));

        JwtSecurityToken token = new(
            issuer: _configuration["Authentication:JwtBearer:Issuer"],
            audience: _configuration["Authentication:JwtBearer:Audience"],
            expires: DateTime.Now.AddHours(8),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
