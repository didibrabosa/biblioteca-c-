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
        if (string.IsNullOrWhiteSpace(livro.Titulo))
            throw new ArgumentException("Título do livro não pode ser vazio.");
            
        if (string.IsNullOrWhiteSpace(livro.Genero))
            throw new ArgumentException("Gênero do livro não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(livro.Autor))
            throw new ArgumentException("Autor do livro não pode ser vazio.");

        if (livro.NumeroDePaginas <= 0)
            throw new ArgumentException("Número de páginas do livro não pode ser zero ou negativo.");

        if (livro.AnoPublicacao <= 0)
            throw new ArgumentException("Ano de publicação do livro não pode ser zero ou negativo.");

        return await _livroRepository.AdicionarLivro(livro);    
    }

    public async Task<Livro> BuscarLivro(int id) => await _livroRepository.BuscarLivro(id);

    public async Task<IEnumerable<Livro>> BuscarTodosLivros() => await _livroRepository.BuscarTodosLivros();

    public async Task<Livro> AtualizarLivro(Livro livro) => await _livroRepository.AtualizarLivro(livro);

    public async Task<bool> DeletarLivro(int id) => await _livroRepository.DeletarLivro(id);
}