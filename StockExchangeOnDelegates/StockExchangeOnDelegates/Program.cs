using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            StockTicker subj = new StockTicker();
            

            subj.StockInformer += VkStockInformer;
            subj.StockInformer += FbStockInformer;


            foreach (var sm in StockMarket.GetNext())
                subj.StockMarket = sm;
            Console.ReadLine();
        }

        private static void FbStockInformer(string name, double value)
        {
            if (name == "VK")
            {
                Console.WriteLine($"{name} stock exchange rate is {value}");
            }
        }

        private static void VkStockInformer(string name, double value)
        {
            if (name == "FACEBOOK")
            {
                Console.WriteLine($"{name} stock exchange rate is {value}");
            }
        }
    }
}
