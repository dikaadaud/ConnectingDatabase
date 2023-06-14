using System.Data.SqlClient;

namespace ConnectingDatabase
{
    public class Employee
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal ComissionPct { get; set; }
        public int ManagerID { get; set; }
        public string JobID { get; set; }
        public int DepartmentID { get; set; }

        public void ShowGetEmployee()
        {
            // Get Employee
            List<Employee> employees = GetEmployee();
            foreach (var emp in employees)
            {
                Console.WriteLine($"id: {emp.Id}, FirstName: {emp.FirstName}, LastName: {emp.LastName}\n" +
                    $"Email: {emp.Email}, PhoneNNumber: {emp.PhoneNumber} " +
                    $"Salary: {emp.Salary}, Commision: {emp.ComissionPct}, HireDate: {emp.HireDate}, " +
                    $"ManagerID: {emp.ManagerID}, JobID: {emp.JobID}, DepartmentID: {emp.DepartmentID}");
            }
        }
        public List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_Employee where comission_pct is not null";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.ComissionPct = reader.GetDecimal(7);
                        emp.ManagerID = reader.GetInt32(8);
                        emp.JobID = reader.GetString(9);
                        emp.DepartmentID = reader.GetInt32(10);
                        employees.Add(emp);
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
            return employees;
        }
    }
}
