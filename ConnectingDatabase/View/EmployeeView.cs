using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class EmployeeView
    {
        public Employee emp { get; set; } = new Employee();
        public void ShowGetEmployee()
        {
            // Get Employee
            List<Employee> employees = emp.GetEmployee();
            foreach (var emp in employees)
            {
                Console.WriteLine($"id: {emp.Id}, FirstName: {emp.FirstName}, LastName: {emp.LastName}\n" +
                    $"Email: {emp.Email}, PhoneNNumber: {emp.PhoneNumber} " +
                    $"Salary: {emp.Salary}, Commision: {emp.ComissionPct}, HireDate: {emp.HireDate}, " +
                    $"ManagerID: {emp.ManagerID}, JobID: {emp.JobID}, DepartmentID: {emp.DepartmentID}");
            }
        }
    }
}
