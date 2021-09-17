using System;

namespace ComeçandoOO.Models.Pagamento
{
    class VAImpl : FormaDePagamento, ICartao
    {
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Vale Alimentação!");
        }

        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartão com Saldo!");
        }
    }
}
