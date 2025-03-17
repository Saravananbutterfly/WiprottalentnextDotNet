namespace OperatorPgm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            
            num2 = ++num1;
            Console.WriteLine($"After Pre-increment: num1 = {num1}, num2 = {num2}");

                     
            num2 = num1++;
            Console.WriteLine($"After Post-increment: num1 = {num1}, num2 = {num2}");

            
            int temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine($"After Swap: num1 = {num1}, num2 = {num2}");
        }
    }
}