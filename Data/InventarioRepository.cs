using System.Data;
using Biblioteca.Entidades;
using MySql.Data.MySqlClient;

public class InventarioRepository : IInventarioRepository
{
    private readonly string _connectionString;

    public InventarioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Inventario> AdicionarInventario(Inventario inventario)
    {
        const string query = @"
        INSERT INTO Inventario (LivroId, Quantidade, Estado)
        VALUES (@LivroId, @Quantidade, @Estado)
        ON DUPLICATE KEY UPDATE
        Quantidade = Quantidade + @Quantidade, Estado = @Estado;";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@LivroId", inventario.LivroId);
        command.Parameters.AddWithValue("@Quantidade", inventario.Quantidade);
        command.Parameters.AddWithValue("@Estado", inventario.Estado);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
        
        return inventario;
    }

    public async Task<Inventario> BuscarInventario(int livroId)
    {
        const string query = @"
        SELECT Id, LivroId, Quantidade, Estado
        FROM Inventario
        WHERE LivroId = @LivroId";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@LivroId", livroId);

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Inventario(
                reader.GetInt32("Id"),
                reader.GetInt32("LivroId"),
                reader.GetInt32("Quantidade"),
                reader.GetString("Estado")
            );
        }

        return null;
    }

    public async Task<IEnumerable<Inventario>> BuscarTodosInventarios()
    {
        const string query = @"
        SELECT Id, LivroId, Quantidade, Estado
        FROM Inventario";

        var inventarios = new List<Inventario>();

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            inventarios.Add(new Inventario(
                reader.GetInt32("Id"),
                reader.GetInt32("LivroId"),
                reader.GetInt32("Quantidade"),
                reader.GetString("Estado")
            ));
        }

        return inventarios;
    }

    public async Task<Inventario> AtualizarInventario(Inventario inventario)
    {
        const string query = @"
        UPDATE Inventario
        SET LivroId = @LivroId, Quantidade = @Quantidade, Estado = @Estado
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", inventario.Id);
        command.Parameters.AddWithValue("@LivroId", inventario.LivroId);
        command.Parameters.AddWithValue("@Quantidade", inventario.Quantidade);
        command.Parameters.AddWithValue("@Estado", inventario.Estado);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? inventario : null;
    }

    public async Task<bool> DeletarInventario(int livroId)
    {
        const string query = @"DELETE FROM Inventario WHERE LivroId = @LivroId";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@LivroId", livroId);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0; 
    }
}