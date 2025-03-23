namespace DelegatesCalculator
{
    public delegate double MathOperation(double a, double b);

    class Calculator
    {
        // Mathematical operations
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return double.NaN;
            }
            return a / b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperation add = new MathOperation(Calculator.Add);
            MathOperation subtract = new MathOperation(Calculator.Subtract);
            MathOperation multiply = new MathOperation(Calculator.Multiply);
            MathOperation divide = new MathOperation(Calculator.Divide);

            // Test values
            double num1 = 10, num2 = 5;

            // Invoking delegate methods
            Console.WriteLine($"Addition: {add(num1, num2)}");
            Console.WriteLine($"Subtraction: {subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {multiply(num1, num2)}");
            Console.WriteLine($"Division: {divide(num1, num2)}");
        }
    }
}