using Biblioteca.Entidades; 

class Program
{
       static string connectionString = "server=localhost;port=3307;database=app_db;user=app_user;password=user123";

       static async Task Main(string[] args)
       {
            while (true)
            {
                Console.WriteLine("\n\n==== GERENCIADOR DE BIBLIOTECA ====");
                Console.WriteLine("1. Usuários");
                Console.WriteLine("2. Livros");
                Console.WriteLine("3. Inventário");
                Console.WriteLine("4. Catálogos");
                Console.WriteLine("5. Empréstimos");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await MenuUsuarios();
                        break;
                    case "2":
                        await MenuLivros();
                        break;
                    case "3":
                        await MenuInventario();
                        break;
                    case "4":
                        await MenuCatalogo();
                        break;
                    case "5":
                        await MenuEmprestimo();
                        break;
                    case "0":
                        Console.WriteLine("Encenrrando o sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break; 
                }
            }
       }

       static async Task MenuUsuarios()
       {
            var usuarioRepository = new UsuarioRepository(connectionString);
            var usuarioService = new UsuarioService(usuarioRepository);

            while (true)
            {
                
                Console.WriteLine("\n\n==== MENU DE USUÁRIO ====");
                Console.WriteLine("1. Adicionar Usuário");
                Console.WriteLine("2. Buscar Usuário por ID");
                Console.WriteLine("3. Listar Todos os Usuários");
                Console.WriteLine("4. Atualizar Usuário");
                Console.WriteLine("5. Deletar Usuário");
                Console.WriteLine("0. Voltar ao Menu Principal");
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
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
       }

       static async Task MenuLivros()
       {
            var livroRepository = new LivroRepository(connectionString);
            var livroService = new LivroService(livroRepository);

            while (true)
            {
                Console.WriteLine("\n\n==== MENU DE LIVROS ====");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Buscar Livro por ID");
                Console.WriteLine("3. Listar Todos os Livros");
                Console.WriteLine("4. Atualizar Livro");
                Console.WriteLine("5. Deletar Livro");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await AdicionarLivro(livroService);
                        continue;
                    case "2":
                        await BuscarLivro(livroService);
                        continue;
                    case "3":
                        await BuscarTodosLivros(livroService);
                        continue;
                    case "4":
                        await AtualizarLivro(livroService);
                        continue;
                    case "5": 
                        await DeletarLivro(livroService);                     
                        continue;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();        
            }
       }

       static async Task MenuInventario()
       {
            var inventarioRepository = new InventarioRepository(connectionString);
            var livroRepository = new LivroRepository(connectionString);
            var inventarioService = new InventarioService(inventarioRepository, livroRepository);

            while (true)
            {
                Console.WriteLine("\n\n==== MENU DE INVENTÁRIO ====");
                Console.WriteLine("1. Adicionar Livro ao Inventário");
                Console.WriteLine("2. Buscar Livro no Inventário");
                Console.WriteLine("3. Buscar todos Livros no Inventário");
                Console.WriteLine("4. Atualizar Livro do Inventário");
                Console.WriteLine("5. Deletar Livro do Inventário");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await AdicionarInventario(inventarioService);
                        continue;
                    case "2":
                        await BuscarInventario(inventarioService);
                        continue;
                    case "3":
                        await BuscarTodosInventarios(inventarioService);
                        continue;
                    case "4":
                        await AtualizarInventario(inventarioService);
                        continue;
                    case "5":
                        await DeletarInventario(inventarioService);
                        continue;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                    }
                        
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
       }

       static async Task MenuCatalogo()
       {
            var catalogoRepository = new CatalogoRepository(connectionString);
            var livroRepository = new LivroRepository(connectionString);
            var catalogoService = new CatalogoService(catalogoRepository, livroRepository);

            while (true)
            {
                Console.WriteLine("\n\n==== MENU DE CATÁLOGO ====");
                Console.WriteLine("1. Adicionar Catalogo");
                Console.WriteLine("2. Buscar Catalogo");
                Console.WriteLine("3. Buscar todos Catalogos");
                Console.WriteLine("4. Atualizar Catalogo");
                Console.WriteLine("5. Deletar Catalogo");
                Console.WriteLine("6. Adicionar Livro ao Catalogo");
                Console.WriteLine("7. Remover Livro do Catalogo");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await AdicionarCatalogo(catalogoService);
                        continue;
                    case "2":
                        await BuscarCatalogo(catalogoService);
                        continue;
                    case "3":
                        await BuscarTodosCatalogos(catalogoService);
                        continue;
                    case "4":
                        await AtualizarCatalogo(catalogoService);
                        continue;
                    case "5":
                        await DeletarCatalogo(catalogoService);
                        continue;
                    case "6":
                        await AdicionarLivroCatalogo(catalogoService);
                        continue;
                    case "7":
                        await RemoverLivroCatalogo(catalogoService);
                        continue;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
       }

       static async Task MenuEmprestimo()
       {
            var emprestimoRepository = new EmprestimoRepository(connectionString);
            var inventarioRepository = new InventarioRepository(connectionString);
            var usuarioRepository = new UsuarioRepository(connectionString);
            var emprestimoService = new EmprestimoService(emprestimoRepository, inventarioRepository, usuarioRepository);

            while (true)
            {
                Console.WriteLine("\n\n==== MENU DE EMPRÉSTIMO ====");
                Console.WriteLine("1. Adicionar Empréstimo");
                Console.WriteLine("2. Buscar Empréstimo por ID");
                Console.WriteLine("3. Buscar Todos os Empréstimos");
                Console.WriteLine("4. Atualizar Status de Empréstimo");
                Console.WriteLine("5. Deletar Empréstimo");
                Console.WriteLine("0. Voltar ao Menu Principal");
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
                
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
       }

    static async Task AdicionarUsuario(UsuarioService usuarioService)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarUsuario(UsuarioService usuarioService)
    {
        try
        {
            Console.WriteLine("Digite o ID do Usuário: ");
            var id = int.Parse(Console.ReadLine());
            var usuario = await usuarioService.BuscarUsuario(id);

            Console.WriteLine($"\nID: {usuario.Id}");
            Console.WriteLine($"\nNome: {usuario.Nome}");
            Console.WriteLine($"\nIdade: {usuario.Idade}");
            Console.WriteLine($"\nData de Nascimento: {usuario.DataDeNascimento}");
            Console.WriteLine($"\nCPF: {usuario.Cpf}");
            Console.WriteLine($"\nTelefone: {usuario.Telefone}");
            Console.WriteLine($"\nEmail: {usuario.Email}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }        
    }

    static async Task BuscarTodosUsuarios(UsuarioService usuarioService)
    {
        try
        {
            var usuarios = await usuarioService.BuscarTodosUsuarios();

            foreach (var usuario in usuarios)
            {   
                Console.WriteLine($"\nID: {usuario.Id}, Nome: {usuario.Nome}, Idade: {usuario.Idade}, Data de Nascimento: {usuario.DataDeNascimento}, CPF: {usuario.Cpf}, Telefone: {usuario.Telefone}, Email: {usuario.Email}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
     }

    static async Task AtualizarUsuario(UsuarioService usuarioService)
    {
        try
        {
            Console.Write("Digite o ID do usuário a ser atualizado: ");
            var id = int.Parse(Console.ReadLine());

            var usuarioExistente = await usuarioService.BuscarUsuario(id);

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
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task DeletarUsuario(UsuarioService usuarioService)
    {
        try
        {   Console.Write("Digite o ID do usuário a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            var sucesso = await usuarioService.DeletarUsuario(id);
            Console.WriteLine(sucesso ? "Usuário deletado com sucesso." : "Erro ao deletar usuário.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AdicionarLivro(LivroService livroService)
    {
        try
        {
            Console.Write("Título: ");
            var titulo = Console.ReadLine();

            Console.Write("Gênero: ");
            var genero = Console.ReadLine();

            Console.Write("Autor: ");
            var autor = Console.ReadLine();

            Console.Write("Número de Páginas: ");
            var numeroDePaginas = int.Parse(Console.ReadLine());

            Console.Write("Ano de Publicação: ");
            var anoPublicacao = int.Parse(Console.ReadLine());

            var livro = new Livro
            {
                Titulo = titulo,
                Genero = genero,
                Autor = autor,
                NumeroDePaginas = numeroDePaginas,
                AnoPublicacao = anoPublicacao
            };

            var resultado = await livroService.AdicionarLivro(livro);
            Console.WriteLine($"Livro adicionado com ID: {resultado.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarLivro(LivroService livroService)
    {
        try
        {
            Console.Write("Digite o ID do livro: ");
            var id = int.Parse(Console.ReadLine());
            var livro = await livroService.BuscarLivro(id);

            Console.WriteLine($"\nID: {livro.Id}"); 
            Console.WriteLine($"\nTítulo: {livro.Titulo}"); 
            Console.WriteLine($"\nGênero: {livro.Genero}"); 
            Console.WriteLine($"\nAutor: {livro.Autor}"); 
            Console.WriteLine($"\nPáginas: {livro.NumeroDePaginas}"); 
            Console.WriteLine($"\nAno: {livro.AnoPublicacao}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarTodosLivros(LivroService livroService)
    {
        try
        {
            var livros = await livroService.BuscarTodosLivros();

            foreach (var livro in livros)
            {
                Console.WriteLine($"\nID: {livro.Id}, Título: {livro.Titulo}, Gênero: {livro.Genero}, Autor: {livro.Autor}, Páginas: {livro.NumeroDePaginas}, Ano: {livro.AnoPublicacao}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AtualizarLivro(LivroService livroService)
    {
        try
        {
            Console.Write("Digite o ID do livro a ser atualizado: ");
            var id = int.Parse(Console.ReadLine());

            var livroExistente = await livroService.BuscarLivro(id);

            Console.Write("Novo Título (deixe em branco para não alterar): ");
            var titulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(titulo)) livroExistente.Titulo = titulo;

            Console.Write("Novo Gênero (deixe em branco para não alterar): ");
            var genero = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genero)) livroExistente.Genero = genero;

            Console.Write("Novo Autor (deixe em branco para não alterar): ");
            var autor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(autor)) livroExistente.Autor = autor;

            Console.Write("Novo Número de Páginas (deixe em branco para não alterar): ");
            var paginas = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(paginas)) livroExistente.NumeroDePaginas = int.Parse(paginas);

            Console.Write("Novo Ano de Publicação (deixe em branco para não alterar): ");
            var ano = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ano)) livroExistente.AnoPublicacao = int.Parse(ano);

            await livroService.AtualizarLivro(livroExistente);
            Console.WriteLine("Livro atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }    
    }

    static async Task DeletarLivro(LivroService livroService)
    {
        try
        {
            Console.Write("Digite o ID do livro a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            var sucesso = await livroService.DeletarLivro(id);
            Console.WriteLine(sucesso ? "Livro deletado com sucesso" : "Erro ao deletar livro");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
    
    static async Task AdicionarInventario(InventarioService inventarioService)
    {
        try
        {
            Console.Write("ID do Livro: ");
            var livroId = int.Parse(Console.ReadLine());

            Console.Write("Quantidade: ");
            var quantidade = int.Parse(Console.ReadLine());

            Console.Write("Estado: ");
            var estado = Console.ReadLine();

            var inventario = new Inventario
            {
                LivroId = livroId,
                Quantidade = quantidade,
                Estado = estado
            };

            var resultado = await inventarioService.AdicionarInventario(inventario);
            Console.WriteLine($"Inventário adicionado com o ID: {resultado.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }    
    }

    static async Task BuscarInventario(InventarioService inventarioService)
    {
        try
        {
            Console.Write("Digite o ID do Inventário: ");
            var id = int.Parse(Console.ReadLine());
            var inventario = await inventarioService.BuscarInventario(id);
            
            Console.WriteLine($"\nID: {inventario.Id}");
            Console.WriteLine($"\nID do Livro: {inventario.LivroId}"); 
            Console.WriteLine($"\nQuantidade: {inventario.Quantidade}");
            Console.WriteLine($"\nEstado: {inventario.Estado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarTodosInventarios(InventarioService inventarioService)
    {
        try
        {
            var inventarios = await inventarioService.BuscarTodosInventarios();

            foreach (var inventario in inventarios)
            {
                Console.WriteLine($"\nID: {inventario.Id}, ID do Livro: {inventario.LivroId}, Quantidade: {inventario.Quantidade}, Estado: {inventario.Estado}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AtualizarInventario(InventarioService inventarioService)
    {
        try
        {
            Console.Write("ID do Inventário: ");
            var id = int.Parse(Console.ReadLine());

            var inventarioExistente = await inventarioService.BuscarInventario(id);

            Console.Write("Nova Quantidade(deixe em branco para não alterar): ");
            var quantidade = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(quantidade)) inventarioExistente.Quantidade = int.Parse(quantidade);

            Console.Write("Novo Estado(deixe em branco para não alterar): ");
            var estado = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(estado)) inventarioExistente.Estado = estado;

            await inventarioService.AtualizarInventario(inventarioExistente);
            Console.WriteLine("Inventário atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task DeletarInventario(InventarioService inventarioService)
    {
        try
        {
            Console.Write("ID do Inventário: ");
            var id = int.Parse(Console.ReadLine());

            await inventarioService.DeletarInventario(id);
            Console.WriteLine("Item deletado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    } 

    static async Task AdicionarCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("Nome do Catálogo: ");
            var nome = Console.ReadLine();

            Console.Write("Gênero do Catálogo: ");
            var genero = Console.ReadLine();

            var catalogo = new Catalogo
            {
                Nome = nome,
                Genero = genero
            };

            var resultado = await catalogoService.AdicionarCatalogo(catalogo);
            Console.WriteLine($"Catálogo criado com o ID {resultado.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("Digite o ID do Catálogo: ");
            var id = int.Parse(Console.ReadLine());
            var catalogo = await catalogoService.BuscarCatalogo(id);

            Console.WriteLine($"\nID do Catálogo: {catalogo.Id}");
            Console.WriteLine($"\nNome do Cátalogo: {catalogo.Nome}");
            Console.WriteLine($"\nGênero do Catálogo: {catalogo.Genero}");
            
            foreach (var livro in catalogo.Livros)
            {
                Console.WriteLine($"\nLivro ID: {livro.Id}, Título: {livro.Titulo}, Autor: {livro.Autor}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarTodosCatalogos(CatalogoService catalogoService)
    {
        try
        {
            var catalogos = await catalogoService.BuscarTodosCatalogos();

            foreach (var catalogo in catalogos)
            {
                Console.WriteLine($"\nID: {catalogo.Id}, Nome: {catalogo.Nome}, Gênero: {catalogo.Genero}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AtualizarCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("Digite o ID do Catálogo a ser atualizado: ");
            var id = int.Parse(Console.ReadLine());

            var catalogoExistente = await catalogoService.BuscarCatalogo(id);

            Console.Write("Novo Nome(deixe em branco para não alterar): ");
            var nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome)) catalogoExistente.Nome = nome;

            Console.Write("Novo Gênero: ");
            var genero = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genero)) catalogoExistente.Genero = genero;

            await catalogoService.AtualizarCatalogo(catalogoExistente);
            Console.WriteLine("Catálogo atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task DeletarCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("Digite ID do Catálogo a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            var resultado = await catalogoService.DeletarCatalogo(id);
            Console.WriteLine(resultado ? "Catálogo deletado com sucesso" : "Erro ao deletar Catálogo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AdicionarLivroCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("ID do Catálogo: ");
            var catalogoId = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            var livroId = int.Parse(Console.ReadLine());

            await catalogoService.AdicionarLivroCatalogo(catalogoId, livroId);
            Console.WriteLine("Livro adicionado ao Catálogo com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task RemoverLivroCatalogo(CatalogoService catalogoService)
    {
        try
        {
            Console.Write("ID do Catálogo: ");
            var catalogoId = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            var livroId = int.Parse(Console.ReadLine());

            await catalogoService.RemoverLivroCatalogo(catalogoId, livroId);
            Console.WriteLine("Livro removido do Catálogo com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
 
    static async Task AdicionarEmprestimo(EmprestimoService emprestimoService)
    {
        try
        {
            Console.Write("ID do Usuário: ");
            var usuarioId = int.Parse(Console.ReadLine());

            Console.Write("ID do Inventário: ");
            var inventarioId = int.Parse(Console.ReadLine());

            Console.Write("Data de Devolução (yyyy-MM-dd HH:mm:ss): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataDevolucao))
            {
                Console.WriteLine("Data inválida. Certifique-se de usar o formato correto.");
                return;
            }

            var emprestimo = new Emprestimo
            {
                UsuarioId = usuarioId,
                InventarioId = inventarioId,
                DataDevolucao = dataDevolucao
            };
            
            var novoEmprestimo = await emprestimoService.AdicionarEmprestimo(emprestimo);
            Console.WriteLine($"Empréstimo realizado com sucesso! ID: {novoEmprestimo.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task BuscarEmprestimo(EmprestimoService emprestimoService)
    {
        try
        {
            Console.WriteLine("Digite o ID do Empréstimo: ");
            var emprestimoId = int.Parse(Console.ReadLine());
            var emprestimo = await emprestimoService.BuscarEmprestimo(emprestimoId);
                    
            Console.WriteLine($"\nID: {emprestimo.Id}");
            Console.WriteLine($"\nUsuário: {emprestimo.UsuarioId}");
            Console.WriteLine($"\nLivro: {emprestimo.InventarioId}");
            Console.WriteLine($"\nData do Empréstimo: {emprestimo.DataEmprestimo}");
            Console.WriteLine($"\nData da Devolução: {emprestimo.DataDevolucao}");
            Console.WriteLine($"\nStatus: {emprestimo.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        } 
    }

    static async Task BuscarTodosEmprestimos(EmprestimoService emprestimoService)
    {
        try
        {
            var emprestimos = await emprestimoService.BuscarTodosEmprestimos();
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"\nID: {emprestimo.Id}, Usuário ID: {emprestimo.UsuarioId}, Inventário ID: {emprestimo.InventarioId}, Data do Empréstimo: {emprestimo.DataEmprestimo}, Data da Devolução: {emprestimo.DataDevolucao}, Status: {emprestimo.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task AtualizarEmprestimo(EmprestimoService emprestimoService)
    {
        try
        {
            Console.Write("Digite o ID do Empréstimo: ");
            var emprestimoId = int.Parse(Console.ReadLine());

            Console.Write("Novo Status (Pendente/Atrasado/Devolvido): ");
            var novoStatus = Console.ReadLine();

            await emprestimoService.AtualizarEmprestimo(emprestimoId, novoStatus);
            Console.WriteLine("Status do empréstimo atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task DeletarEmprestimo(EmprestimoService emprestimoService)
    {
        try
        {
            Console.Write("Digite o ID Empréstimo a ser deletado: ");
            var emprestimoId = int.Parse(Console.ReadLine());

            var sucesso = await emprestimoService.DeletarEmprestimo(emprestimoId);
            Console.WriteLine(sucesso ? "Empréstimo deletado com sucesso!" : "Erro ao deletar o empŕestimo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}