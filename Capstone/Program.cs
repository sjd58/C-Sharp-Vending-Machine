using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates new vending machine
            VendingMachine vm = new VendingMachine();
            //creates new purchase menu and passes it into the vending machine
            PurchaseMenu pm = new PurchaseMenu(vm);
            //creates new main menu and passesit into vending machine and purchase menu
            MainMenu mm = new MainMenu(vm, pm);
            //starts vending machine
            mm.StartMeUp();
        }
    }
}
