namespace BibliotecaApp.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Endereco {get; set;}
        public string Email {get; set;}
        public string Telefone {get; set;}
        public DateTime DataNascimento {get; set;}

         public Usuario()
        {
            Nome = string.Empty;
            Endereco = string.Empty;
            Email = string.Empty;
            Telefone = string.Empty;
        }
    }
}