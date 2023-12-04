using ProjetoAula04.Entities;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    /// <summary>
    /// Classe de controle de aplicação para os eventos de Cliente
    /// </summary>
    public class ClienteController
    {
        public void ManterClientes()
        {
            try
            {
                Console.WriteLine("\n *** CONTROLE DE CLIENTES *** \n");
                Console.WriteLine("(1) - CADASTRAR CLIENTE");
                Console.WriteLine("(2) - ATUALIZAR CLIENTE");
                Console.WriteLine("(3) - EXCLUIR CLIENTE");
                Console.WriteLine("(4) - CONSULTAR TODOS OS CLIENTES");
                Console.WriteLine("(5) - CONSULTAR CLIENTES POR NOME");
                Console.Write("\n");

                Console.Write("Informe a ação desejada.....: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:
                        throw new Exception("\nOpção inválida.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }
            finally
            {
                Console.Write("\nDeseja continuar? (S,N): ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear(); //limpar o console
                    ManterClientes(); //recursividade
                }
                else
                    Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }

        //método privado para fazer o fluxo de cadastro do cliente
        private void CadastrarCliente()
        {
            var cliente = new Cliente();

            Console.WriteLine("\nCADASTRO DE CLIENTE\n");

            Console.Write("ENTRE COM O NOME DO CLIENTE.......: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("ENTRE COM O CPF DO CLIENTE........: ");
            cliente.Cpf = Console.ReadLine();

            Console.Write("ENTRE COM A DATA DE NASCIMENTO....: ");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            var clienteRepository = new ClienteRepository();
            clienteRepository.Create(cliente);

            Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!\n");

        }
    }
}
