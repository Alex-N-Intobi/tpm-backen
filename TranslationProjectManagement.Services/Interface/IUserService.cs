using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Services.Base.Interfaces;
using TranslationProjectManagement.Services.Dtos.Requests;
using TranslationProjectManagement.Services.Dtos.Responses;

namespace TranslationProjectManagement.Services.Interface;

public interface IUserService : IServiceBase
{
    Task<User> GetCurrentUser(CancellationToken cancellationToken = default);
    Task<TokenResponse> LoginAsync(LoginRequest model, CancellationToken cancellationToken = default);
}
