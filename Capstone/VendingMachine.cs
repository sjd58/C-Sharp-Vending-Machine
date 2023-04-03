using PrototypeVendingMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string, Slot> FoodItemSlots { get; private set; } = new Dictionary<string, Slot>(); // make private

        public string ProductSelection { get; set; }
        
        public int UserInput { get; set; }

        public decimal CurrentMoney { get; set; } = 0;

        private string StockCSVFilePath { get; } = "C:\\Users\\Student\\workspace\\capstones\\c-sharp-minicapstonemodule1-team3\\vendingmachine.csv";

        public VendingMachine()
        {
            Stock();
        }

        public void Stock()
        {
            try
            {
                //creating a new stream reader object and taking in the file path
                //from the property of the vending machine got from the CSVFile
                using (StreamReader dataInput = new StreamReader(StockCSVFilePath))
                {
                    //continue while not at the end
                    while (!dataInput.EndOfStream)
                    {
                        //read csv file line by line
                        string inputLine = dataInput.ReadLine();
                        //breaking up the input into an array of strings using the |(pipes) to define the values
                        string[] brokenUpInput = inputLine.Split("|");
                        //creating a new slot object with the information got from StreamReader
                        Slot newSlot = new Slot(brokenUpInput);
                        //add to the food item slots the new slot in the dictionary
                        FoodItemSlots.Add(brokenUpInput[0], newSlot);
                        //add items to the slot 5 times
                        for (int i = 0; i < 5; i++)
                        {
                            newSlot.AddItems();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong, here's the exception: {e}");
            }
        }

        public void DisplayInventory()
        {
            //for each loop to go over every key value pair in the dictionary
            foreach (KeyValuePair<string, Slot> item in FoodItemSlots)
            {
                //return message to customer if item is out of stock
                if (item.Value.NumberOfItems <= 0)
                {
                    Console.WriteLine($"{item.Value.SlotCode} containing {item.Value.StockList[1]} is SOLD OUT.");
                }
                //return the price to the customer
                else
                {
                    Console.WriteLine($"{item.Value.SlotCode} contains {item.Value.NumberOfItems} {item.Value.StockList[1]}. Price: ${item.Value.StockList[2]}");
                }
            }
        }

        public void ReturnChange()
        {
            PreventTheft.LogMakingChange(CurrentMoney);
            //Convert decimal current money into an integer 
            int currentMoneyAsInt = Convert.ToInt32(CurrentMoney * 100);
            int numberOfQuarters = currentMoneyAsInt / 25;
            int remainder = currentMoneyAsInt - numberOfQuarters * 25;
            if (remainder == 0)
            {
                Console.WriteLine($"You received {numberOfQuarters} quarters as change.");
            }
            else
            {
                int numberOfDimes = remainder / 10;
                remainder = remainder - (10 * numberOfDimes);
                if (remainder == 0)
                {
                    Console.WriteLine($"You received {numberOfQuarters} quarters and {numberOfDimes} dimes as change.");
                }
                else
                {
                    int numberOfNickels = remainder / 5;
                    remainder = remainder - (5 * numberOfNickels);
                    Console.WriteLine($"You received {numberOfQuarters} quarters, {numberOfDimes} dimes, and {numberOfNickels} nickels as change.");
                }
            }
        }
    }
}
