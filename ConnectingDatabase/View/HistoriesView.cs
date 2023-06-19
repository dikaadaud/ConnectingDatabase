using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class HistoriesView
    {
        public Histories Histories { get; set; } = new Histories();
        public void ShowGetHistories()
        {
            // Get History
            List<Histories> history = Histories.GetHistories();
            foreach (var h in history)
            {
                Console.WriteLine($"Start Date: {h.StartDate}, EmployeeID: {h.EmployeeID}, " +
                    $"End Date: {h.EndDate}, DepartmentID: {h.DepartmentID}, JobID: {h.JobID}");
            }

        }
    }
}
