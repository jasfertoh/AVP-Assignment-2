class Employee:
    def __init__(self, nric, fullName, salutation, startDate, designation, department, mobileNo, hireType, salary, monthlyPayout=0.0):
        self.nric = nric
        self.fullName = fullName
        self.salutation = salutation
        self.startDate = startDate
        self.designation = designation
        self.department = department
        self.mobileNo = mobileNo
        self.hireType = hireType
        self.salary = salary
        self.monthlyPayout = monthlyPayout
