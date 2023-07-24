
using System;
using System.Collections.Generic;

using System.Globalization;
using System.IO;

namespace SectionA;
public class Program
{
    public static List<Employee> readHRMasterList()
    {
        string line;
        List<Employee> employees = new List<Employee>();
        System.IO.StreamReader file = new System.IO.StreamReader("../HRMasterlist.txt");
        while ((line = file.ReadLine()!) != null)
        {
            string[] employeeListLine = line.Split("|");
            employees.Add(
                new Employee
                {
                    Nric = employeeListLine[0],
                    FullName = employeeListLine[1],
                    Salutation = employeeListLine[2],
                    StartDate = DateTime.ParseExact(
                        employeeListLine[3],
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ),
                    Designation = employeeListLine[4],
                    Department = employeeListLine[5],
                    MobileNo = employeeListLine[6],
                    HireType = employeeListLine[7],
                    Salary = Double.Parse(employeeListLine[8])
                }
            );
        }
        file.Close();
        return employees;
    }
    static void generateInfoForCorpAdmin(List<Employee> employees)
    {
        List<string> lines = new List<string>();
        foreach (var emp in employees)
        {
            lines.Add(emp.FormatForCorpAdmin());
        }

        File.WriteAllLines("CorporateAdmin.txt", lines);
    }

    static void generateInfoForProcurement(List<Employee> employees)
    {
        List<string> lines = new List<string>();
        foreach (var emp in employees)
        {
            lines.Add(emp.FormatForProcurement());
        }
        File.WriteAllLines("Procurement.txt", lines);
    }

    static void generateInfoForITDepartment(List<Employee> employees)
    {
        List<string> lines = new List<string>();
        foreach (var emp in employees)
        {
            lines.Add(emp.FormatForITDepartment());
        }
        File.WriteAllLines("ITDepartment.txt", lines);
    }

    static void Main()
    {
        // Read the HRMasterlist.txt and get a list of employees
        List<Employee> employees = readHRMasterList();

        // Define delegates for the three generation methods
        Action<List<Employee>> generateCorpAdminDelegate = generateInfoForCorpAdmin;
        Action<List<Employee>> generateProcurementDelegate = generateInfoForProcurement;
        Action<List<Employee>> generateITDelegate = generateInfoForITDepartment;

        // Combine delegates into a single delegate
        Action<List<Employee>> allGenerationsDelegate = generateCorpAdminDelegate +
            generateProcurementDelegate + generateITDelegate;

        // Invoke all the methods using the single delegate
        allGenerationsDelegate(employees);
    }
}

