namespace Biblioteca.Entidades
{
    public class Emprestimo
    {
        public int Id {get; set;} 
        public int InventarioId {get; set;} 
        public int UsuarioId {get; set;}
        public DateTime DataEmprestimo {get; set;} = DateTime.MinValue;
        public DateTime DataDevolucao {get; set;} = DateTime.MinValue;
        public string Status {get; set;} = string.Empty;
        
        public Emprestimo() {}

        public Emprestimo(int id, int inventarioId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao, string status)
        {
            Id = id;
            InventarioId = inventarioId;
            UsuarioId = usuarioId;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Status = status;
        }
    }
}