namespace RandomHelper
{
    class RandomHelper
    {
        private static Random random = new Random();

        // Method to generate a random integer (inclusive range)
        public static int RandInt(int min, int max)
        {
            return random.Next(min, max + 1); // max is inclusive
        }

        // Method to generate a random double (min <= x < max)
        public static double RandDouble(int min, int max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Random Integer (1-10): {RandomHelper.RandInt(1, 10)}");
            Console.WriteLine($"Random Double (1-10): {RandomHelper.RandDouble(1, 10):F2}");
        }
    }
}