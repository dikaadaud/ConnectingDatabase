namespace ConnectingDatabase.Models
{
    public class Helper
    {
        public int ValidasiINT()
        {
            int i;
            bool inputNumber = int.TryParse(Console.ReadLine(), out i);
            bool isValid = false;
            while (!isValid)
            {
                if (inputNumber == false)
                {
                    Console.WriteLine($"Harus Input Angka ");
                    Console.Write("> ");
                    inputNumber = int.TryParse(Console.ReadLine(), out i);
                }
                else
                {
                    isValid = true;
                }
            }
            return i;
        }
        public int ValidasiINT(int from, int to)
        {
            int i;
            bool inputNumber = int.TryParse(Console.ReadLine(), out i);
            bool isValid = false;
            while (!isValid)
            {
                if (inputNumber == false || i < from || i > to)
                {
                    Console.WriteLine($"Harus Input Angka {from} sampai {to}");
                    Console.Write("> ");
                    inputNumber = int.TryParse(Console.ReadLine(), out i);
                }
                else
                {
                    isValid = true;
                }
            }
            return i;
        }

        public string ValidasiString(int from, int to)
        {
            string input;
            input = Console.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if (input.Length < from || input.Length > to)
                {
                    Console.WriteLine($"Harus Input {from} sampai {to} Character");
                    Console.Write("> ");
                    input = Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }
            return input;
        }

        public DateTime ValidasiDatetime()
        {
            DateTime dt;
            bool date = DateTime.TryParse(Console.ReadLine(), out dt);
            bool isValid = false;
            while (!isValid)
            {
                if (date != true)
                {
                    Console.WriteLine("Harus input dengan format dd/MM/YYYY");
                    Console.Write("> ");
                    date = DateTime.TryParse(Console.ReadLine(), out dt);

                }
                else
                {
                    isValid = true;
                }
            }

            return dt;
        }
    }
}
