using Biblioteca.Entidades; 

class Program
{
//     static async Task Main(string[] args)
//     {
//         var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123;";
//         var usuarioRepository = new UsuarioRepository(connectionString);
//         var usuarioService = new UsuarioService(usuarioRepository);

//         while (true)
//         {
//             Console.WriteLine("1. Adicionar Usuário");
//             Console.WriteLine("2. Buscar Usuário por ID");
//             Console.WriteLine("3. Listar Todos os Usuários");
//             Console.WriteLine("4. Atualizar Usuário");
//             Console.WriteLine("5. Deletar Usuário");
//             Console.WriteLine("0. Sair");
//             Console.Write("Escolha uma opção: ");

//             var opcao = Console.ReadLine();
//             switch (opcao)
//             {
//                 case "1":
//                     await AdicionarUsuario(usuarioService);
//                     continue;
//                 case "2":
//                     await BuscarUsuario(usuarioService);
//                     continue;
//                 case "3":
//                     await BuscarTodosUsuarios(usuarioService);
//                     continue;
//                 case "4":
//                     await AtualizarUsuario(usuarioService);
//                     continue;
//                 case "5": 
//                     await DeletarUsuario(usuarioService);
//                     continue;
//                 case "0":
//                     return;
//                 default:
//                     Console.WriteLine("Opção inválida.");
//                     return;
//             }
//         }
//     }

//     static async Task AdicionarUsuario(UsuarioService usuarioService)
//     {
//         Console.Write("Nome: ");
//         var nome = Console.ReadLine();

//         Console.Write("Idade: ");
//         var idade = int.Parse(Console.ReadLine());

//         Console.WriteLine("Data de Nascimento (yyyy-MM-dd): ");
//         var DataDeNascimento = DateTime.Parse(Console.ReadLine());

//         Console.WriteLine("CPF: ");
//         var cpf = Console.ReadLine();

//         Console.WriteLine("Telefone: ");
//         var telefone = Console.ReadLine();
        
//         Console.WriteLine("Email: ");
//         var email = Console.ReadLine();

//         var usuario = new Usuario
//         {
//             Nome = nome,
//             Idade = idade,
//             DataDeNascimento = DataDeNascimento,
//             Cpf = cpf,
//             Telefone = telefone,
//             Email = email
//         };

//         var resultado = await usuarioService.AdicionarUsuario(usuario);
//         Console.WriteLine($"Usuario adicionado com ID: {resultado.Id}");
//     }

//     static async Task BuscarUsuario(UsuarioService usuarioService)
//     {
//         Console.WriteLine("Digite o ID do Usuário: ");
//         var id = int.Parse(Console.ReadLine());
//         var usuario = await usuarioService.BuscarUsuario(id);

//         Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Idade: {usuario.Idade}, Data de Nascimento: {usuario.DataDeNascimento}, CPF: {usuario.Cpf}, Telefone: {usuario.Telefone}, Email: {usuario.Email}");        
//     }

//     static async Task BuscarTodosUsuarios(UsuarioService usuarioService)
//     {
//         var usuarios = await usuarioService.BuscarTodosUsuarios();

//         foreach (var usuario in usuarios)
//         {
//             Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Idade: {usuario.Idade}, Data de Nascimento: {usuario.DataDeNascimento}, CPF: {usuario.Cpf}, Telefone: {usuario.Telefone}, Email: {usuario.Email}");
//         }
//     }

//     static async Task AtualizarUsuario(UsuarioService usuarioService)
//     {
//         Console.Write("Digite o ID do usuário a ser atualizado: ");
//         var id = int.Parse(Console.ReadLine());

//         var usuarioExistente = await usuarioService.BuscarUsuario(id);
//         if (usuarioExistente == null)
//         {
//             Console.WriteLine("Usuário não encontrado.");
//             return;
//         }

//         Console.Write("Novo Nome (deixe em branco para não alterar): ");
//         var nome = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(nome)) usuarioExistente.Nome = nome;

//         Console.Write("Nova Idade (deixa em branco para não alterar): ");
//         var idade = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(idade)) usuarioExistente.Idade = int.Parse(idade);

//         Console.Write("Nova Data de Nascimento (deixe em branco para não alterar): ");
//         var data = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(data)) usuarioExistente.DataDeNascimento = DateTime.Parse(data);

//         Console.Write("Novo Cpf (deixe em branco para não alterar): ");
//         var cpf = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(cpf)) usuarioExistente.Cpf = cpf;

//         Console.Write("Novo Telefone (deixe em branco para não alterar): ");
//         var telefone = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(telefone)) usuarioExistente.Telefone = telefone;
        
//         Console.Write("Novo Email (Deixe em branco para não alterar): ");
//         var email = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(email)) usuarioExistente.Email = email;

//         await usuarioService.AtualizarUsuario(usuarioExistente);
//         Console.WriteLine("Usuário atualizado com sucesso.");
//     }

//     static async Task DeletarUsuario(UsuarioService usuarioService)
//     {
//         Console.Write("Digite o ID do usuário a ser detalhado: ");
//         var id = int.Parse(Console.ReadLine());

//         var sucesso = await usuarioService.DeletarUsuario(id);
//         Console.WriteLine(sucesso ? "Usuário deletado com sucesso." : "Erro ao deletar usuário.");
//     }
    // static async Task Main(string[] args)
    // {
    //     var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123;";
    //     var livroRepository = new LivroRepository(connectionString);
    //     var livroService = new LivroService(livroRepository);

    //     while (true)
    //     {
    //         Console.WriteLine("1. Adicionar Livro");
    //         Console.WriteLine("2. Buscar Livro por ID");
    //         Console.WriteLine("3. Listar Todos os Livros");
    //         Console.WriteLine("4. Atualizar Livro");
    //         Console.WriteLine("5. Deletar Livro");
    //         Console.WriteLine("0. Sair");
    //         Console.Write("Escolha uma opção: ");

    //         var opcao = Console.ReadLine();
    //         switch (opcao)
    //         {
    //             case "1":
    //                 await AdicionarLivro(livroService);
    //                 continue;
    //             case "2":
    //                 await BuscarLivro(livroService);
    //                 continue;
    //             case "3":
    //                 await BuscarTodosLivros(livroService);
    //                 continue;
    //             case "4":
    //                 await AtualizarLivro(livroService);
    //                 continue;
    //             case "5":
    //                 await DeletarLivro(livroService);
    //                 continue;
    //             case "0":
    //                 return;
    //             default:
    //                 Console.WriteLine("Opção inválida.");
    //                 continue;
    //         }
    //     }
    // }

    // static async Task AdicionarLivro(LivroService livroService)
    // {
    //     Console.Write("Título: ");
    //     var titulo = Console.ReadLine();

    //     Console.Write("Gênero: ");
    //     var genero = Console.ReadLine();

    //     Console.Write("Autor: ");
    //     var autor = Console.ReadLine();

    //     Console.Write("Número de Páginas: ");
    //     var numeroDePaginas = int.Parse(Console.ReadLine());

    //     Console.Write("Ano de Publicação: ");
    //     var anoPublicacao = int.Parse(Console.ReadLine());

    //     var livro = new Livro
    //     {
    //         Titulo = titulo,
    //         Genero = genero,
    //         Autor = autor,
    //         NumeroDePaginas = numeroDePaginas,
    //         AnoPublicacao = anoPublicacao
    //     };

    //     var resultado = await livroService.AdicionarLivro(livro);
    //     Console.WriteLine($"Livro adicionado com ID: {resultado.Id}");
    // }

    // static async Task BuscarLivro(LivroService livroService)
    // {
    //     Console.Write("Digite o ID do livro: ");
    //     var id = int.Parse(Console.ReadLine());
    //     var livro = await livroService.BuscarLivro(id);

    //     Console.WriteLine($"ID: {livro.Id}, Título: {livro.Titulo}, Gênero: {livro.Genero}, Autor: {livro.Autor}, Páginas: {livro.NumeroDePaginas}, Ano: {livro.AnoPublicacao}");
    // }

    // static async Task BuscarTodosLivros(LivroService livroService)
    // {
    //     var livros = await livroService.BuscarTodosLivros();

    //     foreach (var livro in livros)
    //     {
    //         Console.WriteLine($"ID: {livro.Id}, Título: {livro.Titulo}, Gênero: {livro.Genero}, Autor: {livro.Autor}, Páginas: {livro.NumeroDePaginas}, Ano: {livro.AnoPublicacao}");
    //     }
    // }

    // static async Task AtualizarLivro(LivroService livroService)
    // {
    //     Console.Write("Digite o ID do livro a ser atualizado: ");
    //     var id = int.Parse(Console.ReadLine());

    //     var livroExistente = await livroService.BuscarLivro(id);
    //     if (livroExistente == null)
    //     {
    //         Console.WriteLine("Livro não encontrado.");
    //         return;
    //     }

    //     Console.Write("Novo Título (deixe em branco para não alterar): ");
    //     var titulo = Console.ReadLine();
    //     if (!string.IsNullOrWhiteSpace(titulo)) livroExistente.Titulo = titulo;

    //     Console.Write("Novo Gênero (deixe em branco para não alterar): ");
    //     var genero = Console.ReadLine();
    //     if (!string.IsNullOrWhiteSpace(genero)) livroExistente.Genero = genero;

    //     Console.Write("Novo Autor (deixe em branco para não alterar): ");
    //     var autor = Console.ReadLine();
    //     if (!string.IsNullOrWhiteSpace(autor)) livroExistente.Autor = autor;

    //     Console.Write("Novo Número de Páginas (deixe em branco para não alterar): ");
    //     var paginas = Console.ReadLine();
    //     if (!string.IsNullOrWhiteSpace(paginas)) livroExistente.NumeroDePaginas = int.Parse(paginas);

    //     Console.Write("Novo Ano de Publicação (deixe em branco para não alterar): ");
    //     var ano = Console.ReadLine();
    //     if (!string.IsNullOrWhiteSpace(ano)) livroExistente.AnoPublicacao = int.Parse(ano);

    //     await livroService.AtualizarLivro(livroExistente);
    //     Console.WriteLine("Livro atualizado com sucesso.");
    // }

    // static async Task DeletarLivro(LivroService livroService)
    // {
    //     Console.Write("Digite o ID do livro a ser deletado: ");
    //     var id = int.Parse(Console.ReadLine());

    //     var sucesso = await livroService.DeletarLivro(id);
    //     Console.WriteLine(sucesso ? "Livro deletado com sucesso" : "Erro ao deletar livro");
    // }

//     static async Task Main(string[] args)
//     {
//         var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123;";
//         var inventarioRepository = new InventarioRepository(connectionString);
//         var livroRepository = new LivroRepository(connectionString);
//         var inventarioService = new InventarioService(inventarioRepository, livroRepository);

//         while (true)
//         {
//             Console.WriteLine("1. Adicionar Livro ao Inventário");
//             Console.WriteLine("2. Buscar Livro no Inventário");
//             Console.WriteLine("3. Buscar todos Livros no Inventário");
//             Console.WriteLine("4. Atualizar Livro do Inventário");
//             Console.WriteLine("5. Deletar Livro do Inventário");
//             Console.WriteLine("0. Sair");
//             Console.Write("Escolha uma opção: ");

//             var opcao = Console.ReadLine();
//             switch (opcao)
//             {
//                 case "1":
//                     await AdicionarInventario(inventarioService);
//                     continue;
//                 case "2":
//                     await BuscarInventario(inventarioService);
//                     continue;
//                 case "3":
//                     await BuscarTodosInventarios(inventarioService);
//                     continue;
//                 case "4":
//                     await AtualizarInventario(inventarioService);
//                     continue;
//                 case "5":
//                     await DeletarInventario(inventarioService);
//                     continue;
//                 case "0":
//                     return;
//                 default:
//                     Console.WriteLine("Opção inválida.");
//                     continue;
//             }
//         }
//     }

//     static async Task AdicionarInventario(InventarioService inventarioService)
//     {
//         Console.Write("ID do Livro: ");
//         var livroId = int.Parse(Console.ReadLine());

//         Console.Write("Quantidade: ");
//         var quantidade = int.Parse(Console.ReadLine());

//         Console.Write("Estado: ");
//         var estado = Console.ReadLine();

//         var inventario = new Inventario
//         {
//             LivroId = livroId,
//             Quantidade = quantidade,
//             Estado = estado
//         };

//         var resultado = await inventarioService.AdicionarInventario(inventario);
//         Console.WriteLine("Inventário adicionado com sucesso!");    
//     }

//     static async Task BuscarInventario(InventarioService inventarioService)
//     {
//         Console.Write("Digite o ID do Livro: ");
//         var id = int.Parse(Console.ReadLine());
//         var inventario = await inventarioService.BuscarInventario(id);
         
//         Console.WriteLine($"ID: {inventario.Id}");
//         Console.WriteLine($"ID do Livro: {inventario.LivroId}"); 
//         Console.WriteLine($"Quantidade: {inventario.Quantidade}");
//         Console.WriteLine($"Estado: {inventario.Estado}");
//     }

//     static async Task<IEnumerable<Inventario>> BuscarTodosInventarios(InventarioService inventarioService)
//     {
//         var inventarios = await inventarioService.BuscarTodosInventarios();

//         foreach (var inventario in inventarios)
//         {
//             Console.WriteLine($"ID: {inventario.Id}");
//             Console.WriteLine($"ID do Livro: {inventario.LivroId}");
//             Console.WriteLine($"Quantidade: {inventario.Quantidade}");
//             Console.WriteLine($"Estado: {inventario.Estado}");
//         }

//         return (inventarios);
//     }

//     static async Task AtualizarInventario(InventarioService inventarioService)
//     {
//         Console.Write("ID do Livro: ");
//         var id = int.Parse(Console.ReadLine());

//         Console.Write("Nova Quantidade: ");
//         var quantidade = int.Parse(Console.ReadLine());

//         Console.Write("Novo Estado: ");
//         var estado = Console.ReadLine();

//         var inventarioAtual = await inventarioService.BuscarInventario(id);

//         inventarioAtual.Quantidade = quantidade;
//         inventarioAtual.Estado = estado;

//         var resultado = await inventarioService.AtualizarInventario(inventarioAtual);

//         Console.WriteLine("Livro atualizado com sucesso!");
//     }

//     static async Task DeletarInventario(InventarioService inventarioService)
//     {
//         Console.Write("ID do Livro: ");
//         var id = int.Parse(Console.ReadLine());

//         var resultado = await inventarioService.DeletarInventario(id);
//         Console.WriteLine("Item deletado com sucesso!");
//     } 

//     static async Task Main(string[] args)
//     {
//         var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123";
//         var catalogoRepository = new CatalogoRepository(connectionString);
//         var livroRepository = new LivroRepository(connectionString);
//         var catalogoService = new CatalogoService(catalogoRepository, livroRepository);

//         while (true)
//         {
//             Console.WriteLine("1. Adicionar Catalogo");
//             Console.WriteLine("2. Buscar Catalogo");
//             Console.WriteLine("3. Buscar todos Catalogos");
//             Console.WriteLine("4. Atualizar Catalogo");
//             Console.WriteLine("5. Deletar Catalogo");
//             Console.WriteLine("6. Adicionar Livro ao Catalogo");
//             Console.WriteLine("7. Remover Livro do Catalogo");
//             Console.WriteLine("0. Sair");
//             Console.Write("Escolha uma opção: ");

//             var opcao = Console.ReadLine();
//             switch (opcao)
//             {
//                 case "1":
//                     await AdicionarCatalogo(catalogoService);
//                     continue;
//                 case "2":
//                     await BuscarCatalogo(catalogoService);
//                     continue;
//                 case "3":
//                     await BuscarTodosCatalogos(catalogoService);
//                     continue;
//                 case "4":
//                     await AtualizarCatalogo(catalogoService);
//                     continue;
//                 case "5":
//                     await DeletarCatalogo(catalogoService);
//                     continue;
//                 case "6":
//                     await AdicionarLivroCatalogo(catalogoService);
//                     continue;
//                 case "7":
//                     await RemoverLivroCatalogo(catalogoService);
//                     continue;
//                 case "0":
//                     return;
//                 default:
//                     Console.WriteLine("Opção inválida.");
//                     continue;    
//             }
//         }
//     }

//     static async Task AdicionarCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("Nome do Catálogo: ");
//         var nome = Console.ReadLine();

//         Console.Write("Gênero do Catálogo: ");
//         var genero = Console.ReadLine();

//         var catalogo = new Catalogo
//         {
//             Nome = nome,
//             Genero = genero
//         };

//         var resultado = await catalogoService.AdicionarCatalogo(catalogo);
//         Console.WriteLine($"Catálogo {resultado.Nome} adicionado com sucesso!");
//         Console.WriteLine($"Catálogo criado com o ID {resultado.Id}");
//     }

//     static async Task BuscarCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("Digite o ID do Catálogo: ");
//         var id = int.Parse(Console.ReadLine());
//         var catalogo = await catalogoService.BuscarCatalogo(id);

//         Console.WriteLine($"ID: {catalogo.Id}");
//         Console.WriteLine($"Nome: {catalogo.Nome}");
//         Console.WriteLine($"Gênero: {catalogo.Genero}");
//         foreach (var livro in catalogo.Livros)
//         {
//             Console.WriteLine($"Livro ID: {livro.Id}, Título: {livro.Titulo}, Autor: {livro.Autor}");
//         }
//     }

//     static async Task BuscarTodosCatalogos(CatalogoService catalogoService)
//     {
//         var catalogos = await catalogoService.BuscarTodosCatalogos();

//         foreach (var catalogo in catalogos)
//         {
//             Console.WriteLine($"ID: {catalogo.Id}");
//             Console.WriteLine($"Nome: {catalogo.Nome}");
//             Console.WriteLine($"Gênero: {catalogo.Genero}");
//         }
//     }

//     static async Task AtualizarCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("Digite o ID do Catálogo a ser atualizado: ");
//         var id = int.Parse(Console.ReadLine());

//         var catalogoExistente = await catalogoService.BuscarCatalogo(id);
//         if (catalogoExistente == null)
//         {
//             Console.WriteLine("Catálogo não encontrado.");
//             return;
//         }

//         Console.Write("Novo Nome(deixe em branco para não alterar): ");
//         var nome = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(nome)) catalogoExistente.Nome = nome;

//         Console.Write("Novo Gênero: ");
//         var genero = Console.ReadLine();
//         if (!string.IsNullOrWhiteSpace(genero)) catalogoExistente.Genero = genero;

//         var resultado = await catalogoService.AtualizarCatalogo(catalogoExistente);
//         Console.WriteLine(resultado != null ? "Catálogo atualizado com sucesso!" : "Erro ao atualizar o Catálogo.");
//     }

//     static async Task DeletarCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("Digite ID do Catálogo a ser deletado: ");
//         var id = int.Parse(Console.ReadLine());

//         var resultado = await catalogoService.DeletarCatalogo(id);
//         Console.WriteLine(resultado ? "Catálogo deletado com sucesso" : "Erro ao deletar Catálogo.");
//     }

//     static async Task AdicionarLivroCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("ID do Catálogo: ");
//         var catalogoId = int.Parse(Console.ReadLine());

//         Console.Write("ID do Livro: ");
//         var livroId = int.Parse(Console.ReadLine());

//         await catalogoService.AdicionarLivroCatalogo(catalogoId, livroId);
//         Console.WriteLine("Livro adicionado ao Catálogo com sucesso!");
//     }

//     static async Task RemoverLivroCatalogo(CatalogoService catalogoService)
//     {
//         Console.Write("ID do Catálogo: ");
//         var catalogoId = int.Parse(Console.ReadLine());

//         Console.Write("ID do Livro: ");
//         var livroId = int.Parse(Console.ReadLine());

//         await catalogoService.RemoverLivroCatalogo(catalogoId, livroId);
//         Console.WriteLine("Livro removido do Catálogo com sucesso!");
//     }
// }

    static async Task Main(string [] args)
    {
        var connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123";
        var emprestimoRepository = new EmprestimoRepository(connectionString);
        var inventarioRepository = new InventarioRepository(connectionString);
        var usuarioRepository = new UsuarioRepository(connectionString);
        var emprestimoService = new EmprestimoService(emprestimoRepository, inventarioRepository, usuarioRepository);

        while(true)
        {
            Console.WriteLine("1. Adicionar Empréstimo");
            Console.WriteLine("2. Buscar Empréstimo por ID");
            Console.WriteLine("3. Buscar Todos os Empréstimos");
            Console.WriteLine("4. Atualizar Status de Empréstimo");
            Console.WriteLine("5. Deletar Empréstimo");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    await AdicionarEmprestimo(emprestimoService);
                    continue;
                case "2":
                    await BuscarEmprestimo(emprestimoService);
                    continue;
                case "3":
                    await BuscarTodosEmprestimos(emprestimoService);
                    continue;
                case "4":
                    await AtualizarEmprestimo(emprestimoService);
                    continue;
                case "5":
                    await DeletarEmprestimo(emprestimoService);
                    continue;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static async Task AdicionarEmprestimo(EmprestimoService emprestimoService)
    {
        Console.Write("ID do Usuário: ");
        var usuarioId = int.Parse(Console.ReadLine());

        Console.Write("ID do Inventário: ");
        var inventarioId = int.Parse(Console.ReadLine());

        var emprestimo = new Emprestimo
        {
            UsuarioId = usuarioId,
            InventarioId = inventarioId
        };
        
        var novoEmprestimo = await emprestimoService.AdicionarEmprestimo(emprestimo);
        Console.WriteLine($"Empréstimo realizado com sucesso! ID: {novoEmprestimo.Id}");
    }

    static async Task BuscarEmprestimo(EmprestimoService emprestimoService)
    {
        Console.WriteLine("Digite o ID do Empréstimo: ");
        var emprestimoId = int.Parse(Console.ReadLine());

        var emprestimo = await emprestimoService.BuscarEmprestimo(emprestimoId);
        if (emprestimo != null)
        {
            Console.WriteLine($"ID: {emprestimo.Id}, Usuário: {emprestimo.UsuarioId}, Livro: {emprestimo.InventarioId}, Status: {emprestimo.Status}");
        }
        else
        {
            Console.WriteLine("Empréstimo não encontrado.");
        }
    }

    static async Task BuscarTodosEmprestimos(EmprestimoService emprestimoService)
    {
        var emprestimos = await emprestimoService.BuscarTodosEmprestimos();
        foreach (var emprestimo in emprestimos)
        {
            Console.WriteLine($"ID: {emprestimo.Id}, Usuário: {emprestimo.UsuarioId}, Livro: {emprestimo.InventarioId}, Status: {emprestimo.Status}");
        }
    }

    static async Task AtualizarEmprestimo(EmprestimoService emprestimoService)
    {
        Console.Write("Digite o ID do Empréstimo: ");
        var emprestimoId = int.Parse(Console.ReadLine());

        Console.Write("Novo Status (Pendente/Atrasado/Devolvido): ");
        var novoStatus = Console.ReadLine();

        var emprestimoAtualizado = await emprestimoService.AtualizarEmprestimo(emprestimoId, novoStatus);
        Console.WriteLine("Status do empréstimo atualizado com sucesso!");
    }

    static async Task DeletarEmprestimo(EmprestimoService emprestimoService)
    {
        Console.Write("Digite o ID Empréstimo a ser deletado: ");
        var emprestimoId = int.Parse(Console.ReadLine());

        var sucesso = await emprestimoService.DeletarEmprestimo(emprestimoId);
        Console.WriteLine(sucesso ? "Empréstimo deletado com sucesso!" : "Erro ao deletar o empŕestimo.");
    }

}
