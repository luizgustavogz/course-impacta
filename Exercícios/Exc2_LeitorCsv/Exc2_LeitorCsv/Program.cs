using System;
using System.IO;
using System.Text;
using Exc2_LeitorCsv.Models;

namespace Exc2_LeitorCsv
{
    class Program
    {
        static string path = @"C:\Curso Impacta\projetos-git\course-impacta\Exercícios\Exc2_LeitorCsv\Planilhas";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Começando o processamento");

                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);

                    foreach (var arquivo in files)
                    {
                        if (arquivo.Contains(".csv"))
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine($"Iniciando leitura do arquivo {arquivo}");

                            using (StreamReader sr = new StreamReader(File.OpenRead(arquivo), Encoding.UTF8))
                            {
                                int numLinha = 1;
                                string linha = "";
                                string[] produtoLinha;
                                Produto produto;

                                string nome;
                                DateTime dataDeValidade;
                                string valorStr;
                                double valor;
                                string marca;

                                if (sr.ReadLine() != null)
                                {
                                    while ((linha = sr.ReadLine()) != null)
                                    {
                                        produtoLinha = linha.Split(";");
                                        if (produtoLinha.Length == 4
                                                && !string.IsNullOrEmpty(produtoLinha[1])
                                                && !string.IsNullOrWhiteSpace(produtoLinha[1])
                                                && !string.IsNullOrEmpty(produtoLinha[2])
                                                && !string.IsNullOrWhiteSpace(produtoLinha[2]))
                                        {
                                            nome = produtoLinha[0];
                                            dataDeValidade = DateTime.Parse(produtoLinha[1]);

                                            valorStr = produtoLinha[2].Replace("R$ ", "");
                                            valor = double.Parse(valorStr.Trim());
                                            marca = produtoLinha[3];

                                            produto = new Produto(nome, dataDeValidade, valor, marca);

                                            Console.WriteLine("Leitura da linha:" + numLinha++
                                                + $" - Nome: {produto.Nome} - Data de Validade: {produto.DataDeValidade}" +
                                                $" - Valor: {produto.Valor} - Marca: {produto.Marca}");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine($"Concluindo leitura do arquivo {arquivo}");
                            Console.WriteLine("--------------------------------");
                        }
                    }
                    Console.WriteLine("Fim do processamento");
                }
                Console.WriteLine($"Não existem arquivos .csv no diretório: {path}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
            }
        }
    }
}
