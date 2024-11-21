public class Livro
{
    public int Id {get; set;} 
    public string Titulo {get; set;} = string.Empty;
    public string Genero {get; set;} = string.Empty;
    public string Autor {get; set;} = string.Empty;
    public int NumeroDePaginas {get; set;}
    public int AnoPublicacao {get; set;}
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

}

public class Emprestimo
{
    public int Id {get; set;} 
    public int LivroId {get; set;} 
    public int UsuarioId {get; set;}
    public DateTime DataDevolucao {get; set;} = DateTime.MinValue;
}

public class Inventario
{
    public int Id {get; set;} 
    public int LivroId {get; set;}
    public int Quantidade {get; set;} = int.MaxValue;
    public string Estado {get; set;} = string.Empty;
}

public class Catalogo 
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public int LivroId {get; set;}
    public string Genero {get; set;} = string.Empty;

}
