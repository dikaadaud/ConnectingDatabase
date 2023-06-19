using ConnectingDatabase.Models;
using ConnectingDatabase.View;
using System.Data.SqlClient;

namespace ConnectingDatabase.Controller
{
    public class RegionController
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public RegView regView = new RegView();
        public Helper helper = new Helper();
        public void MenuRegion()
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
                    regView.ShowRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 2:
                    Console.Clear();
                    regView.ShowRegionByid();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 3:
                    Console.Clear();
                    regView.ShowUpdateRegions();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 4:
                    Console.Clear();
                    regView.ShowDeleteRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                case 5:
                    Console.Clear();
                    regView.ShowInsertRegion();
                    Console.WriteLine();
                    MenuRegion();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
