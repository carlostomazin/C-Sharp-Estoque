using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class Estoque
    {
        public Estoque estoque = null;

        public Dictionary<int, Ingrediente> ingrediente = new Dictionary<int, Ingrediente>();
        public Estoque()
        {
            // Para efeito de teste o estoque será criado com alguns ingrediente.
            ingrediente.Add(0, new Ingrediente("Farinha de trigo", 0, 0));
            ingrediente.Add(1, new Ingrediente("Açucar", 0, 0));
            ingrediente.Add(2, new Ingrediente("Sal", 0, 0));
            ingrediente.Add(3, new Ingrediente("Fermento biológico", 0, 0));
            ingrediente.Add(4, new Ingrediente("Molho de tomate", 0, 0));
            ingrediente.Add(5, new Ingrediente("Queijo muçarela", 0, 0));
            ingrediente.Add(6, new Ingrediente("Tomate", 0, 0));
            ingrediente.Add(7, new Ingrediente("Orégano", 0, 0));

        }

    }
}
