using Biblioteca.Entidades;

public interface ICatalogoRepository
{
    Task<Catalogo> AdicionarCatalogo(Catalogo catalogo);
    Task<Catalogo> BuscarCatalogo(int id);
    Task<IEnumerable<Catalogo>> BuscarTodosCatalogos();
    Task<Catalogo> AtualizarCatalogo(Catalogo catalogo);
    Task<bool> DeletarCatalogo(int id);
}