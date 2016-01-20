using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnIObservable
{
    class Program
    {
        static void Main(string[] args)
        {
            StockTicker st = new StockTicker();

            HopelessVata gp = new HopelessVata();
            TeslaObserver tm = new TeslaObserver();

            using (st.Subscribe(gp))
            using (st.Subscribe(tm))
            {
                foreach (var tradeData in StockExchange.GetNext())
                {
                    st.StockExchange = tradeData;
                }
            }


            Console.ReadLine();

        }
    }
}
