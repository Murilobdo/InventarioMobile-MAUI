

using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contracts
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Email, "Email", "O campo email é obrigatório")
                .IsEmail(request.Email, "Email", "O campo email deve ser um email válido")
                .IsNotNullOrEmpty(request.Senha, "Senha", "O campo senha é obrigatório");
        }
    }
}
