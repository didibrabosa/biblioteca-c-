using Biblioteca.Entidades; 

class Program
{
    static async Task Main(string[] args)
    {
        var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123;";
        var usuarioRepository = new UsuarioRepository(connectionString);
        var usuarioService = new UsuarioService(usuarioRepository);

        while (true)
        {
            Console.WriteLine("1. Adicionar Usuário");
            Console.WriteLine("2. Buscar Usuário por ID");
            Console.WriteLine("3. Listar Todos os Usuários");
            Console.WriteLine("4. Atualizar Usuário");
            Console.WriteLine("5. Deletar Usuário");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    await AdicionarUsuario(usuarioService);
                    continue;
                case "2":
                    await BuscarUsuario(usuarioService);
                    continue;
                case "3":
                    await BuscarTodosUsuarios(usuarioService);
                    continue;
                case "4":
                    await AtualizarUsuario(usuarioService);
                    continue;
                case "5": 
                    await DeletarUsuario(usuarioService);
                    continue;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }
        }
    }

    static async Task AdicionarUsuario(UsuarioService usuarioService)
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        Console.Write("Idade: ");
        var idade = int.Parse(Console.ReadLine());

        Console.WriteLine("Data de Nascimento (yyyy-MM-dd): ");
        var DataDeNascimento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("CPF: ");
        var cpf = Console.ReadLine();

        Console.WriteLine("Telefone: ");
        var telefone = Console.ReadLine();
        
        Console.WriteLine("Email: ");
        var email = Console.ReadLine();

        var usuario = new Usuario
        {
            Nome = nome,
            Idade = idade,
            DataDeNascimento = DataDeNascimento,
            Cpf = cpf,
            Telefone = telefone,
            Email = email
        };

        var resultado = await usuarioService.AdicionarUsuario(usuario);
        Console.WriteLine($"Usuario adicionado com ID: {resultado.Id}");
    }

    static async Task BuscarUsuario(UsuarioService usuarioService)
    {
        Console.WriteLine("Digite o ID do Usuário: ");
        var id = int.Parse(Console.ReadLine());
        var usuario = await usuarioService.BuscarUsuario(id);

        Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Idade: {usuario.Idade}, Data de Nascimento: {usuario.DataDeNascimento}, CPF: {usuario.Cpf}, Telefone: {usuario.Telefone}, Email: {usuario.Email}");        
    }

    static async Task BuscarTodosUsuarios(UsuarioService usuarioService)
    {
        var usuarios = await usuarioService.BuscarTodosUsuarios();

        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Idade: {usuario.Idade}, Data de Nascimento: {usuario.DataDeNascimento}, CPF: {usuario.Cpf}, Telefone: {usuario.Telefone}, Email: {usuario.Email}");
        }
    }

    static async Task AtualizarUsuario(UsuarioService usuarioService)
    {
        Console.Write("Digite o ID do usuário a ser atualizado: ");
        var id = int.Parse(Console.ReadLine());

        var usuarioExistente = await usuarioService.BuscarUsuario(id);
        if (usuarioExistente == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        Console.Write("Novo Nome (deixe em branco para não alterar): ");
        var nome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nome)) usuarioExistente.Nome = nome;

        Console.Write("Nova Idade (deixa em branco para não alterar): ");
        var idade = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(idade)) usuarioExistente.Idade = int.Parse(idade);

        Console.Write("Nova Data de Nascimento (deixe em branco para não alterar): ");
        var data = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(data)) usuarioExistente.DataDeNascimento = DateTime.Parse(data);

        Console.Write("Novo Cpf (deixe em branco para não alterar): ");
        var cpf = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(cpf)) usuarioExistente.Cpf = cpf;

        Console.Write("Novo Telefone (deixe em branco para não alterar): ");
        var telefone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(telefone)) usuarioExistente.Telefone = telefone;
        
        Console.Write("Novo Email (Deixe em branco para não alterar): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email)) usuarioExistente.Email = email;

        await usuarioService.AtualizarUsuario(usuarioExistente);
        Console.WriteLine("Usuário atualizado com sucesso.");
    }

    static async Task DeletarUsuario(UsuarioService usuarioService)
    {
        Console.Write("Digite o ID do usuário a ser detalhado: ");
        var id = int.Parse(Console.ReadLine());

        var sucesso = await usuarioService.DeletarUsuario(id);
        Console.WriteLine(sucesso ? "Usuário deletado com sucesso." : "Erro ao deletar usuário.");
    }
}