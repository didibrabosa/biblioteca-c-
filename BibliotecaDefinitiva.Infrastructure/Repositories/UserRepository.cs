using BibliotecaDefinitiva.Domain.Entities;
using BibliotecaDefinitiva.Domain.Interfaces;
using BibliotecaDefinitiva.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaDefinitiva.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<User>> GetAllUsers() 
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
            
            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            return user;
        }

        public async Task<User> AddUser(User user)
        {
            var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == user.Email || u.Email == user.Email);

            if (existingUser!= null)
            {
                return existingUser;
            }
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user), "O Usuário não pode ser nulo.");
            }

            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }
    }
}
