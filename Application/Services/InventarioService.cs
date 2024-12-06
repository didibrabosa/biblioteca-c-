using Biblioteca.Entidades;

public class InventarioService
{
    private readonly IInventarioRepository _inventarioRepository;
    private readonly ILivroRepository _livroRepository;

    public InventarioService(IInventarioRepository inventarioRepository, ILivroRepository livroRepository)
    {
        _inventarioRepository = inventarioRepository;
        _livroRepository = livroRepository;
    }

    public async Task<Inventario> AdicionarInventario(Inventario inventario) 
    {
        var livro = await _livroRepository.BuscarLivro(inventario.LivroId);

        await ValidarLivro(inventario);
        
        ValidarInventario(inventario);
        await _inventarioRepository.AdicionarInventario(inventario);

        return inventario;
    }
    public async Task<Inventario> BuscarInventario(int livroId) 
    {
        if (livroId <= 0)
            throw new ArgumentException("O ID deve ser maior que zero.");

        var inventario = await _inventarioRepository.BuscarInventario(livroId);
        if (inventario == null)
            throw new KeyNotFoundException("Livro não encotrado.");

        return inventario;
    }

    public async Task<IEnumerable<Inventario>> BuscarTodosInventarios()
    {
        var inventarios = await _inventarioRepository.BuscarTodosInventarios();
        
        if (inventarios == null || !inventarios.Any())
        {
            throw new KeyNotFoundException("Nenhum Inventário encontrado.");
        }
        
        return inventarios;
    }

    public async Task<Inventario> AtualizarInventario(Inventario inventario) 
    {
        var livro = await _livroRepository.BuscarLivro(inventario.LivroId);

        await ValidarLivro(inventario);
        
        ValidarInventario(inventario);

        var inventarioAtualizado = await _inventarioRepository.AtualizarInventario(inventario);

        if (inventarioAtualizado == null)
        {
            throw new ArgumentException("Erro ao atualizar o invnetário.");
        }

        throw new ArgumentException("Inventário atualizado com sucesso!");
        
    }

    public async Task<bool> DeletarInventario(int id) 
        => await _inventarioRepository.DeletarInventario(id);

    private void ValidarInventario (Inventario inventario)
    {
        if (inventario.LivroId <= 0)
                throw new ArgumentException("Livro do Inventário não pode ser zero ou negativo.");

        if (inventario.Quantidade <= 0)
            throw new ArgumentException("Quantidade do Livro não pode ser zero ou negativa.");

        if (string.IsNullOrWhiteSpace(inventario.Estado))
            throw new ArgumentException("Estado do Livro não pode ser vazio.");
    }

    private async Task ValidarLivro(Inventario inventario)
    {
        var livro = await _livroRepository.BuscarLivro(inventario.LivroId);

        if(livro == null)
        {
            throw new KeyNotFoundException("O Livro não existe na tabela de Livros.");
        }
    }
}