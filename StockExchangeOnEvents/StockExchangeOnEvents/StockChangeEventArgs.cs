namespace StockExchangeOnEvents
{
    public class StockChangeEventArgs
    {

        public string Name { get; set; }
        public string StockName { get; set; }
        public double Value { get; set; }

        public StockChangeEventArgs(string sName, double sValue, string sExName = "NY Stock Exchange")
        {
            StockName = sExName;
            Name = sName;
            Value = sValue;
        }                                                                 


    }
}