using BibliotecaApp.Models;
using System;

namespace BibliotecaApp.Services
{
    public class EmprestimoService
    {
        public void EfetuaEmpretimo(Inventario livro, Usuario usuario, DateTime dataEstimadaDevolucao)
        {
            if (livro.Disponivel)
            {
                livro.Disponivel = false;
                var emprestimo = new Emprestimo
                {
                    IdInventario = livro.Id,
                    IdUsuario = usuario.Id,
                    DataEmprestimo = DateTime.Now,
                    DataEstimadaDevolucao = dataEstimadaDevolucao
                };
                Console.WriteLine($"Livro '{livro.Id}' emprestado ao usuário {usuario.Nome}.");
            }
            else
            {
                Console.WriteLine("Livro não está disponível para empréstimo.");
            }
        }

        public void RecebeDevolucao(Inventario livro, Usuario usuario)
        {
            livro.Disponivel = true;
            Console.WriteLine($"Livro '{livro.Id}' devolvido pelo usuário {usuario.Nome}.");
        }
    }
}