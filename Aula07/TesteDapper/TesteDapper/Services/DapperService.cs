using TesteDapper.Models;
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
        public static void Select(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                var alunos = db.Query<Aluno>("Select Id, Nome, DataDeNascimento From tblAluno").ToList();

                foreach(var aluno in alunos)
                {
                    Console.WriteLine($"Id {aluno.Id} - Aluno: {aluno.Nome} - Data de Nascimento: {aluno.DataDeNascimento.ToShortDateString()}");
                }
            }
        }
    }
}
