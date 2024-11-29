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
         if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ArgumentException("Nome do usuário não pode ser vazio.");
            
            if (usuario.Idade <= 0)
                throw new ArgumentException("Idade do usuário não pode ser zero ou negativa.");

            if (usuario.DataDeNascimento == DateTime.MinValue)
                throw new ArgumentException("Data de nascimento do usuário não pode ser vazia.");

            if (string.IsNullOrWhiteSpace(usuario.Cpf))
                throw new ArgumentException("CPF do usuário não pode ser vazio.");
            
            if (string.IsNullOrWhiteSpace(usuario.Telefone))
                throw new ArgumentException("Número de telefone do usuário não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("Email do usuário não pode ser vazio.");

            return await _usuarioRepository.AdicionarUsuario(usuario);
    }

    public async Task<Usuario> BuscarUsuario(int id) => await _usuarioRepository.BuscarUsuario(id);
    // {
    //     if (id <= 0)
    //         throw new ArgumentException("O ID do Usuário deve ser maior que zero");

    //         var usuario = await _usuarioRepository.BuscarUsuario(id);

    //         if (usuario == null)
    //             throw new KeyNotFoundException($"Usuário com ID {id} não encontrado."); 
            
    //         return usuario;
    // }

    
    public async Task<IEnumerable<Usuario>> BuscarTodosUsuarios() => await _usuarioRepository.BuscarTodosUsuarios();
    // {
    //     var usuarios = await _usuarioRepository.BuscarTodosUsuarios();

    //     if (usuarios == null || !usuarios.Any())
    //         throw new KeyNotFoundException("Nenhum usuário encotrado.");

    //     return usuarios;  
    // }

    public async Task<Usuario> AtualizarUsuario(Usuario usuario) => await  _usuarioRepository.AtualizarUsuario(usuario);

    public async Task<bool> DeletarUsuario(int id) => await _usuarioRepository.DeletarUsuario(id);

}