using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class Ingrediente
    {
        public string nome { get; set; }
        public int qtd { get; set; }
        public int limit { get; set; }

        public Ingrediente(string nome, int qtd, int limit)
        {
            this.nome = nome;
            this.qtd = qtd;
            this.limit = limit;
        }
    }
}
