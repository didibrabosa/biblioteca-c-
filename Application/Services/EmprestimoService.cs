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

    public async Task<Emprestimo> AdicionarEmprestimo(Emprestimo emprestimo)
    {
        var usuario = await _usuarioRepository.BuscarUsuario(emprestimo.UsuarioId);
        if (usuario == null)
            throw new ArgumentException("Usuário não encontrado.");

        var inventario = await _inventarioRepository.BuscarInventario(emprestimo.InventarioId);
        if (inventario == null)
            throw new ArgumentException("Livro não encontrado no Inventário.");

        if (inventario.Quantidade <= 0)
            throw new InvalidOperationException("Não há livros disponíveis para empréstimo.");
        
        emprestimo.Status = "Pendente";
        emprestimo.DataEmprestimo = DateTime.Now;

        inventario.Quantidade -= 1;
        inventario.Disponibilidade = inventario.Quantidade > 0;
        await _inventarioRepository.AtualizarInventario(inventario);

        return await _emprestimoRepository.AdicionarEmprestimo(emprestimo);
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

        var sucesso = await _emprestimoRepository.DeletarEmprestimo(id);

        if (sucesso)
        {
            var inventario = await _inventarioRepository.BuscarInventario(emprestimo.InventarioId);
            if(inventario != null)
            {
                inventario.Quantidade += 1;
                await _inventarioRepository.AtualizarInventario(inventario);
            }
        }

        return sucesso;
    } 
}