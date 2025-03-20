using System;
using System.Collections;
using System.Collections.Generic;

// Employee Class
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
    private SortedList<int, Employee> employeeList = new SortedList<int, Employee>();

    public bool AddEmployee(Employee e)
    {
        if (!employeeList.ContainsKey(e.EmployeeID))
        {
            employeeList.Add(e.EmployeeID, e);
            return true;
        }
        return false;
    }

    public bool DeleteEmployee(int id)
    {
        return employeeList.Remove(id);
    }

    public Employee SearchEmployee(int id)
    {
        return employeeList.ContainsKey(id) ? employeeList[id] : null;
    }

    public Employee[] GetAllEmployees()
    {
        return employeeList.Values.Count > 0 ? new List<Employee>(employeeList.Values).ToArray() : new Employee[0];
    }

    public void DisplayEmployees()
    {
        Employee[] employees = GetAllEmployees();
        if (employees.Length > 0)
        {
            Console.WriteLine("List of all Employees:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"ID: {e.EmployeeID}, Name: {e.EmployeeName}, Salary: {e.Salary}");
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
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

        empDal.DisplayEmployees();
        // Searching Employee
        Console.Write("Enter Employee ID to Search: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            Employee searchedEmp = empDal.SearchEmployee(searchId);
            if (searchedEmp != null)
            {
                Console.WriteLine($"Found Employee - ID: {searchedEmp.EmployeeID}, Name: {searchedEmp.EmployeeName}, Salary: {searchedEmp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Deleting Employee
        Console.Write("Enter Employee ID to Delete: ");
        if (int.TryParse(Console.ReadLine(), out int deleteId))
        {
            if (empDal.DeleteEmployee(deleteId))
            {
                Console.WriteLine($"Employee with ID {deleteId} has been deleted.");
            }
            else
            {
                Console.WriteLine("Employee not found for deletion.");
            }
        }

        // Display all employees after deletion
        empDal.DisplayEmployees();
    }
}
