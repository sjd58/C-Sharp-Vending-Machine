using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        public VendingMachine VM { get; set; }
        public PurchaseMenu(VendingMachine vm)
        {
            VM = vm;
        }

        public void DisplayPurchaseMenu()
        {
            Console.WriteLine($"Current Money Provided: ${VM.CurrentMoney}");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            GetUserInput();
        }

        public void GetUserInput()
        {
            Console.WriteLine("Please select an option: ");
            //parsing the input to get an integer
            string userInput = Console.ReadLine();
            while (!(userInput.Contains("1") || userInput.Contains("2") || userInput.Contains("3")))
            {
                Console.WriteLine("I didn't understand that input, please try again");
                userInput = Console.ReadLine();
            }
            int userInputInt = int.Parse(userInput);
            //sets the vending machine property equal to a variable
            VM.UserInput = userInputInt;
            //calls on method below
            ExecuteUserInput();
        }

        public void ExecuteUserInput()
        {
            if (VM.UserInput == 1)
            {
                FeedMoney();
            }
            else if (VM.UserInput == 2)
            {
                VM.DisplayInventory();
                SelectProduct();
            }
            else if (!(VM.UserInput == 3))
            {
                Console.WriteLine("I didn't understand that input, please try again...");
                DisplayPurchaseMenu();
            }
            else
            {
                VM.ReturnChange();
            }
        }

        public void SelectProduct()
        {
            Console.WriteLine("Please enter the code for the product you would like to purchase: ");
            VM.ProductSelection = Console.ReadLine();
            Console.WriteLine($"Product {VM.ProductSelection} selected");
            Vend();
        }

        public void FeedMoney()
        {
            //string interpolation of the vending machine property current money
            Console.WriteLine($"Current Money Provided: ${VM.CurrentMoney}");
            
            Console.WriteLine("Select the bills you would like to insert");

            Console.WriteLine("(1) $1.00");
            Console.WriteLine("(2) $5.00");
            Console.WriteLine("(3) $10.00");
            Console.WriteLine("(4) $20.00");
            Console.WriteLine("(5) Finished");
            //array of strings valid input into a new array of strings
            string[] validInput = new string[] { "1", "2", "3", "4", "5" };
            //prompts the user for input
            string userInput = Console.ReadLine();
            //when user input is not valid return i didnt understand that input please try again
            while (!(validInput.Contains(userInput)))
            {
                Console.WriteLine("I didn't understand that input, please try again.");
                userInput = Console.ReadLine();
            }
            // parsing from string into int
            int billSelection = int.Parse(userInput);
            //chain of conditionals of which bill thre user wants to put in
            if (billSelection == 1)
            {
                VM.CurrentMoney += 1;
                //contunuously calls on method feeding money for the user to add money
                PreventTheft.LogFeedingMoney(1, VM.CurrentMoney);
                FeedMoney();
            }
            else if (billSelection == 2)
            {
                VM.CurrentMoney += 5;
                PreventTheft.LogFeedingMoney(5, VM.CurrentMoney);
                FeedMoney();
            }
            else if (billSelection == 3)
            {
                VM.CurrentMoney += 10;
                PreventTheft.LogFeedingMoney(10, VM.CurrentMoney);
                FeedMoney();
            }
            else if (billSelection == 4)
            {
                VM.CurrentMoney += 20;
                PreventTheft.LogFeedingMoney(20, VM.CurrentMoney);
                FeedMoney();
            }
            else if (billSelection == 5)
            {
                DisplayPurchaseMenu();
            }
            else
            {
                Console.WriteLine("I didn't understand that input, please try again...");
                FeedMoney();
            }

        }

        public void Vend()
        {
            //if user did not put in the correct key, skip the item
            if (!(VM.FoodItemSlots.ContainsKey(VM.ProductSelection)))
            {
                Console.WriteLine("Invalid input, please try again.");
                DisplayPurchaseMenu();
            }
            //customer did not put in enough money to buy the food item. using VM key
            else if (VM.CurrentMoney < VM.FoodItemSlots[VM.ProductSelection].SlotItemPrice)
            {
                Console.WriteLine("Not enough money to buy this product; please add more money.");
                DisplayPurchaseMenu();
            }
            // the item is out of stock. vending machine key
            else if (VM.FoodItemSlots[VM.ProductSelection].NumberOfItems <= 0)
            {
                Console.WriteLine("This product is SOLD OUT. Please try again later.");
                DisplayPurchaseMenu();
            }
            else
            { 
                //vending machine property food item slots, accessing key in dictionary, 
                //calling on method to remove item
                VM.FoodItemSlots[VM.ProductSelection].RemoveItem();
                //subtracting from the amount of money the customer entered by the product price
                VM.CurrentMoney -= VM.FoodItemSlots[VM.ProductSelection].SlotItemPrice;
                // how the vending machine is logging
                PreventTheft.LogPurchase(VM.FoodItemSlots[VM.ProductSelection].StockList, VM.CurrentMoney);

                if (VM.ProductSelection.Substring(0, 1) == "A")
                {
                    Console.WriteLine("Crunch Crunch, Yum!");
                }
                else if (VM.ProductSelection.Substring(0, 1) == "B")
                {
                    Console.WriteLine("Munch Munch, Yum!");
                }
                else if (VM.ProductSelection.Substring(0, 1) == "C")
                {
                    Console.WriteLine("Glug Glug, Yum!");
                }
                else
                {
                    Console.WriteLine("Chew Chew, Yum!");
                }
                DisplayPurchaseMenu();
            }

        }
    }
}