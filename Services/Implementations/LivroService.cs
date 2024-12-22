using InventarioLivros.Models;
using InventarioLivros.Repositories;
using InventarioLivros.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace InventarioLivros.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IEnumerable<Livro> GetLivros()
        {
            return _livroRepository.GetLivros();
        }

        public Livro? GetLivroById(int id)
        {
            return _livroRepository.GetLivroById(id);
        }

        public void AddLivro(Livro livro)
        {
            _livroRepository.AddLivro(livro);
        }

        public void UpdateLivro(Livro livro)
        {
            _livroRepository.UpdateLivro(livro);
        }

        public void DeleteLivro(int id)
        {
            _livroRepository.DeleteLivro(id);
        }
    }
}
