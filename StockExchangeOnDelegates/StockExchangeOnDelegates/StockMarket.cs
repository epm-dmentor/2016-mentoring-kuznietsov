using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnDelegates
{
    class StockMarket
    {
        public string StockName { get; set; }
        public double StockValue { get; set; }

        private static readonly string[] MarketNames = { "FACEBOOK", "VK", "VK", "FACEBOOK", "VK", "FACEBOOK" };
        private static readonly double[] MarketValues = {10.0, 12.5, 15.0, 17, 8.5, 5, 19};


        public static IEnumerable<StockMarket> GetNext()
        {
            for (int i = 0; i < MarketNames.Length; i++)
            {
                StockMarket sm = new StockMarket();
                sm.StockName = MarketNames[i];
                sm.StockValue = MarketValues[i];
                yield return sm;
            }
        }

        



    }
}
