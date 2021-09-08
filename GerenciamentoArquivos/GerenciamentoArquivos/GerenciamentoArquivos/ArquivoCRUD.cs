using System;
using System.IO;
using System.Collections.Generic;

namespace GerenciamentoArquivos
{
    class ArquivoCRUD
    {
        private string OriginPath = @"C:\Curso Impacta\projetos-git\course-impacta\GerenciamentoArquivos\";
        private string CompletePath;
        private string Nome;

        public ArquivoCRUD(string nome)
        {
            Nome = nome;
            CompletePath = OriginPath + Nome;
        }

        public void DeletarArquivo()
        {
            if (File.Exists(CompletePath))
            {
                File.Delete(CompletePath);

                if (!File.Exists(CompletePath))
                {
                    Console.WriteLine($"Arquivo {Nome} deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Arquivo {Nome} não pode ser deletado");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} não existe na pasta de gerenciamento");
            }
        }

        public void ListarArquivo()
        {
            if (File.Exists(CompletePath))
            {
                using (StreamReader sr = File.OpenText(CompletePath))
                {
                    string linha;
                    int index = 1;

                    Console.WriteLine($"\n\nIniciando leitura do arquivo {Nome}");
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Linha: {index++} - Conteúdo: {linha}");
                    }

                    Console.WriteLine($"Arquivo {Nome} lido com sucesso!");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} não existe na pasta de gerenciamento");
            }
        }

        public void CriarArquivo()
        {
            if (!File.Exists(CompletePath))
            {
                EfetuarCapturaLinhasParaArquivo(null);
                Console.WriteLine($"Arquivo {Nome} criado e preenchido com sucesso!");
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} já existe na pasta de gerenciamento");
            }
        }

        public void AtualizarArquivo()
        {
            if (File.Exists(CompletePath))
            {
                List<string> jaExistentes = new List<string>();
                using (StreamReader sr = File.OpenText(CompletePath))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        jaExistentes.Add(linha);
                    }
                }
                EfetuarCapturaLinhasParaArquivo(jaExistentes);
                Console.WriteLine($"Arquivo {Nome} atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} já existe na pasta de gerenciamento");
            }
        }

        private void EfetuarCapturaLinhasParaArquivo(List<string> jaExistentes)
        {
            List<string> linhas;
            if (jaExistentes != null && jaExistentes.Count > 0)
            {
                linhas = jaExistentes;
            }
            else
            {
                linhas = new List<string>();
            }

            string linha, finish;
            bool stopProcess = false;

            do
            {
                Console.WriteLine("Favor informa a linha a ser incluída no arquivo (Enter para a próxima instrução):");
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

            using (StreamWriter sw = File.CreateText(CompletePath))
            {
                foreach (var l in linhas)
                {
                    sw.WriteLine(l);
                }
            }
        }
    }
}
