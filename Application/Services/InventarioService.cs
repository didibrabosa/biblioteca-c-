using Biblioteca.Entidades;

public class InventarioService
{
    private readonly IInventarioRepository _inventarioRepository;

    public InventarioService(IInventarioRepository inventarioRepository)
    {
        _inventarioRepository = inventarioRepository;
    }

    public async Task<Inventario> AdicionarInventario(Inventario inventario) 
        => await _inventarioRepository.AdicionarInventario(inventario);

    public async Task<Inventario> BuscarInventario(int id) 
        => await _inventarioRepository.BuscarInventario(id);

    public async Task<IEnumerable<Inventario>> BuscarTodosInventarios()
        => await _inventarioRepository.BuscarTodosInventarios();

    public async Task<Inventario> AtualizarInventario(Inventario inventario) 
        => await _inventarioRepository.AtualizarInventario(inventario);

    public async Task<bool> DeletarInventario(int id) 
        => await _inventarioRepository.DeletarInventario(id);
}