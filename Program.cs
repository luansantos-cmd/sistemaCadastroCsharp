using crud01.Services;
using crud01.Models;
using System;

class Program
{
    static void Main()
    {
        UsuarioService service = new UsuarioService();
        int opcao;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Remover");
            Console.WriteLine("0 - Sair");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    service.Cadastrar(new Usuario { Nome = nome, Email = email });
                    Console.WriteLine("Salvo!");
                    break;

                case 2:
                    var usuarios = service.Listar();
                    foreach (var u in usuarios)
                    {
                        Console.WriteLine($"{u.Id} - {u.Nome} - {u.Email}");
                    }
                    break;

                case 3:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    service.Remover(id);
                    Console.WriteLine("Removido!");
                    break;
            }

        } while (opcao != 0);
    }
}
