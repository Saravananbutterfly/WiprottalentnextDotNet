namespace CountArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int count = 0;

            foreach (var item in arr)
            {
                count++;
            }

            Console.WriteLine($"Number of elements in the array: {count}");
        }
    }
}