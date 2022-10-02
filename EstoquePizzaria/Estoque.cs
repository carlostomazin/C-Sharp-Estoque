using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class Estoque
    {

        public Dictionary<int, Ingrediente> ingrediente = new Dictionary<int, Ingrediente>();
        public Estoque()
        {
            // Para efeito de teste o estoque será criado com alguns ingrediente.
            ingrediente.Add(1, new Ingrediente("Farinha de trigo", 0, 0));
            ingrediente.Add(2, new Ingrediente("Açucar", 0, 0));
/*            ingrediente.Add(3, new Ingrediente("Sal", 0, 0));
            ingrediente.Add(4, new Ingrediente("Fermento biológico", 0, 0));
            ingrediente.Add(5, new Ingrediente("Molho de tomate", 0, 0));
            ingrediente.Add(6, new Ingrediente("Queijo muçarela", 0, 0));
            ingrediente.Add(7, new Ingrediente("Tomate", 0, 0));
            ingrediente.Add(8, new Ingrediente("Orégano", 0, 0));*/

        }

    }
}
