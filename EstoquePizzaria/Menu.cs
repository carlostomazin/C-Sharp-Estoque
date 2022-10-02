using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquePizzaria
{
    public class Menu
    {
        Controller controller = new Controller();

        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("===== CONTROLE DE ESTOQUE PIZZARIA =====");
            Console.WriteLine("\n");
            Console.WriteLine("1) Criar estoque");
            Console.WriteLine("2) Esvaziar estoque");
            Console.WriteLine("3) Visualizar estoque");
            Console.WriteLine("4) Completar todo estoque");
            Console.WriteLine("5) Adicionar um ingrediente");
            Console.WriteLine("6) Remover um ingrediente");
            Console.WriteLine("7) SAIR");
            Console.Write("\r\nSelecione uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    controller.criarEstoque();
                    DisplayResult();
                    return true;
                case "2":
                    Console.Clear();
                    controller.esvaziarEstoque();
                    DisplayResult();
                    return true;
                case "3":
                    Console.Clear();
                    controller.visualizarEstoque();
                    DisplayResult();
                    return true;
                case "4":
                    Console.Clear();
                    controller.completarEstoque();
                    DisplayResult();
                    return true;
                case "5":
                    Console.Clear();
                    controller.addIngrediente();
                    DisplayResult();
                    return true;
                case "6":
                    Console.Clear();
                    controller.removerIngrediente();
                    DisplayResult();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }


        public void DisplayResult()
        {
            Console.Write("\n=========================");
            Console.Write("\r\nPressione Enter para retornar ao Menu");
            Console.ReadLine();
        }
    }

}
