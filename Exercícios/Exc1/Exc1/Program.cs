using System;
using System.Collections.Generic;
using System.IO;

namespace Exc1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Curso Impacta\projetos-git\course-impacta\Exercícios\";

            try
            {
                Console.WriteLine("Nome do arquivo a ser criado:");
                var name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Nome inválido. Refaça o processo");
                    return;
                }

                string linha, finish;
                bool stopProcess = false;
                List<string> linhas = new List<string>();

                do
                {
                    Console.WriteLine("Digite a linha para inserção:");
                    linha = Console.ReadLine();

                    if (!string.IsNullOrEmpty(linha) || !string.IsNullOrWhiteSpace(linha))
                    {
                        linhas.Add(linha);
                    }

                    Console.Write("Concluiu o preenchimento do arquivo (S - Sim/N - Nao)? ");
                    finish = Console.ReadLine();

                    if (finish.Trim().ToUpper() == "S" || finish.Trim().ToUpper() == "SIM")
                    {
                        stopProcess = true;
                    }
                } while (stopProcess == false);

                if (linhas.Count > 0)
                {
                    using (StreamWriter sw = File.CreateText($"{path}{name}.txt"))
                    {
                        foreach (var l in linhas)
                        {
                            sw.WriteLine(l);
                        }
                    }
                }
                Console.WriteLine($"\nArquivo {name} criado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
            }
        }
    }
}
