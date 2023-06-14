using System.Data;
using System.Data.SqlClient;

namespace ConnectingDatabase
{
    public class Countries
    {
        static string connectionString = "Data Source=LAPTOP-SD0D08EF;Database = db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public Helper helper = new Helper();
        public string id { get; set; }
        public string name { get; set; }
        public int RegionId { get; set; }

        //Getall Country
        public void ShowGetALlCountry()
        {
            // ini Get Country
            List<Countries> con = GetCountry();
            foreach (var country in con)
            {
                Console.WriteLine($"id: {country.id} Name: {country.name} region_id: {country.RegionId}");
            }
        }
        public List<Countries> GetCountry()
        {
            List<Countries> country = new List<Countries>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_Countries";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cont = new Countries();
                        cont.id = reader.GetString(0);
                        cont.name = reader.GetString(1);
                        cont.RegionId = reader.GetInt32(2);
                        country.Add(cont);
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
            return country;
        }

        //getcountry by id
        public void ShowGetCountryByID()
        {
            //search by ID Country
            Console.WriteLine("Masukan No Id Yang Ingin Di lihat: ");
            string id = helper.ValidasiString(1, 50);
            List<Countries> countries = GetCountryByID(id);
            foreach (var c in countries)
            {
                Console.WriteLine($"ID: {c.id}  ,nama:  {c.name}, RegionID: {c.RegionId}");
            }
        }

        static List<Countries> GetCountryByID(string id)
        {
            List<Countries> cont = new List<Countries>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * From tb_m_countries where id = @id";

                SqlParameter parameter = new SqlParameter();
                parameter.Value = id;
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(parameter);

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var count = new Countries();
                        count.id = reader.GetString(0);
                        count.name = reader.GetString(1);
                        count.RegionId = reader.GetInt32(2);
                        cont.Add(count);
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
            return cont;
        }




        //Insert
        public void ShowInsertCountry()
        {
            //Insert Country
            Console.WriteLine("Insert");
            Console.WriteLine("Masukan Nama Country:");
            Console.Write("> ");
            string nama = helper.ValidasiString(1, 50);
            Console.WriteLine("Masukan Id Country (2 Character)");
            Console.Write("> ");
            string id = helper.ValidasiString(1, 50);
            Console.WriteLine("Masukan id Region:");
            Console.Write("> ");
            int regId = helper.ValidasiINT();
            int isInsertSuccess = InsertCountry(nama, id, regId);
            if (isInsertSuccess > 0)
            {
                Console.WriteLine("Data Berhasil Di Tambahkan !! ");
            }
            else Console.WriteLine("Data Gagal Di Tambahkan !!");
        }

        // Insert Country
        public static int InsertCountry(string name, string id, int regId)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert into tb_m_countries (id,name,region_id) VALUES (@id,@country_name,@regionId)";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter rId = new SqlParameter();
                rId.ParameterName = "@regionId";
                rId.Value = regId;
                rId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName);
                command.Parameters.Add(pId);
                command.Parameters.Add(rId);
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
        //Update
        public void ShowUpdateCountry()
        {
            // Update Country
            Console.WriteLine("Update");
            Console.WriteLine("Masukan Id Yang Ingin di Update");
            Console.Write("> ");
            string id = helper.ValidasiString(2, 2);
            Console.WriteLine("Masukan Nama Yang Ingin Di ganti");
            Console.Write("> ");
            string nama = helper.ValidasiString(1, 50);
            int isUpdateSuccess = UpdateCountry(id, nama);
            if (isUpdateSuccess > 0)
            {
                Console.WriteLine("Data Berhasil Di Update");
            }
            else
            {
                Console.WriteLine("Data Gagal Di Update");
            }
        }
        //Update Country
        public static int UpdateCountry(string id, string nama)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "update tb_m_countries set name = @country_name where id = @id ";
                command.Connection = connection;
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pID = new SqlParameter();
                pID.ParameterName = "@id";
                pID.Value = id;
                pID.SqlDbType = SqlDbType.VarChar;

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




        //Delete
        public void ShowDeleteCountry()
        {
            Console.WriteLine("Delete");
            Console.WriteLine("Masukan id Yang ingin di delete");
            Console.Write("> ");
            string input = helper.ValidasiString(2, 2);
            int isSuccessfull = DeleteCountry(input);
            if (isSuccessfull > 0)
            {
                Console.WriteLine("Data Berhasil Di Delete");
            }
            else Console.WriteLine("Data Gagal Di Delete");
        }
        public static int DeleteCountry(string id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from tb_m_countries where id = @id ";
                cmd.Transaction = transaction;

                SqlParameter pID = new SqlParameter();
                pID.ParameterName = "@id";
                pID.Value = id;
                pID.SqlDbType = SqlDbType.VarChar;

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
    }
}
