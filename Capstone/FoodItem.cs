using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeVendingMachine
{
    public class FoodItem // make this an abstract class
    {
        public string  SlotIdentifier {get; set; }
        public string FoodName { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SnackType { get; set; }

        public FoodItem(string slotIdentifier, string foodName, decimal purchasePrice, string snackType)
        {
            //the constructor is setting the properties equal to the parameters passed in the object
            SlotIdentifier = slotIdentifier;
            FoodName = foodName;
            PurchasePrice = purchasePrice;
            SnackType = snackType;
        }

    }
}
