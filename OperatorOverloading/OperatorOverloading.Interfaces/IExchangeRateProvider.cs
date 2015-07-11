using System;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace OperatorOverloading.Interfaces
{
    interface IExchangeRateProvider
    {
        double FetchingData(string from, string to);
    }
}
