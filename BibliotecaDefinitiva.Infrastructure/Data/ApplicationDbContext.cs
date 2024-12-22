using Microsoft.EntityFrameworkCore;
using BibliotecaDefinitiva.Domain.Entities;

namespace BibliotecaDefinitiva.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; } = null!;
        
    }
}