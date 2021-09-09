using System;
using System.Collections.Generic;
using System.IO;

namespace Exc1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Curso Impacta\projetos-git\course-impacta\GerenciamentoArquivos\exc1.txt";
            List<string> linhas = new List<string>();

            string linha, finish;
            bool stopProcess = false;

            try
            {
                if (!File.Exists(path))
                {
                    do
                    {
                        Console.WriteLine("Digite a linha:");
                        linha = Console.ReadLine();

                        if (!string.IsNullOrEmpty(linha) || !string.IsNullOrEmpty(linha))
                        {
                            Console.Write("Concluiu o preenchimento do arquivo (S - Sim/N - Nao)? ");
                            finish = Console.ReadLine();

                            if (finish.Trim().ToUpper() == "S" || finish.Trim().ToUpper() == "SIM")
                            {
                                stopProcess = true;
                            }
                            linhas.Add(linha);
                        }
                    } while (stopProcess == false);

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        foreach (var l in linhas)
                        {
                            sw.WriteLine(l);
                        }
                    }

                    Console.WriteLine("\nArquivo criado com sucesso!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
