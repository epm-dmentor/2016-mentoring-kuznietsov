using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnIObservable
{
    class HopelessVata : IObserver<StockTicker>
    {
        public void OnNext(StockTicker value)
        {
            if (Equals(value.StockExchange.CompanyName, "GAZPROM"))
                Console.WriteLine($"GAZPROM stocks trading on {value.StockExchange.StockExchName} value has dropped again. New price is {value.StockExchange.CompanyStockVal}");
        }

        public void OnError(Exception error)
        {
            throw new Exception("Something went horribly wrong! Blame Obama!");
        }

        public void OnCompleted()
        {
            Console.WriteLine("Thats all folks");
        }
    }
}
