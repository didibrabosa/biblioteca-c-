using System.Collections.Generic;
using InventarioLivros.Models;

namespace InventarioLivros.Repositories
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> GetLivros();
        Livro? GetLivroById(int id);
        void AddLivro(Livro livro);
        void UpdateLivro(Livro livro);
        void DeleteLivro(int id);
    }   
}