using System.Collections.Generic;
using System.Linq;
using InventarioLivros.Models;
using InventarioLivros.Data;

namespace InventarioLivros.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly InventarioContext _context;

        public LivroRepository(InventarioContext context)
        {
            _context = context;
        }

        public IEnumerable<Livro> GetLivros() => _context.Livros.ToList();

        public Livro? GetLivroById(int id) => _context.Livros.Find(id);

        public void AddLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void UpdateLivro(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }

        public void DeleteLivro(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }
        }

        
    }
}