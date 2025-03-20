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
    private ArrayList employeeList = new ArrayList();

    public bool AddEmployee(Employee e)
    {
        foreach (Employee emp in employeeList)
        {
            if (emp.EmployeeID == e.EmployeeID)
                return false; // Employee ID already exists
        }
        employeeList.Add(e);
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        foreach (Employee emp in employeeList)
        {
            if (emp.EmployeeID == id)
            {
                employeeList.Remove(emp);
                return true;
            }
        }
        return false;
    }

    public string SearchEmployee(int id)
    {
        foreach (Employee emp in employeeList)
        {
            if (emp.EmployeeID == id)
                return emp.EmployeeName;
        }
        return null;
    }

    public Employee[] GetAllEmployees()
    {
        return (Employee[])employeeList.ToArray(typeof(Employee));
    }

    public void DisplayEmployees()
    {
        if (employeeList.Count > 0)
        {
            Console.WriteLine("List of all Employees:");
            foreach (Employee e in employeeList)
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
        empDal.AddEmployee(new Employee("Sar", 101, 50000));
        empDal.AddEmployee(new Employee("Sai", 102, 60000));
        empDal.AddEmployee(new Employee("Ram", 103, 55000));
        empDal.DisplayEmployees();
        // Searching Employee
        Console.Write("Enter Employee ID to Search: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            string empName = empDal.SearchEmployee(searchId);
            if (empName != null)
            {
                Console.WriteLine($"Found Employee: {empName}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Display all employees after search
        empDal.DisplayEmployees();

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
