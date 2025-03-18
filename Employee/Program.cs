namespace Employee
{
    class Employee
    {
        // Properties
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; private set; }
        public decimal DA { get; private set; }
        public decimal GrossPay { get; private set; }
        public decimal Tax { get; private set; }
        public decimal NetPay { get; private set; }

        // Constructor
        public Employee(string name, decimal basicSalary)
        {
            EmployeeName = name;
            BasicSalary = basicSalary;
        }

        // Method to Calculate Salary Components
        public void CalculateNetPay()
        {
            HRA = BasicSalary * 0.15m;  // 15% of Basic Salary
            DA = BasicSalary * 0.10m;   // 10% of Basic Salary
            GrossPay = BasicSalary + HRA + DA;
            Tax = GrossPay * 0.08m;     // 8% of Gross Pay
            NetPay = GrossPay - Tax;
        }

        // Method to Display Salary Details
        public void Display()
        {
            Console.WriteLine($"Employee Name: {EmployeeName:F2}");
            Console.WriteLine($"Basic Salary: {BasicSalary:F2}");
            Console.WriteLine($"HRA (15%): {HRA:F2}");
            Console.WriteLine($"DA (10%): {DA:F2}");
            Console.WriteLine($"Gross Pay: {GrossPay:F2}");
            Console.WriteLine($"Tax (8%): {Tax:F2}");
            Console.WriteLine($"Net Pay: {NetPay:F2}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Employee emp = new Employee(name, salary);
            emp.CalculateNetPay();
            emp.Display();
        }
    }
}