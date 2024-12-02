using System.Data;
using MySql.Data.MySqlClient;
using Biblioteca.Entidades;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;

    public UsuarioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Usuario> AdicionarUsuario(Usuario usuario)
    {
        const string query = @"INSERT INTO Usuarios (Nome, Idade, DataDeNascimento, Cpf, Telefone, Email)
        VALUES (@Nome, @Idade, @DataDeNascimento, @Cpf, @Telefone, @Email);
        SELECT LAST_INSERT_ID();";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Nome", usuario.Nome);
        command.Parameters.AddWithValue("@Idade", usuario.Idade);
        command.Parameters.AddWithValue("@DataDeNascimento", usuario.DataDeNascimento);
        command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
        command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
        command.Parameters.AddWithValue("@Email", usuario.Email);
        
        await connection.OpenAsync();
        usuario.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
        return usuario;
    }
    

    public async Task<Usuario> BuscarUsuario(int id)
    {
        const string query = @"SELECT Id, Nome, Idade, DataDeNascimento, Cpf, Telefone, Email 
        FROM Usuarios
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Usuario(

                reader.GetInt32("Id"),
                reader.GetString("Nome"),
                reader.GetInt32("Idade"),
                reader.GetDateTime("DataDeNascimento"),
                reader.GetString("Cpf"),
                reader.GetString("Telefone"),
                reader.GetString("Email")

            
            //     Id = reader.GetInt32(0),
            //     Nome = reader.GetString(1),
            //     Idade = reader.GetInt32(2),
            //     DataDeNascimento = reader.GetDateTime(3),
            //     Cpf = reader.GetString(4),
            //     Telefone = reader.GetString(5),
            //     Email = reader.GetString(6)

                // Id = reader.GetInt32("Id"),
                // Nome = reader.GetString("Nome"),
                // Idade = reader.GetInt32("Idade"),
                // DataDeNascimento = reader.GetDateTime("DataDeNascimento"),
                // Cpf = reader.GetString("Cpf"),
                // Telefone = reader.GetString("Telefone"),
                // Email = reader.GetString("Email")
            );
        }

        return null;
    }

    public async Task<IEnumerable<Usuario>> BuscarTodosUsuarios()
    {
        const string query = @"SELECT Id, Nome, Idade, DataDeNascimento, Cpf, Telefone, Email
        FROM Usuarios";

        var usuarios = new List<Usuario>();

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            usuarios.Add(new Usuario( 
            
                reader.GetInt32("Id"),
                reader.GetString("Nome"),
                reader.GetInt32("Idade"),
                reader.GetDateTime("DataDeNascimento"),
                reader.GetString("Cpf"),
                reader.GetString("Telefone"),
                reader.GetString("Email")
            ));
        }

        return usuarios;
    }

    public async Task<Usuario> AtualizarUsuario(Usuario usuario)
    {
        const string query = @"UPDATE Usuarios
        SET Nome = @Nome, Idade = @Idade, DataDeNascimento = @DataDeNascimento, 
        Cpf = @Cpf, Telefone = @Telefone, Email = @Email
        WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", usuario.Id);
        command.Parameters.AddWithValue("@Nome", usuario.Nome);
        command.Parameters.AddWithValue("@Idade", usuario.Idade);
        command.Parameters.AddWithValue("@DataDeNascimento", usuario.DataDeNascimento);
        command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
        command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
        command.Parameters.AddWithValue("@Email", usuario.Email);

        await connection.OpenAsync();
        var rowsAfected = await command.ExecuteNonQueryAsync();

        return rowsAfected > 0 ? usuario : null;
    }

    public async Task<bool> DeletarUsuario(int id)
    {
        const string query = @"DELETE FROM Usuarios WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();

        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }
}