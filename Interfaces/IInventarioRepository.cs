using Biblioteca.Entidades;

public interface IInventarioRepository
{
    Task<Inventario> AdicionarInventario(Inventario inventario);
    Task<Inventario> BuscarInventario(int id);
    Task<Inventario> AtualizarInventario(Inventario inventario);
    Task<bool> DeletarInventario(int id);
}