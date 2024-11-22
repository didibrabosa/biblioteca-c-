using System.Text.RegularExpressions;

public class Livro
{
    public int Id {get; set;} 
    public string Titulo {get; set;} = string.Empty;
    public string Genero {get; set;} = string.Empty;
    public string Autor {get; set;} = string.Empty;
    public int NumeroDePaginas {get; set;} = int.MaxValue;
    public int AnoPublicacao {get; set;} = int.MaxValue;

    public Livro(int id, string titulo, string genero, string autor, int numeroDePaginas, int anoPublicacao)
    {
        Id = id;
        Titulo = titulo;
        Genero = genero;
        Autor = autor;
        NumeroDePaginas = numeroDePaginas;
        AnoPublicacao = anoPublicacao;

        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título do livro não pode ser vazio.");
        
        if (string.IsNullOrWhiteSpace(genero))
            throw new ArgumentException("Gênero do livro não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(autor))
            throw new ArgumentException("Autor do livro não pode ser vazio.");

        if (numeroDePaginas <= 0)
            throw new ArgumentException("Número de páginas do livro não pode ser zero ou negativo.");

        if (anoPublicacao <= 0)
            throw new ArgumentException("Ano de publicação do livro não pode ser zero ou negativo.");
    }
}

public class Usuario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public int Idade {get; set;} = int.MaxValue;
    public DateTime DataDeNascimento {get; set;} = DateTime.MinValue;
    public string Cpf {get; set;} = string.Empty;
    public string NumeroDeTelefone {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;

    public Usuario(int id, string nome, int idade, DateTime dataDeNascimento, string cpf, string numeroDeTelefone, string email)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        DataDeNascimento = dataDeNascimento;
        Cpf = cpf;
        NumeroDeTelefone = numeroDeTelefone;
        Email = email;

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do usuário não pode ser vazio.");
        
        if (idade <= 0)
            throw new ArgumentException("Idade do usuário não pode ser zero ou negativa.");

        if (dataDeNascimento == DateTime.MinValue)
            throw new ArgumentException("Data de nascimento do usuário não pode ser vazia.");

        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF do usuário não pode ser vazio.");
        
        if (string.IsNullOrWhiteSpace(numeroDeTelefone))
            throw new ArgumentException("Número de telefone do usuário não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email do usuário não pode ser vazio.");     
    }
}

public class Emprestimo
{
    public int Id {get; set;} 
    public int LivroId {get; set;} 
    public int UsuarioId {get; set;}
    public DateTime DataEmprestimo {get; set;} = DateTime.MinValue;
    public DateTime DataDevolucao {get; set;} = DateTime.MinValue;
    public string Status {get; set;} = string.Empty;
    

    public Emprestimo(int id, int livroId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao, string status)
    {
        Id = id;
        LivroId = livroId;
        UsuarioId = usuarioId;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
        Status = status;

        if (livroId <= 0)
            throw new ArgumentException("Livro do empréstimo não pode ser zero ou negativo.");

        if (usuarioId <= 0)
            throw new ArgumentException("Usuário do empréstimo não pode ser zero ou negativo.");

        if (dataEmprestimo == DateTime.MinValue)
            throw new ArgumentException("Data de empréstimo do empréstimo não pode ser vazia.");

        if (dataDevolucao == DateTime.MinValue)
            throw new ArgumentException("Data de devolução do empréstimo não pode ser vazia.");
        

        if (DataDevolucao < DateTime.Now)
            throw new ArgumentException("Data de devolução do empréstimo não pode ser anterior à data de hoje.");
    }
}

public class Inventario
{
    public int Id {get; set;} 
    public int LivroId {get; set;}
    public int Quantidade {get; set;} = int.MaxValue;
    public string Estado {get; set;} = string.Empty;

    public Inventario(int id, int livroId, int quantidade, string estado)
    {
        Id = id;
        LivroId = livroId;
        Quantidade = quantidade;
        Estado = estado;

        if (livroId <= 0)
            throw new ArgumentException("Livro do inventário não pode ser zero ou negativo.");

        if (quantidade <= 0)
            throw new ArgumentException("Quantidade do inventário não pode ser zero ou negativa.");

        if (string.IsNullOrWhiteSpace(estado))
            throw new ArgumentException("Estado do inventário não pode ser vazio.");     
    }
}

public class Catalogo 
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public int LivroId {get; set;}
    public string Genero {get; set;} = string.Empty;

    public Catalogo(int id, string nome, int livroId, string genero)
    {
        Id = id;
        Nome = nome;
        LivroId = livroId;
        Genero = genero;

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do catálogo não pode ser vazio.");

        if (livroId <= 0)
            throw new ArgumentException("Livro do catálogo não pode ser zero ou negativo.");

        if (string.IsNullOrWhiteSpace(genero))
            throw new ArgumentException("Gênero do catálogo não pode ser vazio.");
    }
}
