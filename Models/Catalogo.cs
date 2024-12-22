namespace BibliotecaApp.Models
{
    public class Catalogo
    {
        public int Id {get; set;}
        public string? Titulo {get; set;}
        public string? Autor {get; set;}
        public int Ano {get; set;}
        public string? Genero {get; set;}
        public int Paginas {get; set;}
    }
}