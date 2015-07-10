using System;
using OperatorOverloading.dbl;

namespace OperatorOverloading.Host
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
           
            Money amount1 = null;
            Money amount2 = null;
            Money amount3 = null;
           
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
                    Console.Write("Enter Amount and  Currency ");
                    amount2 = new Money(Console.ReadLine());
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
                if (amount2.Currency != amount1.Currency)
                amount2 = amount1.Convert(amount2.Currency);

                amount3 = amount1 + amount2;
               
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
