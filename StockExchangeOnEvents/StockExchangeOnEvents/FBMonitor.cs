using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnEvents
{
    class FbMonitor
    {
        public FbMonitor(StockTicker stock)
        {
            stock.OnStockChangeEvent += FbStockEvent;
        }

        private void FbStockEvent(object sender, StockChangeEventArgs args)
        {
                FbStockFilter(args);
        }

        private void FbStockFilter(StockChangeEventArgs args)
        {
            if (args.Name == "FB")
                Console.WriteLine($"{args.Name} stocks trading on {args.StockName} are currently sold for {args.Value} USD");
        }


    }
}
