public interface IUsuarioRepository
{
    Task<Usuario> AdicionarUsuario(Usuario usuario);
    Task<Usuario> BuscarUsuario (int id);
    Task<IEnumerable<Usuario>> BuscarTodosUsuarios();
    Task<Usuario> AtualizarUsuario(Usuario usuario);
    Task<bool> DeletarUsuario(int id);
}