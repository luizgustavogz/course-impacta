using System;

namespace ListagemDeProdutos.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeValidade { get; set; }
        public decimal Valor { get; set; }
    }
}
