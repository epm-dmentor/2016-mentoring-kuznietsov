using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnEvents
{
    class VKMonitor
    {
        public VKMonitor(StockTicker stock)
        {
            stock.OnStockChangeEvent += VkStockChangeEvent;
        }

        private void VkStockChangeEvent(object sender, StockChangeEventArgs args)
        {
            VKStockFilter(args);
        }

        private void VKStockFilter(StockChangeEventArgs args)
        {
            if (args.Name == "VK")
            {
                Console.WriteLine($"{args.Name} stocks trading on {args.StockName} are currently sold for {args.Value} USD");
            }
        }
    }
}
