using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerv1
{
    class TicketHolder
    {
        //attributes or fields
        private string name;
        private int age;
        private int numberTickets;
        private bool credit;
        //stores the indexes of the snacks that has been ordered
        private List<int> snackOrder = new List<int>();
        private List<int> snackQuantity = new List<int>();
        //stores the indexesof the drinks that have been ordered
        private List<int> drinkOrder = new List<int>();
        private List<int> drinkQuantity = new List<int>();

        //constructor - constructs an object of this class

        public TicketHolder(string name, int age, int nTickets)
        {
            this.name = name;
            this.age = age;
            numberTickets = nTickets;
        }

        //returns the value of the private age variable
        public int GetAge()
        {
            return this.age;
        }

        //sets the value of the private age variable

        public void SetAge(int newAge)
        {
            this.age = newAge;
        }

        //sets the value of the private credit variable
        public void SetCredit(bool newPaymentType)
        {
            credit = newPaymentType;
        }

        //add snacks and quantities to the snackOrder list and snacksQuantity list

        public void AddSnacks(List<int> snacks, List<int> quantities)
        {
            snackOrder = snacks;
            snackQuantity = quantities;
        }

        //add drinks and quantities to the snackOrder list and drinksQuantity list
        public void AddDrinks(List<int> drinks, List<int> quantities)
        {
            drinkOrder = drinks;
            drinkQuantity = quantities;
        }

        private string PaymentType()
        {

            string paymentType = "card";

            if (credit == false)
            {
                paymentType = "cash";
            }

            return paymentType;

        }

        //return the total cost of the purchased items
        public float CalculateTotalCost(List<float> sPrices, List<float> dPrices, float ticketPrices)
        {
            float totalCost = 0f;

            //loop through snack order and calculate the cost for each snack 
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                float snackPrice = sPrices[snackOrder[snackIndex]];

                //add the cost of each snack to totalCost
                totalCost += snackPrice * snackQuantity[snackIndex];
            }



            //loop through drink order and calculate the cost for each drink
            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                float drinkPrice = dPrices[drinkOrder[drinkIndex]];

                //add the cost of each drink to totalCost
                totalCost += drinkPrice * drinkQuantity[drinkIndex];
            }

            totalCost += CalculateTicketCost(ticketPrices); 


            return totalCost;

        }

        //return ticket sumary
        private string TicketSumary(float ticketPrice)
        {
            return "-------------------------\n" + $"{numberTickets} x Tickets\t${CalculateTicketCost(ticketPrice)}\n ------------------------\n";

        }

        //calculate ticket cost
        public float CalculateTicketCost(float ticketPrice)
        {
            return numberTickets * ticketPrice;

        }


        //return a summary of drinks and snack order

        private string SnackDrinkSumary(List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {
            string sumary = "snacks and drinks\n";

            //loop through snack orders and add quantity, snack, total item cost to the sumary
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                sumary += snackQuantity[snackIndex] + "  x  " + sList[snackOrder[snackIndex]] + "\t$" + (snackQuantity[snackIndex] * sPrices[snackOrder[snackIndex]]) + "\n";
            }

            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                sumary += drinkQuantity[drinkIndex] + "  x  " + dList[drinkOrder[drinkIndex]] + "\t$" + (drinkQuantity[drinkIndex] * dPrices[drinkOrder[drinkIndex]]) + "\n";
            }

            return sumary;
        }

        //check if a surcharge is required
        private bool GetSurcharge()
        {
            return credit;
        
        }

        //return string displaying surcharge cost
        private float CalculateSurcharge(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            float surcharge = CalculateTotalCost(sPrices, dPrices, ticketPrice) * 0.2f;

            return surcharge;
        
        }


        private string SurchargeSumary(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            string sumary = "";

            if (credit)
            { 
                sumary += "Surcharge\t$" + CalculateSurcharge (sPrices, dPrices, ticketPrice);
            
            }

            return sumary;
        }

        //calculate the total amount to be paid
        private float CalculateTotalPayment(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            float totalPayment = CalculateTotalCost(sPrices, dPrices, ticketPrice);

            if (credit)
            {
                totalPayment += CalculateSurcharge(sPrices, dPrices, ticketPrice);
            }        
        
            return totalPayment;
        }

        //return a sumary of the total amount to be paid
        private string TotalPaymentSumary(List<float> sPrices, List<float> dPrices, float ticketPrice)
        { 
            return "Total\t$" + CalculateTotalPayment(sPrices, dPrices, ticketPrice);
        
        }

        //returns a string displaying the reciept for the purchased item
        public string GenerateReciept(float tPrice, List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {
            string Reciept = $"Name: {name}\n Age: {age}\n Payment type: " + PaymentType() + 
                "\n" + TicketSumary(tPrice)+ SnackDrinkSumary(sList, sPrices, dList, dPrices)+"\n"+ SurchargeSumary(sPrices, dPrices, tPrice)+"\n\n" +
                TotalPaymentSumary(sPrices, dPrices, tPrice);

            return Reciept;

        }

        //returns a string collecting all the values stored in the private variables
        public override string ToString()
        {
            return "";
        }


    }




}
