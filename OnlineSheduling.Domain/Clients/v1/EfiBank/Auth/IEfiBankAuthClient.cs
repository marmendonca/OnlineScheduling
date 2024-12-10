using System.Threading.Tasks;
using Refit;

namespace OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;

public interface IEfiBankAuthClient
{
    [Post("/oauth/token")]
    Task<LoginResponse> LoginAsync([Body] LoginRequest request);
}