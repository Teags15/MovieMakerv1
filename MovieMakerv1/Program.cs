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
            List<string> availableSnacks = new List<string>() { "Popcorn", "Chips", "Chocolate" };
            List<float> snackPrices = new List<float>() { 2.5f, 1.5f, 2f };
            List<string> availableDrinks = new List<string>() { "Fanta", "L&P" };
            List<float> drinkPrices = new List<float>() { 2.5f, 1.5f };

            float ticketPrice = 5f;

            Console.WriteLine("~~~~~~~~~~~~~~~~ Ticket Holder Testing ~~~~~~~~~~~~~~~~\n\n");

            TicketHolder testTH = new TicketHolder("Hannah", 15, 3);

            List<int> s = new List<int>() { 0, 2 };
            List<int> sq = new List<int>() { 2, 1 };

            testTH.AddSnacks(s, sq);

            List<int> d = new List<int>() { 1 };
            List<int> dq = new List<int>() { 2 };

            testTH.AddDrinks(d, dq);

            testTH.SetAge(18);

            testTH.SetCredit(true);

            Console.WriteLine(testTH.GenerateReciept(ticketPrice, availableSnacks, snackPrices, availableDrinks, drinkPrices));

            Console.WriteLine("~~~~~~~~~~~~~~~~ Ticket Manager Testing ~~~~~~~~~~~~~~~~\n\n");

            TicketManager tm = new TicketManager();

            string name = "Hannah";
            int age = 12;
            int tickets = 3;

            if (tm.CheckAge(age, 0))
            {
                if (tm.CheckAvailableSeats(tickets))
                {
                    tm.AddTicketHolder(new TicketHolder(name, age, tickets));
                }
                else
                {
                    Console.WriteLine($"There are only {tm.CalculateAvailableSeats()} tickets available");

                }
            }
            else
            {
                Console.WriteLine("You are too young to watch this movie");


            }

            tm.AddSnacksDrinksOrder(s, sq, d, dq);

    
            Console.WriteLine ($"Total Number of Seats sold: {tm.GetSeatLimit()-tm.CalculateAvailableSeats()}\n");
            
            Console.ReadLine();
        }
    }
}
