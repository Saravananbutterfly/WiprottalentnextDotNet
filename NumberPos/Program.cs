namespace NumberPos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the six digit number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number to find the place: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int position = 1;
            int temp = num1;
            bool found = false;

            while (temp > 0)
            {
                int digit = temp % 10;
                if (digit == num2)
                {
                    found = true;
                    break;
                }
                temp /= 10;
                position *= 10;
            }

            if (found)
            {
                switch (position)
                {
                    case 1:
                        Console.WriteLine($"{num2} is in the Unit's place.");
                        break;
                    case 10:
                        Console.WriteLine($"{num2} is in the Ten's place.");
                        break;
                    case 100:
                        Console.WriteLine($"{num2} is in the Hundred's place.");
                        break;
                    case 1000:
                        Console.WriteLine($"{num2} is in the Thousand's place.");
                        break;
                    default:
                        Console.WriteLine($"{num2} is in the {position}'s place.");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{num2} is not present in {num1}.");
            }
        }
    }
}