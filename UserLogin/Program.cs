namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string correctLogin = "user";
            string correctPassword = "Password@123";
            int attempts = 3;

            while (attempts > 0)
            {
                Console.Write("Enter Login: ");
                string login = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (login == correctLogin && password == correctPassword)
                {
                    Console.WriteLine("Login Successful!");
                    return;
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Invalid credentials. {attempts} attempts left.");
                }
            }

            Console.WriteLine("Access Denied. Too many failed attempts.");
        }
    }
}