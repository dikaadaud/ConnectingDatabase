using System.Data.SqlClient;

namespace ConnectingDatabase
{
    public static class Menus
    {

        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public static Region region = new Region();
        public static Countries countries = new Countries();
        public static Location loc = new Location();
        public static Employee emp = new Employee();
        public static Departments dept = new Departments();
        public static Jobs jobs = new Jobs();
        public static Histories histories = new Histories();
        public static Helper helper = new Helper();
        public static void MainMenu()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("Welcome To CRUD Database");
            Console.WriteLine("1. All About Region Datbase\n2. All About Country\n3. All About See Another class\n4. Exit");
            Console.Write("> ");
            int input = helper.ValidasiINT(1, 4);
            switch (input)
            {
                case 1:
                    MenuRegion();
                    break;
                case 2:
                    MenuCountry();
                    break;
                case 3:
                    SeeAllValueTable();
                    break;
                default:
                    Console.WriteLine("Terimakasih Sudah Menggunakan Apliaksi ini !!");
                    Environment.Exit(0);
                    break;
            }
        }

        public static void MenuRegion()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("===== Menu Region =====");
            Console.WriteLine("1. See All Region\n2. See Region By ID\n3. Update Name Region\n4. Delete Region\n5. Insert Region\n6. Back To Main Menu");
            Console.Write("> ");
            int input = helper.ValidasiINT(1, 6);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    region.ShowRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 2:
                    Console.Clear();
                    region.ShowRegionByid();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 3:
                    Console.Clear();
                    region.ShowUpdateRegions();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 4:
                    Console.Clear();
                    region.ShowDeleteRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 5:
                    Console.Clear();
                    region.ShowInsertRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        public static void MenuCountry()
        {
            Console.WriteLine("===== Menu Countries =====");
            Console.WriteLine("1. See All Countries\n2. See Countries By ID\n3. Update Name Countries\n4. Delete Countries\n5. Insert Countries\n6. Back To Main Menu");
            Console.Write("> ");
            int input = helper.ValidasiINT(1, 6);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    countries.ShowGetALlCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 2:
                    Console.Clear();
                    countries.ShowGetCountryByID();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 3:
                    Console.Clear();
                    countries.ShowUpdateCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 4:
                    Console.Clear();
                    countries.ShowDeleteCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 5:
                    Console.Clear();
                    countries.ShowInsertCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        public static void SeeAllValueTable()
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
            int input = helper.ValidasiINT(1, 6);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    emp.ShowGetEmployee();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 2:
                    Console.Clear();
                    loc.ShowGetLocations();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 3:
                    Console.Clear();
                    jobs.ShowGetJobs();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 4:
                    Console.Clear();
                    histories.ShowGetHistories();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                case 5:
                    Console.Clear();
                    dept.ShowGetDepartments();
                    Console.WriteLine();
                    SeeAllValueTable();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}
