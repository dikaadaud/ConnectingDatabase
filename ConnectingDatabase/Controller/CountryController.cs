using ConnectingDatabase.Models;
using ConnectingDatabase.View;

namespace ConnectingDatabase.Controller
{
    public class CountryController
    {
        public CounView CounView { get; set; } = new CounView();
        public Helper helper { get; set; } = new Helper();
        public void MenuCountry()
        {

            Console.WriteLine("===== Menu Countries =====");
            Console.WriteLine("1. See All Countries\n2. See Countries By ID\n3. Update Name Countries\n4. Delete Countries\n5. Insert Countries\n6. Back To Main Menu");
            Console.Write("> ");
            int input = helper.ValidasiINT(1, 6);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    CounView.ShowGetALlCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 2:
                    Console.Clear();
                    CounView.ShowGetCountryByID();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 3:
                    Console.Clear();
                    CounView.ShowUpdateCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 4:
                    Console.Clear();
                    CounView.ShowDeleteCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                case 5:
                    Console.Clear();
                    CounView.ShowInsertCountry();
                    Console.WriteLine();
                    MenuCountry();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
