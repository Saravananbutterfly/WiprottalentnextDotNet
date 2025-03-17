namespace CountDigitsAlphabets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                int digitCount = 0, alphaCount = 0;

                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                        digitCount++;
                    else if (char.IsLetter(c))
                        alphaCount++;
                }

                Console.WriteLine($"Number of alphabets: {alphaCount}");
                Console.WriteLine($"Number of digits: {digitCount}");
            }
        }
    }
}