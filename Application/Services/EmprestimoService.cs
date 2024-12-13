using Biblioteca.Entidades;

public class EmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IInventarioRepository _inventarioRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public EmprestimoService(IEmprestimoRepository emprestimoRepository,IInventarioRepository inventarioRepository,IUsuarioRepository usuarioRepository)
    {
        _emprestimoRepository = emprestimoRepository;
        _inventarioRepository = inventarioRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Emprestimo> CriarEmprestimo(Emprestimo emprestimo)
    {
        var inventario = await _inventarioRepository.BuscarInventario(emprestimo.InventarioId);
        if (inventario == null)
            throw new ArgumentException("Livro não encontrado no Inventário.");

        if (!inventario.Disponibilidade)
            throw new InvalidOperationException("O Livro não está disponível para Empréstimo.");

        var usuario = await _usuarioRepository.BuscarUsuario(emprestimo.UsuarioId);
        if (usuario == null)
            throw new ArgumentException("Usuário não encontrado.");

        emprestimo.Status = "Pendente";
        emprestimo.DataEmprestimo = DateTime.Now;
        var novoEmprestimo = await _emprestimoRepository.AdicionarEmprestimo(emprestimo);

        inventario.Quantidade -= 1;

        inventario.Disponibilidade = inventario.Quantidade > 0;
        await _inventarioRepository.AtualizarInventario(inventario);

        return novoEmprestimo;
    }

    public async Task<Emprestimo> BuscarEmprestimo(int id)
    {
        var emprestimo = await _emprestimoRepository.BuscarEmprestimo(id);
        if (emprestimo == null)
            throw new ArgumentException("Empréstimo não encontrado.");
        return emprestimo;
    }

    public async Task<IEnumerable<Emprestimo>> BuscarTodosEmprestimos()
    {
        return await _emprestimoRepository.BuscarTodosEmprestimos();
    }

    public async Task<Emprestimo> AtualizarEmprestimo(int id, string novoStatus)
    {
        var emprestimoExistente = await _emprestimoRepository.BuscarEmprestimo(id);
        if (emprestimoExistente == null)
            throw new ArgumentException("Empréstimo não encotrado.");

        if (string.IsNullOrWhiteSpace(novoStatus))
            throw new ArgumentException("O status do empréstimo não pode ser vazio.");

        emprestimoExistente.Status = novoStatus;

        var emprestimoAtualizado = await _emprestimoRepository.AtualizarEmprestimo(emprestimoExistente);

        return emprestimoAtualizado;
    }

    public async Task<bool> DeletarEmprestimo(int id)
    {
        var emprestimo = await _emprestimoRepository.BuscarEmprestimo(id);
        if (emprestimo == null)
            throw new ArgumentException("Empréstimo não encontrado.");

        return await _emprestimoRepository.DeletarEmprestimo(id);
    } 
}