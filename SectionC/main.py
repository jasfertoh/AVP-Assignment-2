from Employee import Employee
from datetime import datetime
from functools import reduce


def read_hr_masterlist(file):
    employees = []
    try:
        with open(file, "r") as data:
            for line in data:
                employeeListLine = line.strip().split("|")
                employees.append(Employee(
                    employeeListLine[0],
                    employeeListLine[1],
                    employeeListLine[2],
                    datetime.strptime(employeeListLine[3], "%d/%m/%Y"),
                    employeeListLine[4],
                    employeeListLine[5],
                    employeeListLine[6],
                    employeeListLine[7],
                    float(employeeListLine[8])
                ))
    except:
        print(f"Error trying to read from {file}")
        exit(1)

    return employees


def main():
    file_path = './HRMasterlist.txt'
    employees = read_hr_masterlist(file_path)

    total_cost_reduced = reduce(
        lambda a, b: a + b,
        map(lambda employee: employee.salary,
            filter(lambda employee: employee.hireType == "PartTime" and 1995 < employee.startDate.year < 1999, employees))
    )
    print(
        f'Total cost reduced by the company from retrenchment: ${total_cost_reduced:.2f}')


if __name__ == "__main__":
    main()
