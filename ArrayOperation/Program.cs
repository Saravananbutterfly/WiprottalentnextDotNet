namespace ArrayOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            // Accept 10 integers from the user
            Console.WriteLine("Enter 10 integers:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // 1) Print elements in descending order (Manual Sorting - Bubble Sort)
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nElements in Descending Order:");
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // 2) Find Min and Max values
            int min = arr[0], max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }

            Console.WriteLine($"\nMinimum Value: {min}");
            Console.WriteLine($"Maximum Value: {max}");

            // 3) Calculate sum of all elements
            int sum = 0;
            foreach (var num in arr)
            {
                sum += num;
            }

            Console.WriteLine($"Sum of all elements: {sum}");
        }
    }
    
}