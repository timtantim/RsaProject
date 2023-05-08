using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RsaProject.Services
{
    public class TokenService : ITokenService
    {
        private DiscoveryDocumentResponse _discDocument { get; set; }
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            
            using (var client = new HttpClient()) {
                _discDocument = client.GetDiscoveryDocumentAsync(_configuration.GetValue<string>("IDServerHost") + "/.well-known/openid-configuration").Result;
            }
        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            using (var client = new HttpClient()) {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address=_discDocument.TokenEndpoint,
                    ClientId= "cwm.client",
                    Scope=scope,
                    ClientSecret="secret"
                });
                if (tokenResponse.IsError) {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }
        }
    }
}
