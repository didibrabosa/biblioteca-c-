using BibliotecaApp.Models;
using BibliotecaApp.Services;



namespace BibliotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var livroCatalogo = new Catalogo {Id = 1, Titulo = "Harry Potter e a Pedra Filosofal", Autor = "JK Rowling", Ano = 1997, Genero = "Fantasia", Paginas = 223};
            var livroIventario = new Inventario {Id = 1, IdCatalogo = livroCatalogo.Id, Disponivel = true};

            var usuario = new Usuario {Id = 1, Nome = "Diego", Endereco = "Rua cinco de janeiro, 41", Email = "deigovasconcelosb@gmail.com", Telefone = "999999999", DataNascimento = new DateTime(2004, 07, 16)};

            var emprestimoService = new EmprestimoService();

            emprestimoService.EfetuaEmpretimo(livroIventario, usuario, DateTime.Now.AddDays(7));

            emprestimoService.RecebeDevolucao(livroIventario, usuario);
        }

    }
}