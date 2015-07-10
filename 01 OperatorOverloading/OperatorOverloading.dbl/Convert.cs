using System;
using System.Net;
using System.Net.Sockets;

namespace OperatorOverloading.dbl
{
    public class Convert : IConverter
    {
      
        public double FetchingData(string from, string to)
        {
            double convertFactor;
            WebClient webpage = new WebClient();
            var jsonData = webpage.DownloadString("http://www.apilayer.net/api/live?access_key=a8f70a4d56dd71ef3d37065d7e3f3045&format=1");
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
