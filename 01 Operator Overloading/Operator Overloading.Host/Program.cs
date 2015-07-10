using System;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Money amount1 = null;
            Money amount2 = null;
            Money money3 = null;
            while (true)
            {
                try
                {
                    Console.Write("Enter Amount 1 (Amount Currency): ");
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
                    Console.Write("Enter Amount 2 (Amount Currency): ");
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
                money3 = amount1 + amount2;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey();
                return;
            }
            Console.Write("The Total Amount is: ");
            Console.Write(money3.Amount);
            Console.ReadKey();
        }
    }
}