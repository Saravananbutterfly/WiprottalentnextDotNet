using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string Designation { get; set; }
    public DateTime JoiningDate { get; set; }
    public string DepartmentName { get; set; }

    public Employee(int id, string name, string designation, DateTime joiningDate, string department)
    {
        EmployeeID = id;
        EmployeeName = name;
        Designation = designation;
        JoiningDate = joiningDate;
        DepartmentName = department;
    }
}

class EmployeeData
{
    public List<Employee> EmployeeInfo { get; set; } = new List<Employee>();
    private string filePath = "EmployeeData.csv";

    public void AddEmployee(Employee emp)
    {
        EmployeeInfo.Add(emp);
        SaveToFile();
    }

    private void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath, true)) // Append mode
        {
            foreach (var emp in EmployeeInfo)
            {
                writer.WriteLine($"{emp.EmployeeID},{emp.EmployeeName},{emp.Designation},{emp.JoiningDate.ToShortDateString()},{emp.DepartmentName}");
            }
        }
        EmployeeInfo.Clear(); // Clear the list to avoid duplicate entries on next save
    }
}

class Program
{
    static void Main()
    {
        EmployeeData empData = new EmployeeData();

        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Designation: ");
        string designation = Console.ReadLine();

        Console.Write("Enter Joining Date (yyyy-mm-dd): ");
        DateTime joiningDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Department Name: ");
        string department = Console.ReadLine();

        Employee newEmp = new Employee(id, name, designation, joiningDate, department);
        empData.AddEmployee(newEmp);

        Console.WriteLine("Employee details saved successfully!");
    }
}
