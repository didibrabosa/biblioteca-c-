using Microsoft.EntityFrameworkCore;
using InventarioLivros.Models;

namespace InventarioLivros.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}