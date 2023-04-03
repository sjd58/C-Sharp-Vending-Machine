using PrototypeVendingMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Slot
    {
        public string[] StockList { get; set; }
        public Stack<FoodItem> Stack { get; set; } = new Stack<FoodItem>();
        public string SlotCode { get; set; } // get the stock code from the first value of the 
        public int NumberOfItems { get; set; }

        public decimal SlotItemPrice { get; set; } // change this to private set so people can't change the price.

        public Slot(string[] stockList)
        {
            //setting the proterty for stock list based on what is being passed into the constructor
            StockList = stockList;
            //slot code is the first index in the array
            SlotCode = stockList[0];
            //the stock list item: price is parsed from an integer into a decimal
            SlotItemPrice = decimal.Parse(stockList[2]);
        }

        public void AddItems()
        {
            //slot code for the item i.e. A2
            string slotCode = StockList[0];
            // name of food item
            string foodName = StockList[1];
            // parsing the food price from integer into a decimal 
            decimal foodPrice = decimal.Parse(StockList[2]);
            //defined food type
            string foodType = StockList[3];
            //creating a new instantion of food item
            FoodItem itemToAdd = new FoodItem(slotCode, foodName, foodPrice, foodType);
            //adds item to the stack once it is created
            Stack.Push(itemToAdd);
            //continues to add items until 5 are stocked
            NumberOfItems++;

        }

        public void RemoveItem()
        {
            //pops item off of stack
            Stack.Pop();
            //decrements number of items
            NumberOfItems--;

            // return the food item
        }
    }
}
