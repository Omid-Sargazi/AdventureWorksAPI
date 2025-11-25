using AuthDemoTwo.Models;

namespace AuthDemoTwo.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterModel model);
        Task<bool> ValidateUserAsync(LoginModel model);
        Task<bool> UserExistAsync(string email);
    }

    public class UserService : IUserService
    {
        private readonly List<RegisterModel> _users = new();
        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            _users.Add(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UserExistAsync(string email)
        {
            var user = _users.FirstOrDefault(u=>u.Email == email);
            return await Task.FromResult(user !=null);
        }

        public async Task<bool> ValidateUserAsync(LoginModel model)
        {
            var user = _users.FirstOrDefault(u=>u.Email == model.Email && u.Password==model.Password);
            return await Task.FromResult(user!=null);

        }
    }
}