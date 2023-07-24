public class Employee
{
    public string? Nric { get; set; }
    public string? FullName { get; set; }
    public string? Salutation { get; set; }
    public DateTime StartDate { get; set; }
    public string? Designation { get; set; }
    public string? Department { get; set; }
    public string? MobileNo { get; set; }
    public string? HireType { get; set; }
    public double Salary { get; set; }
    public double MonthlyPayout { get; set; } = 0.0;

    public string FormatForCorpAdmin()
    {
        return $"{FullName}, {Designation}, {Department}";
    }

    public string FormatForProcurement()
    {
        return $"{Salutation}, {FullName}, {MobileNo}, {Designation}, {Department}";
    }

    public string FormatForITDepartment()
    {
        return $"{Nric}, {FullName}, {StartDate}, {Department}, {MobileNo}";
    }
}
