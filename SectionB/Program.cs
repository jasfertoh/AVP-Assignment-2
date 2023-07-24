using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using SectionA;
namespace SectionB;
public class Program
{

    static void processPayroll(List<Employee> employees)
    {
        double totalPayrollAmount = 0;

        foreach (Employee employee in employees)
        {
            bool parsed = Enum.TryParse<HireType>(employee.HireType, out HireType hiretype);

            if (!parsed)
            {
                Console.WriteLine("Invalid Hire Type data");
                Environment.Exit(1);
            }

            switch (hiretype)
            {
                case HireType.FullTime:
                    employee.MonthlyPayout = employee.Salary;
                    break;
                case HireType.PartTime:
                    employee.MonthlyPayout = 0.4 * employee.Salary;
                    break;
                case HireType.Hourly:
                    employee.MonthlyPayout = 0.2 * employee.Salary;
                    break;
            }
            totalPayrollAmount += employee.MonthlyPayout;

            Console.WriteLine($"{employee.FullName} (S{employee.Nric})");
            Console.WriteLine($"{employee.Designation}");
            Console.WriteLine($"{hiretype.ToString()} Payout: ${employee.MonthlyPayout}\n----------------------------");
        }

        Console.WriteLine($"Total Payroll Amount: ${totalPayrollAmount} to be paid to {employees.Count} employees.");

    }

    static void updateMonthlyPayoutToMasterlist(List<Employee> employees)
    {
        List<string> lines = new List<string>();
        foreach (var emp in employees)
        {
            lines.Add($"{emp.Nric}|{emp.FullName}|{emp.Salutation}|{emp.StartDate.ToString("dd/MM/yyyy")}|{emp.Designation}|{emp.Department}|{emp.MobileNo}|{emp.HireType}|{emp.Salary}|{emp.MonthlyPayout}");
        }
        File.WriteAllLines("HRMasterlistB.txt", lines);
    }
    static async Task Main(string[] args)
    {
        // Read the HRMasterlist.txt and get a list of employees
        List<Employee> employees = SectionA.Program.readHRMasterList();

        // Calculate monthly payout for each employee
        await Task.Run(() => processPayroll(employees));

        // Update monthly payout to HRMasterlistB.txt
        updateMonthlyPayoutToMasterlist(employees);

        // Wait for user input to keep the console open
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
