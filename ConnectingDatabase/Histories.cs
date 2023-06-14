using System.Data.SqlClient;

namespace ConnectingDatabase
{
    public class Histories
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string JobID { get; set; }

        public void ShowGetHistories()
        {
            // Get History
            List<Histories> history = GetHistories();
            foreach (var h in history)
            {
                Console.WriteLine($"Start Date: {h.StartDate}, EmployeeID: {h.EmployeeID}, " +
                    $"End Date: {h.EndDate}, DepartmentID: {h.DepartmentID}, JobID: {h.JobID}");
            }
        }
        static List<Histories> GetHistories()
        {
            List<Histories> Histories = new List<Histories>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_tr_histories";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var his = new Histories();
                        his.StartDate = reader.GetDateTime(0);
                        his.EmployeeID = reader.GetInt32(1);
                        his.EndDate = reader.GetDateTime(2);
                        his.DepartmentID = reader.GetInt32(3);
                        his.JobID = reader.GetString(4);
                        Histories.Add(his);
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
            return Histories;
        }
    }
}
