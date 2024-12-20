using Biblioteca.Entidades;

public class CatalogoService
{
    private readonly ICatalogoRepository _catalogoRepository;
    private readonly ILivroRepository _livroRepository;

    public CatalogoService(ICatalogoRepository catalogoRepository, ILivroRepository livroRepository)
    {
        _catalogoRepository = catalogoRepository;
        _livroRepository = livroRepository;
    }

    public async Task<Catalogo> AdicionarCatalogo(Catalogo catalogo)
    {
        ValidarCatalogo(catalogo);

        return await _catalogoRepository.AdicionarCatalogo(catalogo);
    }
    
    public async Task<Catalogo> BuscarCatalogo(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID do Catálogo deve ser maior que zero.");

        var catalogo = await _catalogoRepository.BuscarCatalogo(id);
        if (catalogo == null)
            throw new KeyNotFoundException("Catálogo não encontrado.");

        return catalogo;
    }

    public async Task<IEnumerable<Catalogo>> BuscarTodosCatalogos()
    {
        var catalogos = await _catalogoRepository.BuscarTodosCatalogos();

        if (catalogos == null || !catalogos.Any())
            throw new KeyNotFoundException("Nenhum Catálogo encontrado.");

        return catalogos;
    }

    public async Task<Catalogo> AtualizarCatalogo(Catalogo catalogo)
    {
        ValidarCatalogo(catalogo);

        var catalogoAtualizado = await _catalogoRepository.AtualizarCatalogo(catalogo);

        if (catalogoAtualizado == null)
            throw new ArgumentException("Erro ao atualizar o catálogo.");

        return catalogoAtualizado;
    }

    public async Task<bool> DeletarCatalogo(int id)
    {    
        if (id <= 0)
            throw new ArgumentException("O ID do Catálogo deve ser maior que zero.");

        return await _catalogoRepository.DeletarCatalogo(id);
    }
    public async Task AdicionarLivroCatalogo(int catalogoId, int livroId)
    {
        if (catalogoId <= 0 || livroId <= 0)
            throw new ArgumentException("Os IDs de catálogo e livro devem ser maiores que zero.");

        await ValidarLivro(livroId);
        
        await _catalogoRepository.AdicionarLivroCatalogo(catalogoId, livroId);
        
    }

    public async Task RemoverLivroCatalogo(int catalogoId, int livroId)
    {
        if (catalogoId <= 0 || livroId <= 0)
            throw new ArgumentException("Os IDs de catálogo e livro devem ser maiores que zero.");

        await ValidarLivro(livroId);

        await _catalogoRepository.RemoverLivroCatalogo(catalogoId, livroId);
        
    }

    private async Task ValidarLivro (int livroId)
    {
        var livro = await _livroRepository.BuscarLivro(livroId);
        if (livro == null)
            throw new KeyNotFoundException("Livro não encontrado.");
    }

    public void ValidarCatalogo(Catalogo catalogo)
    {
        if (string.IsNullOrWhiteSpace(catalogo.Nome))
        {
            throw new ArgumentException("O nome do catálogo não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(catalogo.Genero))
        {
            throw new ArgumentException("O genêro do catálogo não pode ser vazio.");
        }
    }
    
}