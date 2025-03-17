namespace AreaSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the side length of the square: ");
            double side = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Area of the square: {0}",side*side);
        }
    }
}