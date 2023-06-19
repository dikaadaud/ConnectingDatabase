using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class LocationView
    {
        public Location Location { get; set; } = new Location();
        public void ShowGetLocations()
        {
            //ini Get Locations
            List<Location> locations = Location.GetLocations();
            foreach (var loc in locations)
            {
                Console.WriteLine($"id: {loc.Id} StreetAddress: {loc.StreetAddress} City: {loc.City}\n" +
                    $"StateProvince: {loc.StateProvince} Country_ID: {loc.CountryID}");
            }
        }
    }
}
