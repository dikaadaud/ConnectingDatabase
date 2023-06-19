using System.Data.SqlClient;

namespace ConnectingDatabase.Models
{
    public class Departments
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public int ManagerID { get; set; }


        public List<Departments> GetDepartment()
        {
            List<Departments> departments = new List<Departments>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_departments";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var debt = new Departments();
                        debt.Id = reader.GetInt32(0);
                        debt.Name = reader.GetString(1);
                        debt.LocationID = reader.GetInt32(2);
                        debt.ManagerID = reader.GetInt32(3);
                        departments.Add(debt);
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
            return departments;
        }
    }
}
