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

            List<string> uniqueProducts = new List<string>();

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
                    if (!(uniqueProducts.Contains(saleSplit[0])))
                    {
                        uniqueProducts.Add(saleSplit[0]);
                        File.Create($"{saleSplit[0]}");
                    }
                    File.AppendAllText($"{saleSplit[0]}.txt", $"{date} - {salesHistory[i][j]}\n");
                }
            }
        }
    }
}

