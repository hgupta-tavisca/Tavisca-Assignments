
using OperatorOverloading.Interfaces;
using System;


namespace OperatorOverloading.Host
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
          
            Money amount1 = null;
            Money amount2 = null;
            Money amount3 = null;
            string currency;
           
            while (true)
            {
                try
                {
                    Console.Write("Enter Amount  and currency : ");
                    amount1 = new Money(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured.");
                    Console.WriteLine(e.Message);

                    continue;
                }
                break;
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter Currency ");
                    currency = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured.");
                    Console.WriteLine(e.Message);

                    continue;
                }
                break;

            }
           
            try
            {
               
                amount2 = amount1.Convert(currency);
               
              
               
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey();
                return;
            }
            Console.Write("The Total Amount is: ");
            Console.Write(amount3.Amount);
            Console.Write(amount3.Currency);
            Console.ReadKey();
        }
    }
}
