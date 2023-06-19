using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class DepartmentView
    {
        public Departments Departments { get; set; } = new Departments();
        public void ShowGetDepartments()
        {
            //Get Department
            List<Departments> departments = Departments.GetDepartment();
            foreach (var debt in departments)
            {
                Console.WriteLine($"ID: {debt.Id}, Name: {debt.Name}, LocationID: {debt.LocationID}, managerID: {debt.ManagerID}");
            }
        }
    }
}
