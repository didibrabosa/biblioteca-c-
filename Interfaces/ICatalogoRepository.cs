using Biblioteca.Entidades;

public interface ICatalogoRepository
{
    Task<Catalogo> AdicionarCatalogo(Catalogo catalogo, int livroId);
    Task<Catalogo> BuscarCatalogo(int id);
    Task<IEnumerable<Catalogo>> BuscarTodosCatalogos();
    Task<Catalogo> AtualizarCatalogo(Catalogo catalogo);
    Task<bool> DeletarCatalogo(int id);
    Task AdicionarLivroCatalogo(int catalogoId, int livroId);
    Task<bool> RemoverLivroCatalogo(int catalogoId, int livroId);
}