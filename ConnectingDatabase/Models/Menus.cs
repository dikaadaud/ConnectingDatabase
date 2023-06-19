using ConnectingDatabase.Controller;
using System.Data.SqlClient;

namespace ConnectingDatabase.Models
{
    public class Menus
    {

        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public RegionController Reg = new RegionController();
        public CountryController Country = new CountryController();
        public SeeAllController See = new SeeAllController();
        public Helper Helper = new Helper();
        public void MainMenu()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("Welcome To CRUD Database");
            Console.WriteLine("1. All About Region Datbase\n2. All About Country\n3. All About See Another class\n4. Exit");
            Console.Write("> ");
            int input = Helper.ValidasiINT(1, 4);
            switch (input)
            {
                case 1:
                    Reg.MenuRegion();
                    break;
                case 2:
                    Country.MenuCountry();
                    break;
                case 3:
                    See.SeeAllValueTable();
                    break;
                default:
                    Console.WriteLine("Terimakasih Sudah Menggunakan Apliaksi ini !!");
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
