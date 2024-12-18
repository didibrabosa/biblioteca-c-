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
        ValidarEmprestimo(emprestimo);

        if (emprestimo.DataDevolucao == default)
            throw new ArgumentException("A data de devolução é obrigatória e deve ser válida.");

        var usuario = await ValidarUsuario(emprestimo.UsuarioId);
        await LimiteEmprestimo(usuario.Id);

        var inventario = await ValidarInventario(emprestimo.InventarioId);
        DisponibilidadeLivro(inventario);

        emprestimo.Status = "Pendente";
        emprestimo.DataEmprestimo = DateTime.Now;

        inventario.Quantidade -= 1;
        inventario.Disponibilidade = inventario.Quantidade > 0;

        await _inventarioRepository.AtualizarInventario(inventario);

        return await _emprestimoRepository.AdicionarEmprestimo(emprestimo);
    }

    public async Task<Emprestimo> BuscarEmprestimo(int id)
    {
         if (id <= 0)
            throw new ArgumentException("O ID deve ser maior que zero.");
        
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
            throw new ArgumentException("Empréstimo não encontrado.");

        if (string.IsNullOrWhiteSpace(novoStatus))
            throw new ArgumentException("O status de empréstimo não pode ser vazio.");

        emprestimoExistente.Status = novoStatus;

        var emprestimoAtualizado = await _emprestimoRepository.AtualizarEmprestimo(emprestimoExistente);

        return emprestimoAtualizado;
    }

    public async Task<bool> DeletarEmprestimo(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID deve ser maior que zero.");
        
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

    private async Task<Usuario> ValidarUsuario(int usuarioId)
    {
        var usuario = await _usuarioRepository.BuscarUsuario(usuarioId);
        if (usuario == null)
            throw new KeyNotFoundException("Usuário não encontrado.");
        return usuario;
    }

    private async Task<Inventario> ValidarInventario(int inventarioId)
    {
        var inventario = await _inventarioRepository.BuscarInventario(inventarioId);
        if (inventario == null)
            throw new KeyNotFoundException("Livro não encontrado no Inventário.");
        return inventario;
    }

    private async Task LimiteEmprestimo(int usuarioId)
    {
        var emprestimos = await _emprestimoRepository.BuscarTodosEmprestimos();
        var emprestimosAtivos = emprestimos
            .Count(e => e.UsuarioId == usuarioId && e.Status == "Pendente");

        if (emprestimosAtivos >= 3)
            throw new InvalidOperationException("O usuário já atingiu o limite máximo de 3 empréstimos.");
    }

    private void DisponibilidadeLivro(Inventario inventario)
    {
        if (inventario.Quantidade <= 0)
            throw new InvalidOperationException("Não há livros disponíveis para empréstimo.");
    }

    private void ValidarEmprestimo(Emprestimo emprestimo)
    {
        if (emprestimo == null)
            throw new ArgumentException("Os dados do empréstimo são inválidos.");

        if (emprestimo.UsuarioId <= 0)
            throw new ArgumentException("ID do usuário inválido.");

        if (emprestimo.InventarioId <= 0)
            throw new ArgumentException("ID do inventário inválido.");
    }


}
