using System.Text.RegularExpressions;
using Biblioteca.Entidades;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> AdicionarUsuario(Usuario usuario)
    {
        ValidarUsuario(usuario);
        
        return await _usuarioRepository.AdicionarUsuario(usuario);
    }

    public async Task<Usuario> BuscarUsuario(int id)
    {
         if (id <= 0)
             throw new ArgumentException("O ID do Usuário deve ser maior que zero");

             var usuario = await _usuarioRepository.BuscarUsuario(id);

             if (usuario == null)
                 throw new KeyNotFoundException($"Usuário com ID {id} não encontrado."); 
            
             return usuario;
    }

    public async Task<IEnumerable<Usuario>> BuscarTodosUsuarios() 
    {
         var usuarios = await _usuarioRepository.BuscarTodosUsuarios();

         if (usuarios == null || !usuarios.Any())
             throw new KeyNotFoundException("Nenhum usuário encotrado.");

         return usuarios;  
    }

    public async Task<Usuario> AtualizarUsuario(Usuario usuario)
    {
        ValidarUsuario(usuario, isUpdate: true);
        
        return await _usuarioRepository.AtualizarUsuario(usuario);
    }

    public async Task<bool> DeletarUsuario(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID do Úsuario deve ser maior que zero");
        
        return await _usuarioRepository.DeletarUsuario(id);
    }

    private void ValidarUsuario(Usuario usuario, bool isUpdate = false)
    {
         if (usuario == null)
            throw new ArgumentException("Usuário não pode ser nulo.");

        if (!isUpdate && string.IsNullOrWhiteSpace(usuario.Nome))
            throw new ArgumentException("Nome do usuário não pode ser vazio.");

        if (usuario.Idade <= 0)
            throw new ArgumentException("Idade do usuário inválida.");

         if (usuario.DataDeNascimento == DateTime.MinValue && usuario.DataDeNascimento != null)
            throw new ArgumentException("Data de nascimento inválida.");

        if (!isUpdate && string.IsNullOrWhiteSpace(usuario.Cpf))
            throw new ArgumentException("CPF do usuário não pode ser vazio.");
        
         if (!isUpdate && string.IsNullOrWhiteSpace(usuario.Telefone))
            throw new ArgumentException("Número de telefone do usuário não pode ser vazio.");

        if (!isUpdate && string.IsNullOrWhiteSpace(usuario.Email))
            throw new ArgumentException("Email do usuário não pode ser vazio.");

        if (!isUpdate)
        {
            if (!ValidarCpf(usuario.Cpf))
                throw new ArgumentException("CPF inválido.");

            if (!ValidarTelefone(usuario.Telefone))
                throw new ArgumentException("Telefone inválido.");

            if (!ValidarEmail(usuario.Email))
                throw new ArgumentException("E-Mail inválido.");    
        }

    }

    private bool ValidarCpf(string cpf)
    {
        return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
    }

    private bool ValidarTelefone(string telefone)
    {
        return Regex.IsMatch(telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$");
    }

    private bool ValidarEmail(string email)
    {
        return Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
    }
}