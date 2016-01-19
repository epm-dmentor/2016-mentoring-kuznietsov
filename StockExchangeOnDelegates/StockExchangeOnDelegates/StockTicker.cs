using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnDelegates
{
    class StockTicker
    {
        private StockMarket _stockMarket;

        public StockMarket StockMarket
        {
            get { return _stockMarket; }
            set
            {
                _stockMarket = value;
                if (StockInformer != null)
                {
                StockInformer(StockMarket.StockName, StockMarket.StockValue);

                }
            }
        }

        public delegate void OnStockChange(string name, double value);

        public OnStockChange StockInformer;

    }
}
