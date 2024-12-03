using Biblioteca.Entidades;

public class LivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<Livro> AdicionarLivro(Livro livro)
    {
        ValidarLivro(livro);

        return await _livroRepository.AdicionarLivro(livro);    
    }

    public async Task<Livro> BuscarLivro(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID do livro deve ser maior que zero.");

        var livro = await _livroRepository.BuscarLivro(id);

        if (livro == null)
            throw new KeyNotFoundException($"Livro com o ID {id} não encontrado.");

        return livro;

    }

    public async Task<IEnumerable<Livro>> BuscarTodosLivros()
    {
        var livros = await _livroRepository.BuscarTodosLivros();

        if (livros == null || !livros.Any())
            throw new KeyNotFoundException("Nenhum livro encontrado.");

        return livros;
    }

    public async Task<Livro> AtualizarLivro(Livro livro)
    {
        ValidarLivro(livro, isUpdate: true);

        return await _livroRepository.AtualizarLivro(livro);
    }

    public async Task<bool> DeletarLivro(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID do livro deve ser maior que zero.");

        return await _livroRepository.DeletarLivro(id);
    }

    public void ValidarLivro(Livro livro, bool isUpdate = false)
    {
        if (livro == null)
            throw new ArgumentException("Livro não pode ser nulo.");
        
        if (!isUpdate && string.IsNullOrWhiteSpace(livro.Titulo))
            throw new ArgumentException("Título do livro não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(livro.Genero))
            throw new ArgumentException("Gênero do livro não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(livro.Autor))
            throw new ArgumentException("Autor do livro não pode ser vazio.");

        if (livro.NumeroDePaginas <= 0)
            throw new ArgumentException("Número de páginas do livro deve ser maior que zero.");

        if (livro.AnoPublicacao <= 0 || livro.AnoPublicacao > DateTime.Now.Year)
            throw new ArgumentException("Ano de publicação inválido.");

        if (livro.Titulo.Length > 255)
            throw new ArgumentException("Título do livro não pode ter mais que 255 caracteres.");
    }
}