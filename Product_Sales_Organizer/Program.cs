using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Product_Sales_Organizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string[]> salesHistory = new List<string[]>();
            salesHistory.Add(File.ReadAllLines("MondaySales.txt"));
            salesHistory.Add(File.ReadAllLines("TuesdaySales.txt"));
            salesHistory.Add(File.ReadAllLines("WednesdaySales.txt"));
            salesHistory.Add(File.ReadAllLines("ThursdaySales.txt"));
            salesHistory.Add(File.ReadAllLines("FridaySales.txt"));

            HashSet<string> existingLines = new HashSet<string>();
            HashSet<string> existingProducts = new HashSet<string>();

            for (int i = 0; i < salesHistory.Count; i++)
            {
                string date = "";
                if (i == 0)
                    date = "Monday";
                else if (i == 1)
                    date = "Tuesday";
                else if (i == 2)
                    date = "Wednesday";
                else if (i == 3)
                    date = "Thursday";
                else if (i == 4)
                    date = "Friday";

                for (int j = 0; j < salesHistory[i].Length; j++)
                {
                    string[] saleSplit = salesHistory[i][j].Split(',');
                    string appendText = $"{salesHistory[i][j]},{date}";
                    string productName = saleSplit[0];

                    if (!(existingProducts.Contains(saleSplit[0])))
                        existingProducts.Add(saleSplit[0]);

                    if (File.Exists($"{productName}.txt"))
                    {
                        string[] fileCheck = File.ReadAllLines($"{productName}.txt");
                        foreach (string line in fileCheck)
                            existingLines.Add(line);
                    }

                    if (!(existingLines.Contains(appendText)))
                    {
                        File.AppendAllText($"{productName}.txt", $"{appendText}\n");
                        existingLines.Add(appendText);
                    }
                }
            }

            Console.WriteLine("Outputted Files:");
            foreach (string product in existingProducts)
            {
                string[] productFile = File.ReadAllLines($"{product}.txt");

                Console.WriteLine($"{product} Sales:");
                foreach (string line in productFile)
                    Console.WriteLine(line);

                Console.WriteLine();
            }
        }
    }
}
