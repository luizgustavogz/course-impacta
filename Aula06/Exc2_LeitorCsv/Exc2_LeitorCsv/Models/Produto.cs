using System;

namespace Exc2_LeitorCsv.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public DateTime DataDeValidade { get; set; }
        public double Valor { get; set; }
        public string Marca { get; set; }

        public Produto(string nome, DateTime dataDeValidade, double valor, string marca)
        {
            Nome = nome;
            DataDeValidade = dataDeValidade;
            Valor = valor;
            Marca = marca;
        }
    }
}
