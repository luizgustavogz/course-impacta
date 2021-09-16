using ListagemDeProdutos.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ListagemDeProdutos
{
    class Program
    {
        private static string conexao;

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
                    Console.WriteLine("String de conexão não encontrada");
                    return;
                }

                var produtos = ExecutarConsulta(conexao);

                Console.WriteLine("Informe a operação a ser feita:");
                Console.WriteLine("1 - Filtrar \t 2 - Ordenar \t 3 - Agrupar \t 4 - Selecionar");
                var operacao = CapturarInformacoesInt("operacao", 1, 4);

                Console.WriteLine("Informe o campo a ser feita a operação:");
                Console.WriteLine("1 - Id \t 2 - Nome \t 3 - Validade \t 4 - Valor");
                var campo = CapturarInformacoesInt("operacao", 1, 4);

                List<Produto> produtosFinal = new();
                switch (operacao)
                {
                    case 1:
                        produtosFinal = FiltrarLista(produtos, campo);
                        ExibirResultadoFinal(produtosFinal);
                        break;
                    case 2:
                        produtosFinal = OrdenarLista(produtos, campo);
                        ExibirResultadoFinal(produtosFinal);
                        break;
                    case 3:
                        AgruparLista(produtos, campo);
                        break;
                    case 4:
                        SelecionarLista(produtos, campo);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu erro ao executar operação, tente novamente.");
            }
        }

        private static void AgruparLista(IEnumerable<Produto> produtos, int campo)
        {
            switch (campo)
            {
                case 1:
                    var group = produtos.GroupBy(p => p.Id).ToList();
                    group.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Id {resultado.Key},Total de registro: {resultado.Count()}");
                    });
                    break;
                case 2:
                    var group2 = produtos.GroupBy(p => p.Nome).ToList();
                    group2.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Nome {resultado.Key},Total de registro: {resultado.Count()}");
                    });
                    break;
                case 3:
                    var group3 = produtos.GroupBy(p => p.DataDeValidade).ToList();
                    group3.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Validade {resultado.Key},Total de registro: {resultado.Count()}");
                    });
                    break;
                case 4:
                    var group4 = produtos.GroupBy(p => p.Valor).ToList();
                    group4.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Valor {resultado.Key},Total de registro: {resultado.Count()}");
                    });
                    break;
                default: return;
            }
        }

        private static void SelecionarLista(IEnumerable<Produto> produtos, int campo)
        {
            switch (campo)
            {
                case 1:
                    var result = produtos.Select(p => p.Id).ToList();
                    result.ForEach(resultado =>
                    {
                        Console.WriteLine($"Id {resultado}");
                    });
                    break;
                case 2:
                    var result2 = produtos.Select(p => p.Nome).ToList();
                    result2.ForEach(resultado =>
                    {
                        Console.WriteLine($"Nome {resultado}");
                    });
                    break;
                case 3:
                    var result3 = produtos.Select(p => p.DataDeValidade).ToList();
                    result3.ForEach(resultado =>
                    {
                        Console.WriteLine($"Validade: {resultado}");
                    });
                    break;
                case 4:
                    var result4 = produtos.Select(p => p.Valor).ToList();
                    result4.ForEach(resultado =>
                    {
                        Console.WriteLine($"Valor: {resultado}");
                    });
                    break;
                default: return;
            }
        }

        private static List<Produto> FiltrarLista(IEnumerable<Produto> produtos, int campo)
        {
            Console.WriteLine("Favor informe o valor a ser filtrado:");
            var valor = Console.ReadLine();

            switch (campo)
            {
                case 1:
                    var valorInt = int.Parse(valor);
                    return produtos.Where(p => p.Id == valorInt).ToList();
                case 2:
                    return produtos.Where(p => p.Nome.Contains(valor)).ToList();
                case 3:
                    var valorDateTime = DateTime.Parse(valor);
                    return (from produto in produtos
                            where produto.DataDeValidade == valorDateTime
                            select produto).ToList();
                case 4:
                    var valorDecimal = decimal.Parse(valor);
                    return (from produto in produtos
                            where produto.Valor == valorDecimal
                            select produto).ToList();
                default: return null;
            }
        }

        private static List<Produto> OrdenarLista(IEnumerable<Produto> produtos, int campo)
        {
            Console.WriteLine("Favor informe o tipo de ordenação");
            Console.WriteLine("1 - Crescente\t2 - Decrescente");
            var tipoDeOrdenacao = CapturarInformacoesInt("operacao", 1, 2);

            switch (campo)
            {
                case 1:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Id).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.Id).ToList();
                    }
                case 2:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Nome).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.Nome).ToList();
                    }
                case 3:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.DataDeValidade).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.DataDeValidade).ToList();
                    }
                case 4:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Valor).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.Valor).ToList();
                    }
                default: return null;
            }
        }

        private static IEnumerable<Produto> ExecutarConsulta(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                return db.Query<Produto>("Select Id, Nome, DataDeValidade, Valor From tblProduto");
            }
        }

        private static void ExibirResultadoFinal(List<Produto> listaFinal)
        {
            listaFinal.ForEach(produto =>
            {
                Console.WriteLine($"Id: {produto.Id} - Nome: {produto.Nome}" +
                    $" - Validade {produto.DataDeValidade.ToShortDateString()}" +
                    $" - Valor: {produto.Valor}");
            });

            //foreach(var produto in listaFinal)
            //{
            //    Console.WriteLine($"Id: {produto.Id} - Nome: {produto.Nome}" +
            //        $" - Validade {produto.DataDeValidade.ToShortDateString()}" +
            //        $" - Valor: {produto.Valor}");
            //}
        }

        private static int CapturarInformacoesInt(string tipoInfo, int? valorMinimo, int? valorMaximo)
        {
            var infoStr = Console.ReadLine();
            if (string.IsNullOrEmpty(infoStr) || string.IsNullOrWhiteSpace(infoStr))
            {
                Console.WriteLine($"{tipoInfo} é obrigatório");
                return 0;
            }

            int info;
            try
            {
                info = int.Parse(infoStr);

                if ((valorMinimo != null && info < valorMinimo) || (valorMaximo != null && info > valorMaximo))
                {
                    throw new Exception();
                }

                return info;
            }
            catch (Exception)
            {
                Console.WriteLine($"{tipoInfo} não é válido");
                return 0;
            }
        }
    }
}
