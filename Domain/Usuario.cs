using System.Text.RegularExpressions;

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

        private bool ValidarCpf (string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        }

        private bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$");
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

            /*  private bool ValidarEmail(string email) 
            {
            return Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            }*/
        }   
    }
}    