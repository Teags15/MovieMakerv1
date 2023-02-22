using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerv1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> availableSnacks = new List<string>() { "popcorn", "chips", "chocolate" };
            List<float> snackPrices = new List<float>() { 2.5f, 1.5f, 2f };
            List<string> availableDrinks = new List<string>() { "Fanta", "L&P" };
            List<float> drinkPrices = new List<float>() { 2.5f, 1.5f };

            float ticketPrice = 5f;

            TicketHolder testTH = new TicketHolder("Charlie",16,3);
            
            List<int> s = new List<int>() { 0, 2 };
            List<int> sq = new List<int>() { 2, 1 };
            
            testTH.AddSnacks(s, sq);
            
            List<int> d = new List<int>() { 1 };
            List<int> dq = new List<int>() { 2 };
            
            testTH.AddDrinks(d, dq);
            
            testTH.SetAge(18);

            testTH.SetCredit(true);
            
            Console.WriteLine(testTH.GenerateReciept(ticketPrice, availableSnacks, snackPrices, availableDrinks, drinkPrices));
            Console.ReadLine();
        }
    }
}
