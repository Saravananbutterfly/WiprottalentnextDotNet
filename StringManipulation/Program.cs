namespace StringManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            // 1. Reverse the string
            string reversed = new string(input.ToCharArray().Reverse().ToArray());
            Console.WriteLine($"Reversed String: {reversed}");

            // 2. Extract part of the string from the 2nd position till the end
            string substring = input.Length > 1 ? input.Substring(1) : "";
            Console.WriteLine($"Extracted String from 2nd position: {substring}");

            // 3. Replace a given character with '$'
            Console.Write("Enter character to replace: ");
            char oldChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
            string replacedString = input.Replace(oldChar, '$');
            Console.WriteLine($"Modified String: {replacedString}");

            // 4. Copy string, modify the copy, and print both
            string copiedString = input;
            string modifiedCopy = copiedString + " new string";
            Console.WriteLine($"Original String: {copiedString}");
            Console.WriteLine($"Modified Copy: {modifiedCopy}");
        }
    }
}