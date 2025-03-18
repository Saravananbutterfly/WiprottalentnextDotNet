namespace Stock
{
    class Stock
    {
        // Properties
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public double PreviousClosingPrice { get; set; }
        public double CurrentClosingPrice { get; set; }

        // Constructor
        public Stock(string name, string symbol, double previousPrice, double currentPrice)
        {
            StockName = name;
            StockSymbol = symbol;
            PreviousClosingPrice = previousPrice;
            CurrentClosingPrice = currentPrice;
        }

        // Method to Calculate Percentage Change
        public double GetChangePercentage()
        {
            return ((CurrentClosingPrice - PreviousClosingPrice) / PreviousClosingPrice) * 100;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock("Diary Milk", "DM", 250.75, 260.50);
            Console.WriteLine($"Stock: {stock.StockName} ({stock.StockSymbol})");
            Console.WriteLine($"Previous Closing Price: {stock.PreviousClosingPrice}");
            Console.WriteLine($"Current Closing Price: {stock.CurrentClosingPrice}");
            Console.WriteLine($"Price Change Percentage: {stock.GetChangePercentage():F2}%");
        }
    }
}