using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;
using InventarioMobile.Repositories.Login;
using InventarioMobile.Helpers;
using Flurl;
using Flurl.Http;
using System.Net.Http.Headers;

namespace InventarioMobile.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {

            var response = await Constants.ApiUrl
                .AppendPathSegment("/users/login")
                .PutJsonAsync(request);

            if(response.ResponseMessage.IsSuccessStatusCode)
            {
                var jsonResponse = await response.ResponseMessage.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<LoginResponse>(jsonResponse);
            }

            return new LoginResponse(string.Empty);
        }
    }
}
