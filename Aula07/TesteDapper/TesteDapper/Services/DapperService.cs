using TesteDapper.Models;
using TesteDapper.Extensions;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace TesteDapper.Services
{
    class DapperService
    {
        private string Conexao;

        public DapperService(string conexao)
        {
            Conexao = conexao;
        }

        public void Select()
        {
            using (var db = new SqlConnection(Conexao))
            {
                var alunos = db.Query<Aluno>("Select Id, Nome, DataDeNascimento From tblAluno").ToList();

                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Id {aluno.Id} - Aluno: {aluno.Nome} - Data de Nascimento: {aluno.DataDeNascimento.FormatarDataSistema()}");
                }
            }
        }

        public void Insert()
        {
            var aluno = ObterDadosAluno();

            if (aluno == null)
            {
                return;
            }

            using (var db = new SqlConnection(Conexao))
            {
                var query = @"Insert into tblAluno values (@Nome, @DataDeNascimento)";
                db.Execute(query, aluno);

                Console.WriteLine("\nAluno criado com sucesso!");
            }
        }

        public void Update()
        {
            int id = CapturarInformacoesInt("Id", null, null);
            if (id == 0) { return; }

            var aluno = ObterDadosAluno();

            if (aluno == null)
            {
                return;
            }

            aluno.Id = id;

            using (var db = new SqlConnection(Conexao))
            {
                var query = @"UPDATE tblAluno SET Nome=@Nome, DataDeNascimento=@DataDeNascimento WHERE Id=@Id";
                db.Execute(query, aluno);

                Console.WriteLine("\nAluno atualizado com sucesso!");
            }
        }

        public void Delete()
        {
            int id = CapturarInformacoesInt("Id", null, null);
            if (id == 0) { return; }

            using (var db = new SqlConnection(Conexao))
            {
                var query = @"DELETE FROM tblAluno WHERE Id=" + id;
                db.Execute(query);

                Console.WriteLine("\nAluno removido com sucesso!");
            }
        }

        private Aluno ObterDadosAluno()
        {
            Console.Write("Informe qual o nome do aluno atualizado: ");
            var nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome do aluno é obrigatório");
                return null;
            }

            var diaNascimento = CapturarInformacoesInt("Dia de nascimento", 1, 31);
            if (diaNascimento == 0) { return null; }
            var mesNascimento = CapturarInformacoesInt("Mês de nascimento", 1, 12);
            if (mesNascimento == 0) { return null; }
            var anoNascimento = CapturarInformacoesInt("Ano de nascimento", 1901, 2100);
            if (anoNascimento == 0) { return null; }

            var aluno = new Aluno()
            {
                Nome = nome,
                DataDeNascimento = new DateTime(anoNascimento, mesNascimento, diaNascimento)
            };

            return aluno;
        }

        private int CapturarInformacoesInt(string tipoInfo, int? valorMinimo, int? valorMaximo)
        {
            var msg = $"Informe qual o {tipoInfo} do usuário";
            if (valorMinimo != null || valorMaximo != null)
            {
                msg += $" ({valorMinimo} a {valorMaximo}):";
            }
            else
            {
                msg += ":";
            }

            Console.WriteLine(msg);
            var infoStr = Console.ReadLine();
            if (string.IsNullOrEmpty(infoStr) || string.IsNullOrWhiteSpace(infoStr))
            {
                Console.WriteLine($"{tipoInfo} do aluno é obrigatório");
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
                Console.WriteLine($"{tipoInfo} do aluno não é válido");
                return 0;
            }
        }
    }
}
