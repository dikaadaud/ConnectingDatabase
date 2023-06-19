using ConnectingDatabase.Models;
using ConnectingDatabase.View;

namespace ConnectingDatabase.Controller
{
    public class SeeAllController
    {
        public Helper Helper { get; set; } = new Helper();
        public EmployeeView Employee { get; set; } = new EmployeeView();
        public DepartmentView Department { get; set; } = new DepartmentView();
        public HistoriesView Histories { get; set; } = new HistoriesView();
        public JobView Job { get; set; } = new JobView();
        public LocationView Location { get; set; } = new LocationView();
        public void SeeAllValueTable()
        {
            Console.WriteLine("===== Menu See All Value Table Database =====");
            Console.WriteLine("1. Table Employee\n" +
                "2. Table Location\n" +
                "3. Table Jobs\n" +
                "4. Table Histories\n" +
                "5. Table Department\n" +
                "6. Back to Main Menu");
            Console.WriteLine("Masukan Menu Yang Ingin Dipilih:");
            Console.Write("> ");
            int input = Helper.ValidasiINT(1, 6);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Employee.ShowGetEmployee();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 2:
                    Console.Clear();
                    Location.ShowGetLocations();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 3:
                    Console.Clear();
                    Job.ShowGetJobs();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 4:
                    Console.Clear();
                    Histories.ShowGetHistories();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 5:
                    Console.Clear();
                    Department.ShowGetDepartments();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
