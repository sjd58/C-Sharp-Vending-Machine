using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    static class PreventTheft
    {

        

        public static void LogFeedingMoney(int informationToLog, decimal currentMoney)
        {
            //setting up the file path
            string path = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(path, fileName);

            try
            {
                //passing in the file path we created above
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    //writes file into the log file
                    sw.WriteLine($"{DateTime.UtcNow} FEED MONEY: ${informationToLog}.00 ${currentMoney}.00");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error with the log: {e}");
            }
        }

        public static void LogPurchase(string[] soldProduct, decimal currentMoney)
        {
            //sets up file path
            string path = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(path, fileName);

            try
            {
                //setting up a new stream writer
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} {soldProduct[1]} {soldProduct[0]} ${soldProduct[2]} ${currentMoney}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error with the log: {e}");
            }
            
        }

        public static void LogMakingChange(decimal currentMoney)
        {
            //sets up file path
            string path = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(path, fileName);

            try
            {
                //creating a new stream writer and logging the change
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} GIVE CHANGE: ${currentMoney} $0.00");
                }
            }
            catch (Exception e)
            {
                //catches exceptions
                Console.WriteLine($"An exception happened: {e}");
            }
        }
    }
}