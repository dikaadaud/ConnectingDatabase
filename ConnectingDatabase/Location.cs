using System.Data.SqlClient;

namespace ConnectingDatabase
{
    public class Location
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryID { get; set; }

        public void ShowGetLocations()
        {
            //ini Get Locations
            List<Location> locations = GetLocations();
            foreach (var loc in locations)
            {
                Console.WriteLine($"id: {loc.Id} StreetAddress: {loc.StreetAddress} City: {loc.City}\n" +
                    $"StateProvince: {loc.StateProvince} Country_ID: {loc.CountryID}");
            }
        }

        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_Locations";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Location();
                        loc.Id = reader.GetInt32(0);
                        loc.StreetAddress = reader.GetString(1);
                        loc.PostalCode = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.StateProvince = reader.GetString(4);
                        loc.CountryID = reader.GetString(5);
                        locations.Add(loc);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found !!");
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            connection.Close();
            return locations;
        }
    }

}
