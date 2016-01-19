using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnEvents
{
    class StockTicker
    {
        private StockExchange _stockExchange;

        public StockExchange StockExchange

        {
            get { return _stockExchange; }
            set
            {
                _stockExchange = value;
                if (OnStockChangeEvent != null)
                {
                    StockChangeEventArgs args = new StockChangeEventArgs(StockExchange.StockName, StockExchange.StockValue);
                    OnStockChangeEvent(this, args);
                }
            }
        }

        internal delegate void OnStockChange(object sender, StockChangeEventArgs args);

        internal event OnStockChange OnStockChangeEvent;


    }
}
