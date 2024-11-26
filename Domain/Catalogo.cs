namespace Biblioteca.Entidades
{
    public class Catalogo 
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public int InventarioId {get; set;}
        public string Genero {get; set;} = string.Empty;

        public Catalogo(int id, string nome, int inventarioId, string genero)
        {
            Id = id;
            Nome = nome;
            InventarioId = inventarioId;
            Genero = genero;

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do catálogo não pode ser vazio.");

            if (inventarioId <= 0)
                throw new ArgumentException("Livro do catálogo não pode ser zero ou negativo.");

            if (string.IsNullOrWhiteSpace(genero))
                throw new ArgumentException("Gênero do catálogo não pode ser vazio.");
        }
    }
}    