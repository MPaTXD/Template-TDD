using System.Threading.Tasks;
using Template.API.Application.Services.v1;
using Template.API.Application.ViewModel.v1;

namespace Template.API.Application.Interfaces.v1
{
    public interface IUserService
    {
        Task<AuthResponse> Authenticate(LoginViewModel login);
    }
}
