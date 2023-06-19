using System.Data.SqlClient;

namespace ConnectingDatabase.Models
{
    internal class Program
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        static void Main(string[] args)
        {

            connection = new SqlConnection(connectionString);
            Menus menu = new Menus();
            menu.MainMenu();

        }

    }
}