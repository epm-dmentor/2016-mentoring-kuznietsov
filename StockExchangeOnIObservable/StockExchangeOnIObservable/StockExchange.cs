using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnIObservable
{
    internal class StockExchange
    {
        internal string StockExchName = "NASDAQ";
        internal string CompanyName { get; set; }
        internal double CompanyStockVal { get; set; }

        private static readonly string[] StockCompanies = {"TESLA MOTORS", "GAZPROM", "GAZPROM", "TESLA MOTORS", "TESLA MOTORS", "GAZPROM"};
        private static readonly double[] StockCompValues = {40, 5, 2.5, 50, 45.5, 0.75};

        internal static IEnumerable<StockExchange> GetNext()
        {
            for (int i = 0; i < StockCompanies.Length; i++)
            {
                StockExchange stock = new StockExchange();
                stock.CompanyName = StockCompanies[i];
                stock.CompanyStockVal = StockCompValues[i];
                yield return stock;
            }
        }
    }
}
