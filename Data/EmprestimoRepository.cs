using System.Data;
using Biblioteca.Entidades;
using MySql.Data.MySqlClient;


public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly string _connectionString;

    public EmprestimoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Emprestimo> AdicionarEmprestimo(Emprestimo emprestimo)
    {
        const string query = @"
        INSERT INTO Emprestimo (InventarioId, UsuarioId, DataEmprestimo, DataDevolucao, Status)
        VALUES (@InventarioId, @UsuarioId, @DataEmprestimo, @DataDevolucao, @Status)";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@InventarioId", emprestimo.InventarioId);            
        command.Parameters.AddWithValue("@UsuarioId", emprestimo.UsuarioId);
        command.Parameters.AddWithValue("@DataEmprestimo", emprestimo.DataEmprestimo);
        command.Parameters.AddWithValue("@DataDevolucao", emprestimo.DataDevolucao == DateTime.MinValue ? DBNull.Value : emprestimo.DataDevolucao);             
        command.Parameters.AddWithValue("@Status", emprestimo.Status);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        emprestimo.Id = (int)command.LastInsertedId;
        return emprestimo;
    }

    public async Task<Emprestimo> BuscarEmprestimo(int id)
    {
        const string query = @"
        SELECT Id, InventarioId, UsuarioId, DataEmprestimo, DataDevolucao, Status
        FROM Emprestimo
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Emprestimo(
                reader.GetInt32("Id"),
                reader.GetInt32("InventarioId"),
                reader.GetInt32("UsuarioId"),
                reader.GetDateTime("DataEmprestimo"),
                reader.IsDBNull("DataDevolucao") ? DateTime.MinValue : reader.GetDateTime("DataDevolucao"),
                reader.GetString("Status")
            );
        }

        return null;
    }

    public async Task<IEnumerable<Emprestimo>> BuscarTodosEmprestimos()
    {
        const string query = @"
        SELECT Id, InventarioId, UsuarioId, DataEmprestimo, DataDevolucao, Status
        FROM Emprestimo";

        var emprestimos = new List<Emprestimo>();

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            emprestimos.Add(new Emprestimo(
                reader.GetInt32("Id"),
                reader.GetInt32("InventarioId"),
                reader.GetInt32("UsuarioId"),
                reader.GetDateTime("DataEmprestimo"),
                reader.IsDBNull("DataDevolucao") ? DateTime.MinValue : reader.GetDateTime("DataDEvolucao"),
                reader.GetString("Status")
            ));
        }

        return emprestimos;
    }

    public async Task<Emprestimo> AtualizarEmprestimo(Emprestimo emprestimo)
    {
        const string query = @"
        UPDATE Emprestimo   
        SET InventarioId = @InventarioId,
        UsuarioId = @UsuarioId,
        DataEmprestimo = @DataEmprestimo,
        DataDevolucao = @DataDevolucao,
        Status = @Status
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", emprestimo.Id);
        command.Parameters.AddWithValue("@InventarioId", emprestimo.InventarioId);
        command.Parameters.AddWithValue("@UsuarioId", emprestimo.UsuarioId);
        command.Parameters.AddWithValue("@DataEmprestimo", emprestimo.DataEmprestimo);
        command.Parameters.AddWithValue("@DataDevolucao", emprestimo.DataDevolucao);
        command.Parameters.AddWithValue("@Status", emprestimo.Status);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0 ? emprestimo : null;
    }

    public async Task<bool> DeletarEmprestimo(int id)
    {
        const string query = @"DELETE FROM Emprestimo WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }
}