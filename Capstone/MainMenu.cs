using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {

        public VendingMachine VM { get; set; }

        public MainMenu(VendingMachine vm, PurchaseMenu pm)
        {
            VM = vm;
            PM = pm;
        }

        public PurchaseMenu PM { get; set; }

        public void StartMeUp()
        {
            Console.WriteLine("Welcome to the Vendo-Matic 800");
            DisplayMainMenu();
        }


        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            GetUserInput();
        }

        public void GetUserInput()
        {
            Console.WriteLine("Please select an option: ");
            string userInput = Console.ReadLine();
            while(!(userInput.Contains("1") || userInput.Contains("2") || userInput.Contains("3")))
            {
                Console.WriteLine("I didn't understand that input, please try again.");
                userInput = Console.ReadLine();
            }
            VM.UserInput = int.Parse(userInput); // always use try catch with parse
            ExecuteUserInput();
        }

        public void ExecuteUserInput()
        {
            if (VM.UserInput == 1)
            {
                VM.DisplayInventory();
                DisplayMainMenu();
                
                
            }
            else if (VM.UserInput == 2)
            {
                PM.DisplayPurchaseMenu();
            }
            else if (!(VM.UserInput == 3))
            {
                Console.WriteLine("I didn't understand that input, please try again...");
                GetUserInput();
            }
            else
            {

                // eventually going to crash because of recursion. we're calling methods within each other.
                // we want these methods to be looping instead of calling each other.
            }
        }
    }
}
