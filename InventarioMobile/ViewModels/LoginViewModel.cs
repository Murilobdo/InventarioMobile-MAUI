
using InventarioMobile.Contracts;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositories.Login;
using System.Text;
using InventarioMobile.Helpers;
using Flurl;
using Flurl.Http;

namespace InventarioMobile.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(ILoginRepository repository)
        {
            _repository = repository;
        }
        
        [ObservableProperty]
        string email = "";

        [ObservableProperty]
        string senha = "";

        private readonly ILoginRepository _repository;

        [RelayCommand]
        public async Task LoginAsync()
        {
            var request = new LoginRequest(Email, Senha);
            var contract = new LoginContract(request);

            if(!contract.IsValid)
            {
                var sb = new StringBuilder();
                contract.Notifications
                    .ToList()
                    .ForEach(x => sb.Append(x.Message + "\n"));

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            }
            else
            {
                var response = Constants.ApiUrl
                    .AppendPathSegment("/users/login")
                    .PutJsonAsync(request);
            }
        }
    }
}
