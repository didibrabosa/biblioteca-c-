public class Livro
{
    public int Id {get; set;} 
    public string Titulo {get; set;} = string.Empty;
    public string Genero {get; set;} = string.Empty;
    public string Autor {get; set;} = string.Empty;
    public int NumeroDePaginas {get; set;}
    public int AnoPublicacao {get; set;}

    public Livro(int id, string titulo, string genero, string autor, int numeroDePaginas, int anoPublicacao)
    {
        Id = id;
        Titulo = titulo;
        Genero = genero;
        Autor = autor;
        NumeroDePaginas = numeroDePaginas;
        AnoPublicacao = anoPublicacao;
    }
}

public class Usuario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public int Idade {get; set;} = int.MaxValue;
    public DateTime DataDeNascimento {get; set;} = DateTime.MinValue;
    public int Cpf {get; set;} = int.MaxValue;
    public int NumeroDeTelefone {get; set;} = int.MaxValue;
    public string Email {get; set;} = string.Empty;

    public Usuario(int id, string nome, int idade, DateTime dataDeNascimento, int cpf, int numeroDeTelefone, string email)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        DataDeNascimento = dataDeNascimento;
        Cpf = cpf;
        NumeroDeTelefone = numeroDeTelefone;
        Email = email;
    }
}

public class Emprestimo
{
    public int Id {get; set;} 
    public int LivroId {get; set;} 
    public int UsuarioId {get; set;}
    public DateTime DataDevolucao {get; set;} = DateTime.MinValue;

    public Emprestimo(int id, int livroId, int usuarioId, DateTime dataDevolucao)
    {
        Id = id;
        LivroId = livroId;
        UsuarioId = usuarioId;
        DataDevolucao = dataDevolucao;
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
    }
}
