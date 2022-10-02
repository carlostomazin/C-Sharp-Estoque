using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace EstoquePizzaria
{
    public class Controller
    {
        public Estoque estoque_controller = null;
        private IFormaPagamento formaPagamentoStratgy;
        private string estoqueNaoCriado = "Estoque não criado!";
        private string estoqueCriado = "Estoque já criado!";
        private string estoqueVazio = "Estoque está vazio!";

        public void check_formaPagamento(int qtd) //Strategy definir forma de pagamento
        {

            if (qtd < 10)
            {
                formaPagamentoStratgy = new FormaPagamentoPix();
                Console.WriteLine(formaPagamentoStratgy.formaPagamento());
                return;
            }

            formaPagamentoStratgy = new FormaPagamentoCartaoCredito();
            Console.WriteLine(formaPagamentoStratgy.formaPagamento());

        }

        public int check_criaEstoque()
        {
            int retorno;

            if (estoque_controller == null)
            {
                retorno =  0;
            }
            else
            {
                retorno = 1;
                if (estoque_controller.ingrediente.Count == 0)
                {
                    retorno = 2;
                }
            }

            return retorno;
        }

        public void criarEstoque() //Singleton para a criação de somente um estoque
        {

            if (check_criaEstoque() == 0)
            {
                estoque_controller = new Estoque();
                int somaQtd = 0;

                Console.Write("INGREDIENTES (EM UNIDADES):\n");

                foreach (KeyValuePair<int, Ingrediente> ing in estoque_controller.ingrediente)
                {
                    Console.Write("==> {0}: \n", ing.Value.nome);

                    Console.Write("Quantidade quem já tem: ");
                    ing.Value.qtd = int.Parse(Console.ReadLine());

                    Console.Write("Limite do ingrediente no estoque: ");
                    ing.Value.limit = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                    somaQtd =+ ing.Value.qtd;
                }


                Console.WriteLine("\nEstoque criado com sucesso");

                check_formaPagamento(somaQtd);
            }
            else
            {
                Console.WriteLine(estoqueCriado);
                return;
            }
        }

        public void esvaziarEstoque()
        {
            if (check_criaEstoque() == 1)
            {
                estoque_controller.ingrediente.Clear();
                Console.WriteLine("Estoque esvaziado com sucesso!");
            }
            else if (check_criaEstoque() == 2)
            {
                Console.WriteLine(estoqueVazio);
                return;
            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
        }

        public void visualizarEstoque()
        {

            if (check_criaEstoque() == 1)
            {
                foreach (Ingrediente ing in estoque_controller.ingrediente.Values)
                {
                    Console.WriteLine("{0}: {1}", ing.nome, ing.qtd); ;
                }
            }
            else if (check_criaEstoque() == 2)
            {
                Console.WriteLine(estoqueVazio);
                return;
            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
               
            
        }

        public void cadastrarIngrediente()
        {
            if (check_criaEstoque() == 1 || check_criaEstoque() == 2)
            {

                Console.Write("Nome ingrediente: ");
                string nome = Console.ReadLine();

                Console.Write("\nQuantidade que já tem: ");
                int qtd = int.Parse(Console.ReadLine());

                Console.Write("\nLimite do ingrediente no estoque: ");
                int limit = int.Parse(Console.ReadLine());

                estoque_controller.ingrediente.Add(estoque_controller.ingrediente.Count + 1, new Ingrediente(nome, qtd, limit));
                Console.WriteLine("\nIngrediente adicionado!");
                check_formaPagamento(qtd);

            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
        }

        public void removerIngrediente()
        {
            if (check_criaEstoque() == 1)
            {
                foreach (KeyValuePair<int, Ingrediente> ing in estoque_controller.ingrediente)
                {
                    Console.WriteLine("{0} - {1}", ing.Key + 1, ing.Value.nome);
                }

                Console.Write("\nQual ingrediente deseja remover (digite um número): ");
                estoque_controller.ingrediente.Remove(int.Parse(Console.ReadLine()) - 1);

                Console.WriteLine("\nIngrediente removido!");

            }
            else if (check_criaEstoque() == 2)
            {
                Console.WriteLine(estoqueVazio);
                return;
            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
        }

        public void adicionarIngrediente()
        {
            if (check_criaEstoque() == 1)
            {
                foreach (KeyValuePair<int, Ingrediente> ing in estoque_controller.ingrediente)
                {
                    Console.WriteLine("{0} - {1}", ing.Key, ing.Value.nome);
                }

                Console.Write("\nQual ingrediente deseja adicionar (digite um número): ");
                int ingrediente = int.Parse(Console.ReadLine());

                Console.Write("\nQual a quantide (digite um número): ");
                int qtd = int.Parse(Console.ReadLine());
                estoque_controller.ingrediente[ingrediente].qtd =+ qtd;

                Console.WriteLine("\nIngrediente adicionado!");
                check_formaPagamento(qtd);

            }
            else if (check_criaEstoque() == 2)
            {
                Console.WriteLine(estoqueVazio);
                return;
            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
        }

        public void completarEstoque() //Facede auto-preencher estoque
        {
            int somaQtd = 0;
            if (check_criaEstoque() == 1)
            {
                foreach (Ingrediente ing in estoque_controller.ingrediente.Values)
                {
                    ing.qtd = ing.limit;
                    somaQtd =+ ing.limit - ing.qtd;
                }
                Console.WriteLine("Estoque completo");
                check_formaPagamento(somaQtd);

            }
            else if (check_criaEstoque() == 2)
            {
                Console.WriteLine(estoqueVazio);
                return;
            }
            else
            {
                Console.WriteLine(estoqueNaoCriado);
                return;
            }
        }

    }
}
