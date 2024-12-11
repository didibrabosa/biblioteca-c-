namespace Biblioteca.Entidades
{
    public class Catalogo 
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public string Genero {get; set;} = string.Empty;
        public List<Livro> Livros {get; set;}

        public Catalogo() {}

        public Catalogo(int id, string nome, string genero)
        {
            Id = id;
            Nome = nome;
            Genero = genero;
            Livros = new List<Livro>();
        }
    }
}    