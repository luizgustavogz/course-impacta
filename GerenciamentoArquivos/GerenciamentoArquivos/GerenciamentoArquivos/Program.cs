using System;
using System.IO;

namespace GerenciamentoArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Nome do arquivo a ser gerenciado (Ex: nome.txt/nome.csv)");
                var nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome) ||
                    nome.Length < 5 || (!nome.Contains(".txt") && !nome.Contains(".csv")))
                {
                    Console.WriteLine("Nome inválido, refaça a operação");
                    return;
                }

                Console.Write("\nOperação a relizar (1 - Deletar, 2 - Criar, 3 - Atualizar, 4 - Selecionar): ");
                var opTxt = Console.ReadLine();
                int op = int.Parse(opTxt);

                var arquivo = new ArquivoCRUD(nome);
                switch (op)
                {
                    case 1:
                        arquivo.DeletarArquivo();
                        break;
                    case 2:
                        arquivo.CriarArquivo();
                        break;
                    case 3:
                        arquivo.AtualizarArquivo();
                        break;
                    case 4:
                        arquivo.ListarArquivo();
                        break;
                    default:
                        throw new ArgumentException("Valor informado não é um número disponível, refaça a operação");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Número informado nulo, refaça a operação");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Número informado não é um inteiro, refaça a operação");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Número informado é maior que um inteiro, refaça a operação");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
