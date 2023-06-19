using System.Data.SqlClient;

namespace ConnectingDatabase.Models
{
    public class Jobs
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public void ShowGetJobs()
        {
            //Get Jobs
            List<Jobs> jobs = GetJobs();
            foreach (var j in jobs)
            {
                Console.WriteLine($"ID: {j.Id}, title: {j.Title}, MinSalary: {j.MinSalary}, MaxSalary: {j.MaxSalary}");
            }
        }
        public List<Jobs> GetJobs()
        {
            List<Jobs> Jobs = new List<Jobs>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_Jobs";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);
                        Jobs.Add(job);
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
            return Jobs;
        }
    }
}
