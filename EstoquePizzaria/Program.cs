using System;

namespace EstoquePizzaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }

        }
    }
}
