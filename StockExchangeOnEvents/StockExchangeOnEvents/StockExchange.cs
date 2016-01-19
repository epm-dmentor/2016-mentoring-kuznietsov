using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnEvents
{
    //Честно признаюсь, эту конструкцию я спёр))))
    //Очень уже мне понравился сам принсип создания и возвращение Енумерабл одним движением))


    internal class StockExchange
    {
        public string StockName { get; set; }
        public double StockValue { get; set; }
        public string StockExchangeName { get; set; }


        private static readonly string[] _StockName = {"VK", "FB", "FB", "VK", "VK", "FB"};
        private static readonly double[] _stockValues = {5, 10, 12.5, 4, 3.5, 15};

        public static IEnumerable<StockExchange> GetNext()
        {
            for (int i = 0; i < _stockValues.Length; i++)
            {
                StockExchange stock = new StockExchange();
                stock.StockName = _StockName[i];
                stock.StockValue = _stockValues[i];
                yield return stock;
            }
        } 
    }
}
