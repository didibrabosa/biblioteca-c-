using System.ComponentModel.DataAnnotations;

namespace InventarioLivros.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public required string Editora { get; set; }
    }
}