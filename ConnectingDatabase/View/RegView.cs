using ConnectingDatabase.Models;

namespace ConnectingDatabase.View
{
    public class RegView
    {
        Region region = new Region();
        public void ShowRegion()
        {
            List<Region> reg = region.GetAllRegion();
            foreach (var regi in reg)
            {
                Console.WriteLine("id: {0} Name: {1}", regi.id, regi.name);
            }
        }

        public void ShowRegionByid()
        {
            Console.WriteLine("Masukan No Id Yang Ingin Di lihat: ");
            int id = region.helper.ValidasiINT();
            List<Region> reg = region.GetRegionByID(id);
            foreach (var region in reg)
            {
                Console.WriteLine($"ID: {region.id} ,nama: {region.name}");
            }
        }

        public void ShowUpdateRegions()
        {
            Console.WriteLine("Update");
            Console.WriteLine("Masukan Id Yang Ingin di Update");
            Console.Write("> ");
            int id = region.helper.ValidasiINT();
            Console.WriteLine("Masukan Nama Yang Ingin Di ganti");
            Console.Write("> ");
            string nama = region.helper.ValidasiString(1, 50);
            int isUpdateSuccess = region.UpdateRegion(id, nama);
            if (isUpdateSuccess > 0)
            {
                Console.WriteLine("Data Berhasil Di Update");
            }
            else
            {
                Console.WriteLine("Data Gagal Di Update");
            }
        }

        public void ShowInsertRegion()
        {
            Console.WriteLine("Insert");
            Console.Write("Masukan Nama Region:");
            string nama = region.helper.ValidasiString(1, 50);
            int isInserSuccessfull = region.InsertRegion(nama);
            if (isInserSuccessfull > 0)
            {
                Console.WriteLine("Data berhasil di tambhakan !!");
            }
            else Console.WriteLine("Data gagal di tambahkan !!");
        }
        public void ShowDeleteRegion()
        {
            Console.WriteLine("Delete");
            Console.WriteLine("Masukan id Yang ingin di delete");
            Console.Write("> ");
            int id = region.helper.ValidasiINT();
            int isSuccessful = region.DeleteRegion(id);
            if (isSuccessful > 0)
            {
                Console.WriteLine("Data Berhasil Di Delete");
            }
            else Console.WriteLine("Data Gagal Di Delete");
        }
    }
}
