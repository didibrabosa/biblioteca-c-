using System.Collections.Generic;
using InventarioLivros.Models;

namespace InventarioLivros.Services.Interfaces
{
    public interface ILivroService
    {
        IEnumerable<Livro> GetLivros();
        Livro? GetLivroById(int id);
        void AddLivro(Livro livro);
        void UpdateLivro(Livro livro);
        void DeleteLivro(int id);
    }

}
