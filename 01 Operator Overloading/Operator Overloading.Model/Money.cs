using System;
using OperatorOverloading.Model;
using Operator_Overloading.Model;

namespace OperatorOverloading.Model
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
                if (double.IsInfinity(value))
                {
                    throw new OverflowException();
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
                    throw new InvalidCurrencyException(Messages.InvalidCurrency);
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
                throw new System.Exception(Messages.NullExcception);
            }

            var amountArr = inputAmount.Split(' ');
            double amount;

            if (amountArr.Length != 2)
            {
                throw new System.Exception();
            }

            if (double.TryParse(amountArr[0], out amount))
            {
                Amount = amount;
            }
            else
            {
                throw new System.Exception(Messages.InvalidAmount);
            }

            Currency = amountArr[1];
        }

        public static Money operator +(Money obj1, Money obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new Exception(Messages.NullExcception);
            }
            if (obj1.Currency.Equals(obj2.Currency, StringComparison.OrdinalIgnoreCase))
            {
                double totalAmount = obj1.Amount + obj2.Amount;
                return new Money(totalAmount, obj1.Currency);
            }
            else
            {
                throw new System.Exception(Messages.CurrencyMismatch);
            }
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}