using System;

namespace ComeçandoOO
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }       
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime Validade { get; set; }

        public Produto(int idProduto, string nome, string descricao, string tipo, double valor, DateTime validade)
        {
            IdProduto = idProduto;
            Nome = nome;
            Descricao = descricao;
            Tipo = tipo;
            Valor = valor;
            Validade = validade;
        }

        public bool IsProdutoValido()
        {
            return Validade > DateTime.Now;
        }

        public void AtualizarDataValidade(DateTime newDate)
        {
            Validade = newDate;
        }
    }
}
