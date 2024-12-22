namespace BibliotecaDefinitiva.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } 
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }   

}