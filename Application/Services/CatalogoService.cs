using Biblioteca.Entidades;

public class CatalogoService
{
    private readonly ICatalogoRepository _catalogoRepository;

    public CatalogoService(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }

    public async Task<Catalogo> AdicionarCatalogo(Catalogo catalogo)
        => catalogo != null ? await _catalogoRepository.AdicionarCatalogo(catalogo) : null;
    
    public async Task<Catalogo> BuscarCatalogo(int id)
        => id > 0 ? await _catalogoRepository.BuscarCatalogo(id) : null;

    public async Task<IEnumerable<Catalogo>> BuscarTodosCatalogos()
        => await _catalogoRepository.BuscarTodosCatalogos();

    public async Task<bool> DeletarCatalogo(int id)
        => id > 0 && await _catalogoRepository.DeletarCatalogo(id);

    public async Task AdicionarLivroCatalogo(int catalogoId, int livroId)
    {
        if (catalogoId > 0 && livroId > 0)
        {
            await _catalogoRepository.AdicionarLivroCatalogo(catalogoId, livroId);
        }
    }

    public async Task RemoverLivroCatalogo(int catalogoId, int livroId)
    {
        if (catalogoId > 0 && livroId > 0)
        {
            await _catalogoRepository.RemoverLivroCatalogo(catalogoId, livroId);
        }
    }
    
}