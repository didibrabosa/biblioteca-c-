namespace Biblioteca.Entidades
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public int Idade {get; set;} = int.MaxValue;
        public DateTime DataDeNascimento {get; set;} = DateTime.MinValue;
        public string Cpf {get; set;} = string.Empty;
        public string Telefone {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;

        public Usuario() { }
        
        public Usuario(int id, string nome, int idade, DateTime dataDeNascimento, string cpf, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;     
        }
    }
}    