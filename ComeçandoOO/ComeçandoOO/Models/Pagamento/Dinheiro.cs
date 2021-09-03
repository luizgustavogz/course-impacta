using System;

namespace ComeçandoOO.Models.Pagamento
{
    class Dinheiro : FormaDePagamento
    {
        public override void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento efetuado com Dinheiro!");
        }
    }
}
