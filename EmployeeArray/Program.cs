using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

class Employee
{
    public string EmployeeName { get; set; }
    public int EmployeeID { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int id, double salary)
    {
        EmployeeName = name;
        EmployeeID = id;
        Salary = salary;
    }
}

// Employee Data Access Layer
class EmployeeDAL
{
    private ArrayList employeeList;

    public EmployeeDAL()
    {
        employeeList = new ArrayList();
    }

    public bool AddEmployee(Employee e)
    {
        employeeList.Add(e);
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        foreach (Employee e in employeeList)
        {
            if (e.EmployeeID == id)
            {
                employeeList.Remove(e);
                return true;
            }
        }
        return false;
    }

    public string SearchEmployee(int id)
    {
        foreach (Employee e in employeeList)
        {
            if (e.EmployeeID == id)
                return e.EmployeeName;
        }
        return null;
    }

    public Employee[] GetAllEmployees()
    {
        return (Employee[])employeeList.ToArray(typeof(Employee));
    }
}

// Test Program
class Program
{
    static void Main()
    {
        EmployeeDAL empDal = new EmployeeDAL();

        // Adding Employees
        empDal.AddEmployee(new Employee("John Doe", 101, 50000));
        empDal.AddEmployee(new Employee("Jane Smith", 102, 60000));
        empDal.AddEmployee(new Employee("Sam Wilson", 103, 55000));

        // Searching Employee
        Console.WriteLine("Searching Employee with ID 102: " + empDal.SearchEmployee(102));

        // Deleting Employee
        Console.WriteLine("Deleting Employee with ID 101: " + empDal.DeleteEmployee(101));

        // Listing all Employees
        Employee[] employees = empDal.GetAllEmployees();
        Console.WriteLine("List of all Employees:");
        foreach (Employee e in employees)
        {
            Console.WriteLine($"ID: {e.EmployeeID}, Name: {e.EmployeeName}, Salary: {e.Salary}");
        }
    }
}
