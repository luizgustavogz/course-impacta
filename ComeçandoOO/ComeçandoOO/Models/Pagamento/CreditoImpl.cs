using System;

namespace ComeçandoOO.Models.Pagamento
{
    class CreditoImpl : FormaDePagamento, ICartao
    {
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Cartão de Crédito!");
        }

        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartão com Saldo!");
        }
    }
}
