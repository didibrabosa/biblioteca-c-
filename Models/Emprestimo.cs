public class Emprestimo
{
    public int Id {get; set;} 
    public int LivroId {get; set;} 
    public int UsuarioId {get; set;}
    public DateTime DataEmprestimo {get; set;} = DateTime.MinValue;
    public DateTime DataDevolucao {get; set;} = DateTime.MinValue;
    public string Status {get; set;} = string.Empty;
    

    public Emprestimo(int id, int livroId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao, string status)
    {
        Id = id;
        LivroId = livroId;
        UsuarioId = usuarioId;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
        Status = status;

        if (livroId <= 0)
            throw new ArgumentException("Livro do empréstimo não pode ser zero ou negativo.");

        if (usuarioId <= 0)
            throw new ArgumentException("Usuário do empréstimo não pode ser zero ou negativo.");

        if (dataEmprestimo == DateTime.MinValue)
            throw new ArgumentException("Data de empréstimo do empréstimo não pode ser vazia.");

        if (dataDevolucao == DateTime.MinValue)
            throw new ArgumentException("Data de devolução do empréstimo não pode ser vazia.");
        
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Status do empréstimo não pode ser vazio.");
    }
}
