using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class Controller
    {
        public Estoque estoque_controller = null;

        public int check_criaEstoque()
        {
            if (estoque_controller == null)
            {
                Console.WriteLine("Estoque não criado!");
                return 0;
            }
            else
            {
                if (estoque_controller.ingrediente.Count == 0)
                {
                    Console.WriteLine("Estoque vazio!");
                    return 2;
                }
                return 1;
            }
        }

        public void criarEstoque() //Singleton para a criação de somente um estoque
        {
            
            if (check_criaEstoque() == 0)
            {
                estoque_controller = new Estoque();

                Console.Write("INGREDIENTES (EM UNIDADES):\n");

                foreach (KeyValuePair<int, Ingrediente> ing in estoque_controller.ingrediente)
                {
                    Console.Write("{0}: \n", ing.Value.nome);

                    Console.Write("\tQuantidade quem já tem: ");
                    ing.Value.qtd = int.Parse(Console.ReadLine());

                    Console.Write("\tLimite do ingrediente no estoque: ");
                    ing.Value.limit = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                }

                Console.WriteLine("\nEstoque criado com sucesso");
            }
            else
            {
                Console.WriteLine("Estoque já criado!");
                return;
            }
        }

        public void visualizarEstoque()
        {
            if (check_criaEstoque() == 1)
            {
                foreach (Ingrediente strValue in estoque_controller.ingrediente.Values)
                {
                    Console.WriteLine("{0}: {1}", strValue.nome, strValue.qtd); ;
                }
            }
            else
            {
                return;
            }
        }

        public void completarEstoque() //Facede auto-preencher estoque
        {
            if (check_criaEstoque() == 1)
            {
                foreach (Ingrediente strValue in estoque_controller.ingrediente.Values)
                {
                    strValue.qtd = strValue.limit;
                }
                Console.WriteLine("Estoque completo");
            }
            else
            {
                return;
            }
        }

        public void addIngrediente()
        {
            if (check_criaEstoque() == 2 || check_criaEstoque() == 1)
            {
                Console.WriteLine("Nome ingrediente: ");
                string nome = Console.ReadLine();

                Console.WriteLine("\nQuantidade que já tem: ");
                int qtd = int.Parse(Console.ReadLine());

                Console.WriteLine("\nLimite do ingrediente no estoque: ");
                int limit = int.Parse(Console.ReadLine());

                estoque_controller.ingrediente.Add(estoque_controller.ingrediente.Count + 1, new Ingrediente(nome, qtd, limit));
                Console.WriteLine("\nIngrediente adicionado!");
                
            }
            else
            {
                return;
            }
        }

        public void removerIngrediente()
        {
            if (check_criaEstoque() == 1)
            {
                foreach (KeyValuePair<int, Ingrediente> ing in estoque_controller.ingrediente)
                {
                    Console.WriteLine("{0} - {1}", ing.Key+1,ing.Value.nome);
                }

                Console.Write("\nQual ingrediente deseja remover (digite um número): ");
                estoque_controller.ingrediente.Remove(int.Parse(Console.ReadLine())-1);

                Console.WriteLine("\nIngrediente removido!");

            }
            else
            {
                return;
            }
        }

        public void esvaziarEstoque()
        {
            if (check_criaEstoque() == 1)
            {
                estoque_controller.ingrediente.Clear();
            }
            else
            {
                return;
            }
        }
    }
}
