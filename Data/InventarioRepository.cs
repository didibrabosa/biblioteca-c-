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
        INSERT INTO Inventario (LivroId, Quantidade, Estado, Disponibilidade)
        VALUES (@LivroId, @Quantidade, @Estado, @Disponibilidade)
        ON DUPLICATE KEY UPDATE
        Quantidade = Quantidade + @Quantidade, Estado = @Estado, Disponibilidade = @Disponibilidade;";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@LivroId", inventario.LivroId);
        command.Parameters.AddWithValue("@Quantidade", inventario.Quantidade);
        command.Parameters.AddWithValue("@Estado", inventario.Estado);
        command.Parameters.AddWithValue("@Disponibilidade", inventario.Disponibilidade);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
        
        return inventario;
    }

    public async Task<Inventario> BuscarInventario(int id)
    {
        const string query = @"
        SELECT Id, LivroId, Quantidade, Estado, Disponibilidade
        FROM Inventario
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id",id);

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Inventario(
                reader.GetInt32("Id"),
                reader.GetInt32("LivroId"),
                reader.GetInt32("Quantidade"),
                reader.GetString("Estado"),
                reader.GetBoolean("Disponibilidade")
            );
        }

        return null;
    }

    public async Task<IEnumerable<Inventario>> BuscarTodosInventarios()
    {
        const string query = @"
        SELECT Id, LivroId, Quantidade, Estado, Disponibilidade
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
                reader.GetString("Estado"),
                reader.GetBoolean("Disponibilidade")
            ));
        }

        return inventarios;
    }

    public async Task<Inventario> AtualizarInventario(Inventario inventario)
    {
        const string query = @"
        UPDATE Inventario
        SET LivroId = @LivroId, Quantidade = @Quantidade, Estado = @Estado, Disponibilidade = @Disponibilidade
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", inventario.Id);
        command.Parameters.AddWithValue("@LivroId", inventario.LivroId);
        command.Parameters.AddWithValue("@Quantidade", inventario.Quantidade);
        command.Parameters.AddWithValue("@Estado", inventario.Estado);
        command.Parameters.AddWithValue("@Disponibilidade", inventario.Disponibilidade);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? inventario : null;
    }

    public async Task<bool> DeletarInventario(int id)
    {
        const string query = @"DELETE FROM Inventario WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0; 
    }
}