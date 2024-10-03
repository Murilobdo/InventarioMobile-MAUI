
namespace InventarioMobile.Models.Response
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
