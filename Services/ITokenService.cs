using IdentityModel.Client;
using System.Threading.Tasks;

namespace RsaProject.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
