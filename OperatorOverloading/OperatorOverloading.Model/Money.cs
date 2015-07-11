using System;
using System.Net;


namespace OperatorOverloading.Interfaces
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public double Amount
        {
            get { return _amount; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception(Messages.AmountNegative);
                }
                if (double.IsInfinity(value))
                {
                    throw new Exception(Messages.AmountTooLarge);
                }
                _amount = value;
            }
        }

        public string Currency
        {
            get { return _currency; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(Messages.InvalidCurrency);
                }
                if (value.Length != 3)
                {
                    throw new Exception(Messages.InvalidCurrency);
                }
                _currency = value;
            }
        }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money(string inputAmount)
        {

            if (string.IsNullOrWhiteSpace(inputAmount))
            {
                throw new Exception(Messages.NullValue);
            }

            var amountArr = inputAmount.Split(' ');
            double amount;

            if (amountArr.Length != 2)
            {
                throw new Exception(Messages.InvalidInput);
            }

            if (double.TryParse(amountArr[0], out amount))
            {
                Amount = amount;
            }
            else
            {
                throw new Exception(Messages.InvalidAmount);
            }

            Currency = amountArr[1];
        }
        public Money Convert(string convertTo)
        {
            double result;
            result = new OperatorOverloading.Dbl.Convert().ConversionRate(Currency, convertTo);
          
           
            return new Money(result * Amount, convertTo);
        }

        public static Money operator +(Money obj1, Money obj2)
        {
           
                double totalAmount = obj1.Amount + obj2.Amount;
                return new Money(totalAmount, obj1.Currency);
            
        }

       
        

        
    }
}
