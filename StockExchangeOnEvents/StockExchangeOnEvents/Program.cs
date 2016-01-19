using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            StockTicker st = new StockTicker();
            
            FbMonitor stockFbMonitor = new FbMonitor(st);

            VKMonitor stockVkMonitor = new VKMonitor(st);



            foreach (var stock in StockExchange.GetNext())
                st.StockExchange = stock;

            Console.ReadLine();
        }
    }
}
