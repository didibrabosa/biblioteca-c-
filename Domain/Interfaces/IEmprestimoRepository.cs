public interface IEmprestimoRepository
{
    Task<Emprestimo> AdicionarEmprestimo(Emprestimo emprestimo);
    Task<Emprestimo> BuscarEmprestimo(int id);
    Task<IEnumerable<Emprestimo>> BuscarTodosEmprestimos();
    Task<Emprestimo> AtualizarEmprestimo(Emprestimo emprestimo);
    Task<bool> DeletarEmprestimo(int id);
}