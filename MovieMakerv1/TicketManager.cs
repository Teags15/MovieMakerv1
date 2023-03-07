using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerv1
{
    internal class TicketManager
    {
        //attributes 
        private List<TicketHolder> ticketHolders = new List<TicketHolder>();
        private List<string> availableSnacks = new List<string>() { "Popcorn", "Chips", "Chocolate" };
        private List<float> snackPrices = new List<float>() { 2.5f, 1.5f, 2f };
        private List<string> availableDrinks = new List<string>() { "Fanta", "L&P" };
        private List<float> drinkPrices = new List<float>() { 2.5f, 1.5f };

        private float ticketPrice = 5f;

        private List<int> ageLimit = new List<int>() { 12 };

        private const int SEATLIMIT = 150;

        
        //constructor - constructs a TicketManager object
        public TicketManager()
        { 
            
        }

        //adds a ticket holder into the ticketHolders list
        public void AddTicketHolder(TicketHolder ticketHolder) 
        {
            ticketHolders.Add(ticketHolder);
        
        
        }

        //returns true if purchaser's age meets age requirements else it returns false
        public bool CheckAge(int buyerAge, int ageLimitIndex)
        {
            bool isOfAge = true;
            if (buyerAge < ageLimit[ageLimitIndex])
            {
                isOfAge = false;
            }

            return isOfAge;
            
        }

        public int CalculateAvailableSeats()
        {
            int sumTickets = 0;
            foreach (TicketHolder ticketHolder in ticketHolders)
            {
                sumTickets += ticketHolder.GetTickets();
            }

            return SEATLIMIT - sumTickets;
        }

        //returns true if enough seats are available for purchase else it returns false
        public bool CheckAvailableSeats(int requestedNumTickets)
        {
            if ((CalculateAvailableSeats()- requestedNumTickets) <0)
            { 
                return false;
            
            }
           
            return true;
        
        }

        //add new snack and snack prices to the snack and price lists
        public void AddSnack(string snack, float price)
        { 
            availableSnacks.Add(snack);
            snackPrices.Add(price);
        
        }

        //add new age to the age limit list
        public void AddAgeTier(int newAge)
        { 
            ageLimit.Add(newAge);
            ageLimit.Sort();
        
        }

        //change ticket prices and adds to the list
        public void ChangeTicketPrice(float newTicketPrice)
        {
            ticketPrice = newTicketPrice; 
        
        }

        

        //calculate gross profit for ticket sales
        private float CalculateTicketGrossProfit()
        {
            int sumTicketsSold = 0;

            foreach (TicketHolder ticketHolder in ticketHolders)
            {
                sumTicketsSold += ticketHolder.GetTickets();
            }
        
            return sumTicketsSold * ticketPrice;



        }

        private List<int> SumItemsSold(string itemType)
        {

            List<string> availableItems;

            //gets correct available item list
            if (itemType.Equals("snacks"))
            {
                availableItems = availableSnacks;

            }
            else 
            {
                availableItems = availableDrinks;
            }
          

            //collection storing the total quantities sold for snacks and drinks
            List<int> sumItemsSold = new List<int>();

            for (int availableItemIndex = 0; availableItemIndex < availableItems.Count; availableItemIndex++)
            {
                sumItemsSold.Add(0);
            }
            
            foreach (TicketHolder ticketHolder in ticketHolders)
            {
                List<int> orderedItems, itemsQuantities;
                // stores the correct item order and its quantities
                
                if (itemType.Equals("snacks"))
                {
                    orderedItems = ticketHolder.GetSnackOrder();
                    itemsQuantities = ticketHolder.GetSnackQuantity();
                }
                else
                {
                    orderedItems = ticketHolder.GetDrinkOrder();
                    itemsQuantities = ticketHolder.GetDrinkQuantity();
                }
                //loop through the ordered snacks
                for (int orderIndex = 0; orderIndex < orderedItems.Count; orderIndex++)
                {
                    //loop through available snacks
                    for (int snackIndex = 0; snackIndex < availableItems.Count; snackIndex++)
                    {
                        //check if ticketHolder has purchased snack 

                        if (snackIndex == orderedItems[orderIndex])
                        {
                            //add quantity to sumSnacksSold
                            sumItemsSold[snackIndex] += itemsQuantities[orderIndex];

                        }

                    }
                }


            }

            return sumItemsSold;
        }

        private float CalculateItemsGrossProfit()
        {
            //calculate total gross profit by multiply the sum quantity of each item with its price
            
            float grossProfit = 0;
            
            for (int snackIndex = 0; snackIndex < availableSnacks.Count; snackIndex++)
            {
                grossProfit += SumItemsSold("snacks")[snackIndex] * snackPrices[snackIndex];
            }
            
            for (int drinkIndex = 0; drinkIndex < availableDrinks.Count; drinkIndex++)
            {
                grossProfit += SumItemsSold("drinks")[drinkIndex] * drinkPrices[drinkIndex];
            }
            //calculate gross profit for snack and drick sales
            
            return grossProfit;
        }


        //calculate the cost for total snack and drink sales
        private float CalculateSnackDrinkTotalCost()
        {


            //cost = 100 x (total of sales \ 120)
            return 100 * (CalculateItemsGrossProfit() / 120);

        }

        //returns calculated total profit
        public float CalculateTotalPrice()
        {
            //total profit = ticket profit + (snack and drink gross profit -  cost of snacks and drinks)
            return CalculateTicketGrossProfit() + (CalculateItemsGrossProfit() - CalculateSnackDrinkTotalCost());
        }

        //returns string listing the total number snacks ordered
        public string TotalSnacksOrdered()
        {
            string sumary = "----- Total Ordered Snacks -----\n";

            for (int snackIndex = 0; snackIndex < availableSnacks.Count; snackIndex++)
            {
                sumary += availableSnacks[snackIndex] + "\tX\t" + SumItemsSold("snacks")[snackIndex] + "\n";
            }

            return sumary;
        
        }

        public string DisplayTotalProfit()
        {
            return $"Total Profit: ${CalculateTotalPrice()}";
        
        }

        //returns a string collecting all the values stored in the private variables
        public override string ToString()
        {
            return base.ToString();
        }



    }
}
