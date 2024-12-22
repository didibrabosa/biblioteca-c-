namespace BibliotecaApp.Models
{
    public class Emprestimo
    {
        public int IdInventario {get; set;}
        public int IdUsuario {get; set;}
        public DateTime DataEmprestimo {get; set;}
        public DateTime DataEstimadaDevolucao {get; set;}
        public DateTime? DataDevolucao {get; set;}
    }
}