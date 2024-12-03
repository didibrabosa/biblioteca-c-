namespace Biblioteca.Entidades
{ 
    public class Livro
    {
        public int Id {get; set;} 
        public string Titulo {get; set;} = string.Empty;
        public string Genero {get; set;} = string.Empty;
        public string Autor {get; set;} = string.Empty;
        public int NumeroDePaginas {get; set;} = int.MaxValue;
        public int AnoPublicacao {get; set;} = int.MaxValue;

        public Livro(int id, string titulo, string genero, string autor, int numeroDePaginas, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Autor = autor;
            NumeroDePaginas = numeroDePaginas;
            AnoPublicacao = anoPublicacao;
        }
    }
}