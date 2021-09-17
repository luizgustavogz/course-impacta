using System;

namespace ComeçandoOO.Models.Pagamento
{
    class DebitoImpl : FormaDePagamento, ICartao
    {
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Cartão de Débito!");
        }

        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartão com Saldo!");
        }
    }
}
