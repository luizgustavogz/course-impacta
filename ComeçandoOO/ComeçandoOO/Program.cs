using System;
using System.Collections.Generic;
using ComeçandoOO.Models;
using ComeçandoOO.Models.Pagamento;

namespace ComeçandoOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var newValidade = new DateTime(2021,5,10);
            Produto cafe = new Produto(1, "Café 3 Corações", "Café premium torrado", "Alimento", 9.90, new DateTime(2022,9,6));
            Produto leite = new Produto(2, "Leite UHT Integral", "Leite Integral pasteurizado", "Alimento", 6.70, new DateTime(2021,8,15));
            
            if (cafe.Valor > leite.Valor)
            {
                Console.WriteLine("Café está mais caro que o leite\n");
            } 
            else
            {
                Console.WriteLine("Leite está mais caro que o café\n");
            }

            if (!cafe.IsProdutoValido())
            {
                Console.WriteLine("Café vencido");
            }

            Console.WriteLine($"Café está na validade? {cafe.IsProdutoValido()}");
            Console.WriteLine($"Leite está na validade? {leite.IsProdutoValido()}");

            cafe.AtualizarDataValidade(newValidade);
            Console.WriteLine($"\nValidade do café atualizada! {newValidade}");
            Console.WriteLine($"Café ainda está na validade? {cafe.IsProdutoValido()}\n");

            Cliente cliente = new Cliente() {
                Id = 1,
                Nome = "Luiz",
                IsMaiorDeIdade = true
            };

            Funcionario funcionario = new Funcionario()
            {
                Id = 1,
                Nome = "Administrador",
                Demissao = null
            };

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(cliente);
            pessoas.Add(funcionario);

            foreach(var p in pessoas)
            {
                if (p is Cliente)
                {
                    Console.WriteLine($"Cliente: {p.Nome}, maior de idade? {((Cliente)p).IsMaiorDeIdade}\n");                    
                }
                else if (p is Funcionario)
                {
                    Console.WriteLine($"Funcionário: {p.Nome}, foi demitido? {((Funcionario)p).Demissao}\n");
                }
                else
                {
                    Console.WriteLine($"Pessoa: {p.Nome}");
                }
            }

            Console.WriteLine("Selecione a forma de pagamento (1 - Crédito, 2 - Débito, 3 - VA, 4 - Dinheiro, 5 - Pix):");
            var tipoDePagamentoString = Console.ReadLine();
            var tipoDePagamento = int.Parse(tipoDePagamentoString);

            FormaDePagamento pagamento;
            switch (tipoDePagamento) 
            {
                case 1:
                    pagamento = new CreditoImpl();
                    break;
                case 2:
                    pagamento = new DebitoImpl();
                    break;
                case 3:
                    pagamento = new VAImpl();
                    break;
                case 4:
                    pagamento = new Dinheiro();
                    break;
                case 5:
                    pagamento = new Pix();
                    break;
                default:
                    pagamento = null;
                    break;
            }

            if (pagamento == null)
            {
                Console.WriteLine("Forma de pagamento inválida, refaça o procedimento");
                return;
            }

            pagamento.EfetuarPagamento();
        }
    }
}
