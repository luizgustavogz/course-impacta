using TesteDapper.Models;
using TesteDapper.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace TesteDapper
{
    class Program
    {
        private static string conexao;

        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var configuration = builder.Build();
                conexao = configuration["ConnectionStrings:DefaultConnection"];

                if (string.IsNullOrEmpty(conexao) || string.IsNullOrWhiteSpace(conexao))
                {
                    Console.WriteLine("Arquivo de configuração (appsettings) não foi encontrado na pasta de binário");
                    return;
                }

                Console.WriteLine("Informe a operação a ser realizada:");
                Console.WriteLine("1 - Select\t2 - Create\t3 - Update\t4 - Delete");
                var opcaoStr = Console.ReadLine();
                var opcao = int.Parse(opcaoStr);

                switch (opcao)
                {
                    case 1:
                        DapperService.ConsultarLinhas(conexao);
                        break;
                    default:
                        Console.WriteLine("Opção informada não é válida");
                        break;
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Você informou um número inválido, tente novamente");
            }
            catch (FormatException)
            {
                Console.WriteLine("Você informou um número inválido, tente novamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu erro ao processar dados via Dapper: " + e.Message);
            }   
        }
    }
}
