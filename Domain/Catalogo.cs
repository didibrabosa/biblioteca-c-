namespace Biblioteca.Entidades
{
    public class Catalogo 
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public string Genero {get; set;} = string.Empty;
        public List<Livro> Livros {get; set;}

        public Catalogo(int id, string nome, string genero)
        {
            Id = id;
            Nome = nome;
            Genero = genero;
            Livros = new List<Livro>();

            // if (string.IsNullOrWhiteSpace(nome))
            //     throw new ArgumentException("Nome do catálogo não pode ser vazio.");

            // if (livroId <= 0)
            //     throw new ArgumentException("Livro do catálogo não pode ser zero ou negativo.");

            // if (string.IsNullOrWhiteSpace(genero))
            //     throw new ArgumentException("Gênero do catálogo não pode ser vazio.");
        }
    }
}    