using System.Data;
using Biblioteca.Entidades;
using MySql.Data.MySqlClient;

public class LivroRepository : ILivroRepository
{
    private readonly string _connectionString;

    public LivroRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Livro> AdicionarLivro(Livro livro)
    {
        const string query = @"
        INSERT INTO Livros (Titulo, Genero, Autor, NumeroDePaginas, AnoPublicacao)
        VALUES (@Titulo, @Genero, @Autor, @NumeroDePaginas, @AnoPublicacao);
        SELECT LAST_INSERT_ID()";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Titulo", livro.Titulo);
        command.Parameters.AddWithValue("@Genero", livro.Genero);
        command.Parameters.AddWithValue("@Autor", livro.Autor);
        command.Parameters.AddWithValue("@NumeroDePaginas", livro.NumeroDePaginas);
        command.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);

        await connection.OpenAsync();
        livro.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
        return livro;
    }

    public async Task<Livro> BuscarLivro(int id)
    {
        const string query = @"
        SELECT Id, Titulo, Genero, Autor, NumeroDePaginas, AnoPublicacao
        FROM Livros
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Livro(
                reader.GetInt32("Id"),
                reader.GetString("Titulo"),
                reader.GetString("Genero"),
                reader.GetString("Autor"),
                reader.GetInt32("NumeroDePaginas"),
                reader.GetInt32("AnoPublicacao")
            );
        }

        return null;
    }

    public async Task<IEnumerable<Livro>> BuscarTodosLivros()
    {
        const string query = @"
        SELECT Id, Titulo, Genero, Autor, NumeroDePaginas, AnoPublicacao
        FROM Livros";

        var livros = new List<Livro>();

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            livros.Add(new Livro(
                reader.GetInt32("Id"),
                reader.GetString("Titulo"),
                reader.GetString("Genero"),
                reader.GetString("Autor"),
                reader.GetInt32("NumeroDePaginas"),
                reader.GetInt32("AnoPublicacao")
            ));
        }

        return livros; 
    }

    public async Task<Livro> AtualizarLivro(Livro livro)
    {
        const string query = @"
        UPDATE Livros
        SET Titulo = @Titulo, Genero = @Genero, Autor = @Autor,
        NumeroDePaginas = @NumeroDePaginas, AnoPublicacao = @AnoPublicacao
        Where Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", livro.Id);
        command.Parameters.AddWithValue("@Titulo", livro.Titulo);
        command.Parameters.AddWithValue("@Genero", livro.Genero);
        command.Parameters.AddWithValue("Autor", livro.Autor);
        command.Parameters.AddWithValue("@NumeroDePaginas", livro.NumeroDePaginas);
        command.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? livro : null;
    }

    public async Task<bool> DeletarLivro(int id)
    {
        const string query = @"DELETE FROM Livros WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }
}