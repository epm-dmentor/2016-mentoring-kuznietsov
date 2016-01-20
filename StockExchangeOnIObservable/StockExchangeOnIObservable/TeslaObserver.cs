using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnIObservable
{
    class TeslaObserver : IObserver<StockTicker>
    {
        public void OnNext(StockTicker value)
        {
            if (Equals(value.StockExchange.CompanyName, "TESLA MOTORS"))
                Console.WriteLine($"TESLA stocks trading at {value.StockExchange.StockExchName} are sold at price of {value.StockExchange.CompanyStockVal}");
        }

        public void OnError(Exception error)
        {
            throw new Exception("Ooooopppsssss.... ");
        }

        public void OnCompleted()
        {
            Console.WriteLine("EOD, please run batches and send data to EM");
        }
    }
}
