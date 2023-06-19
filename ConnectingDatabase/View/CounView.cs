using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class CounView
    {
        public Countries Countries { get; set; } = new Countries();
        public void ShowGetALlCountry()
        {
            // ini Get Country
            List<Countries> con = Countries.GetCountry();
            foreach (var country in con)
            {
                Console.WriteLine($"id: {country.id} Name: {country.name} region_id: {country.RegionId}");
            }
        }
        public void ShowGetCountryByID()
        {
            //search by ID Country
            Console.WriteLine("Masukan No Id Yang Ingin Di lihat: ");
            string id = Countries.helper.ValidasiString(1, 50);
            List<Countries> countries = Countries.GetCountryByID(id);
            foreach (var c in countries)
            {
                Console.WriteLine($"ID: {c.id}  ,nama:  {c.name}, RegionID: {c.RegionId}");
            }
        }

        public void ShowInsertCountry()
        {
            //Insert Country
            Console.WriteLine("Insert");
            Console.WriteLine("Masukan Nama Country:");
            Console.Write("> ");
            string nama = Countries.helper.ValidasiString(1, 50);
            Console.WriteLine("Masukan Id Country (2 Character)");
            Console.Write("> ");
            string id = Countries.helper.ValidasiString(1, 50);
            Console.WriteLine("Masukan id Region:");
            Console.Write("> ");
            int regId = Countries.helper.ValidasiINT();
            int isInsertSuccess = Countries.InsertCountry(nama, id, regId);
            if (isInsertSuccess > 0)
            {
                Console.WriteLine("Data Berhasil Di Tambahkan !! ");
            }
            else Console.WriteLine("Data Gagal Di Tambahkan !!");
        }

        public void ShowUpdateCountry()
        {
            // Update Country
            Console.WriteLine("Update");
            Console.WriteLine("Masukan Id Yang Ingin di Update");
            Console.Write("> ");
            string id = Countries.helper.ValidasiString(2, 2);
            Console.WriteLine("Masukan Nama Yang Ingin Di ganti");
            Console.Write("> ");
            string nama = Countries.helper.ValidasiString(1, 50);
            int isUpdateSuccess = Countries.UpdateCountry(id, nama);
            if (isUpdateSuccess > 0)
            {
                Console.WriteLine("Data Berhasil Di Update");
            }
            else
            {
                Console.WriteLine("Data Gagal Di Update");
            }
        }

        public void ShowDeleteCountry()
        {
            Console.WriteLine("Delete");
            Console.WriteLine("Masukan id Yang ingin di delete");
            Console.Write("> ");
            string input = Countries.helper.ValidasiString(2, 2);
            int isSuccessfull = Countries.DeleteCountry(input);
            if (isSuccessfull > 0)
            {
                Console.WriteLine("Data Berhasil Di Delete");
            }
            else Console.WriteLine("Data Gagal Di Delete");
        }
    }
}
