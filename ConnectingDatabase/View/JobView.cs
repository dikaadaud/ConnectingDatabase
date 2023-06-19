using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class JobView
    {
        public Jobs Jobs { get; set; } = new Jobs();
        public void ShowGetJobs()
        {
            //Get Jobs
            List<Jobs> jobs = Jobs.GetJobs();
            foreach (var j in jobs)
            {
                Console.WriteLine($"ID: {j.Id}, title: {j.Title}, MinSalary: {j.MinSalary}, MaxSalary: {j.MaxSalary}");
            }
        }
    }
}
