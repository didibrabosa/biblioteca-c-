using BibliotecaDefinitiva.Domain.Entities;
using BibliotecaDefinitiva.Domain.Interfaces;

namespace BibliotecaDefinitiva.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) => _repository = repository;

        public async Task<IEnumerable<User>> GetAllUsers() => await _repository.GetAllUsers();
        public async Task<IEnumerable<User>> GetUserById(int id) => (IEnumerable<User>)await _repository.GetUserById(id);
        public async Task<User> AddUser(User user) => await _repository.AddUser(user);
        public async Task UpdateUser(User user) => await _repository.UpdateUser(user);
        public async Task DeleteUser(int id) => await _repository.DeleteUser(id);
    }
}