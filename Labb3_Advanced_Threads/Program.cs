namespace Labb3_Advanced_Threads
{
    internal class Program
    {
        public static List<Vehicles>carList=new List<Vehicles>();
        static void Main(string[] args)
        {
            Vehicles Volvo = new Vehicles(0, "Volvo");
            Vehicles Koenigsegg = new Vehicles(1, "Koenigsegg");

            carList.Add(Volvo);
            carList.Add(Koenigsegg);

            Thread cartrack1 = new Thread(Volvo.Drive);
            Thread cartrack2=new Thread(Koenigsegg.Drive);

            Thread status1 = new Thread(StatusChecker);

            cartrack1.Start();
            cartrack2.Start();
            status1.Start();
        }
        static void StatusChecker()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    Console.WriteLine("----Status----");
                    foreach(var item in carList)
                    {
                        Console.WriteLine("The car with the name {0} has driven {1} meters and is currently holding the speed {2}\n",item.Name,Math.Round(item.Stretch),item.Speed);
                    }
                }
            }
        }
    }
}