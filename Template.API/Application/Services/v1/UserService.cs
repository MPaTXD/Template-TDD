using System.Threading.Tasks;
using Template.API.Application.Interfaces.v1;
using Template.API.Application.ViewModel.v1;
using Template.Domain.ModelAggregate.v1.UserAggregate;

namespace Template.API.Application.Services.v1
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthResponse> Authenticate(LoginViewModel login)
        {
            throw new System.NotImplementedException();
        }
    }
}
