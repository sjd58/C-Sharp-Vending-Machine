using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypeVendingMachine;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class FoodItemTests
    {
        [TestMethod]
        public void Constructor_Sets_Properties_Test()
        {
            // Arrange
            //tests the slot code 
            string slotCode = "A1";
            // tests that food name is valid
            string foodName = "Candy Bar";
            //checks to make sure the decimal passed to the machine is valid
            decimal price = 2.50M;
            //checks to make sure the vending machine knows snack types
            string snackType = "Candy";


            // Act
            //creates a class to make sure the parameters can bee properly passed into the instance
            FoodItem foodItem = new FoodItem(slotCode, foodName, price, snackType);

            // Assert
            //checking to make sure the values above actually match the istantiated class
            Assert.AreEqual(slotCode, foodItem.SlotIdentifier);
            Assert.AreEqual(foodName, foodItem.FoodName);
            Assert.AreEqual(price, foodItem.PurchasePrice);
            Assert.AreEqual(snackType, foodItem.SnackType);
        }
    }
}
