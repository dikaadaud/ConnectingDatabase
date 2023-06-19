using System.Data;
using System.Data.SqlClient;

namespace ConnectingDatabase.Models
{
    public class Region
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public Helper helper = new Helper();
        public int id { get; set; }
        public string name { get; set; }
        public List<Region> GetAllRegion()
        {
            var region = new List<Region>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Command Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_regions";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.id = reader.GetInt32(0);
                        reg.name = reader.GetString(1);
                        region.Add(reg);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found !!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return region;
        }

        public List<Region> GetRegionByID(int id)
        {
            List<Region> reg = new List<Region>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_regions where id = @id";

                SqlParameter parameter = new SqlParameter();
                parameter.Value = id;
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameter);

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region();
                        region.id = reader.GetInt32(0);
                        region.name = reader.GetString(1);
                        reg.Add(region);
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
            return reg;
        }

        public int DeleteRegion(int id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from tb_m_regions where id = @id ";
                cmd.Transaction = transaction;

                SqlParameter pID = new SqlParameter();
                pID.ParameterName = "@id";
                pID.Value = id;
                pID.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(pID);
                result = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
            }
            connection.Close();
            return result;
        }

        public int UpdateRegion(int id, string nama)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "update tb_m_regions set name = @reg_name where id = @id ";
                command.Connection = connection;
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@reg_name";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pID = new SqlParameter();
                pID.ParameterName = "@id";
                pID.Value = id;
                pID.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName);
                command.Parameters.Add(pID);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {

                    Console.WriteLine(rollback);

                }
            }
            connection.Close();
            return result;
        }

        public int InsertRegion(string name)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert into tb_m_regions (name) values (@region_name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan Parameter ke Command
                command.Parameters.Add(pName);

                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {

                    Console.WriteLine(rollback);

                }
            }
            connection.Close();
            return result;
        }

    }
}
