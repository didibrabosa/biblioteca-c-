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

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título do livro não pode ser vazio.");
            
            if (string.IsNullOrWhiteSpace(genero))
                throw new ArgumentException("Gênero do livro não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor do livro não pode ser vazio.");

            if (numeroDePaginas <= 0)
                throw new ArgumentException("Número de páginas do livro não pode ser zero ou negativo.");

            if (anoPublicacao <= 0)
                throw new ArgumentException("Ano de publicação do livro não pode ser zero ou negativo.");
        }
    }
}