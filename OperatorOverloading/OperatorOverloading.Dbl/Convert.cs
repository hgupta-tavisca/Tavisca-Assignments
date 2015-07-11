using System;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace OperatorOverloading.Dbl
{
    public class Convert : IExchangeRateProvider
    {

        public double ConversionRate(string from, string to)
        {
            double convertFactor;
            string jsonData = null; ;

            jsonData = System.IO.File.ReadAllText(@"D:\Training\01 OperatorOverloading\OperatorOverloading.Model\Data.txt");
            string searchString = from.ToUpper() + to.ToUpper();
            convertFactor = Parse(jsonData, searchString);
            if (convertFactor < 0)
            {
                throw new Exception("no results");
            }
            return convertFactor;
        }

        public double Parse(string jsonString, string searchString)
        {
            double rate = 0;
            if (String.IsNullOrWhiteSpace(jsonString))
            {
                throw new Exception("InvalidResponse");
            }

            if (String.IsNullOrWhiteSpace(searchString))
            {
                throw new Exception("NullInputs");
            }

            if (searchString.Length != 6)
            {
                throw new Exception("NoResults");
            }

            var keyArray = jsonString.Split('{', '}', ',');
            foreach (string str in keyArray)
            {
                // System.Environment.Exit(1);
                if (str.Contains(searchString))
                {
                    var resultArray = str.Split(':');

                    if (double.TryParse(resultArray[1], out rate))
                    {
                        if (rate < 0 || double.IsPositiveInfinity(rate))
                        {
                            throw new Exception("InvalidRate");
                        }
                        return rate;
                    }
                    else
                    {
                        throw new Exception("TypeMismatch");
                    }
                }
            }
            return -1;
        }
    }
}
