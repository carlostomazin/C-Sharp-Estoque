using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class FormaPagamentoCartaoCredito : IFormaPagamento
    {
        public string formaPagamento()
        {
            return "Forma de pagamento: Cartão de Crédito!";
        }
    }
}
