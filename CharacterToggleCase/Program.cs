namespace CharacterToggleCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            char[] modifiedChars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char newChar = (char)(input[i] + 1);
                modifiedChars[i] = char.IsLower(newChar) ? char.ToUpper(newChar) : char.ToLower(newChar);
            }

            string modifiedString = new string(modifiedChars);
            Console.WriteLine($"Modified String: {modifiedString}");
        }
    }
}