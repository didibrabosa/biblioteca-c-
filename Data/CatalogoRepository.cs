using System.Data;
using Biblioteca.Entidades;
using MySql.Data.MySqlClient;

public class CatalogoRepository : ICatalogoRepository
{
    private readonly string _connectionString;

    public CatalogoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Catalogo> AdicionarCatalogo(Catalogo catalogo)
    {
        const string query = @"
        INSERT INTO Catalogos (Nome, Genero, LivroId)
        VALUES (@Nome, @Genero, @LivroId);
        SELECT LAST_INSERT_ID();";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Nome", catalogo.Nome);
        command.Parameters.AddWithValue("@Genero", catalogo.Genero);

        await connection.OpenAsync();
        catalogo.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
        return catalogo;
    }

    public async Task<Catalogo> BuscarCatalogo(int id)
    {
        const string query = @"
        SELECT c.Id, c.Nome, c.Genero, l.Id as LivroId, l.Tutulo, l.Genero as LivroGenero, l.Autor, l.NumeroDePaginas, l.AnoPublicacao
        FROM Catalogos c
        LEFT JOIN Catalogo_Livros cl On c.Id = cl.CatalogoId
        LEFT JOIN Livros l ON cl.LivrosId - l.Id
        WHERE c.Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        Catalogo catalogo = null;

        while (await reader.ReadAsync())
        {
            if (catalogo == null)
            {
                catalogo = new Catalogo(
                    reader.GetInt32("Id"),
                    reader.GetString("Nome"),
                    reader.GetString("Genero")
                );
            }

            if (reader ["LivroId"] != DBNull.Value)
            {
                catalogo.Livros.Add(new Livro(
                    reader.GetInt32("LivroId"),
                    reader.GetString("Titulo"),
                    reader.GetString("LivroGenero"),
                    reader.GetString("Autor"),
                    reader.GetInt32("NumeroDePaginas"),
                    reader.GetInt32("AnoPublicacao")
                ));
            }
        }

        return catalogo;
        
    }

    public async Task<IEnumerable<Catalogo>> BuscarTodosCatalogos()
    {
        const string query = @"
        SELECT Id, Nome, Genero
        FROM Catalogos";

        var catalogos = new List<Catalogo>();

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            catalogos.Add(new Catalogo(
                reader.GetInt32("Id"),
                reader.GetString("Nome"),
                reader.GetString("Genero")
            ));
        }

        return catalogos;
    }

    public async Task<Catalogo> AtualizarCatalogo(Catalogo catalogo)
    {
        const string query = @"
        UPDATE Catalogos
        SET Nome = @Nome, Genero = @Genero
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", catalogo.Id);
        command.Parameters.AddWithValue("@Nome", catalogo.Nome);
        command.Parameters.AddWithValue("@Genero", catalogo.Genero);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? catalogo : null;
    }

    public async Task<bool> DeletarCatalogo(int id)
    {
        const string query = @"
        DELETE FROM Catalogos
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }

    public async Task AdicionarLivroCatalogo(int catalogoId, int livroId)
    {
        const string query = @"
        INSERT INTO Catalogos_Livros (CatalogoId, LivroId)
        VALUES (@CatalogoId, @LivroId)";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@CatalogoId", catalogoId);
        command.Parameters.AddWithValue("@LivroId", livroId);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    public async Task<bool> RemoverLivroCatalogo(int catalogoId, int livroId)
    {
        const string query = @"
        DELETE FROM Catalogo_Livros
        WHERE CatalogoId = @CatalogoId AND LivroId = @LivroId";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@CatalogoId", catalogoId);
        command.Parameters.AddWithValue("@LivroId", livroId);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;    
    }

}
