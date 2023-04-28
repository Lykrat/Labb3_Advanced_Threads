using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_Advanced_Threads
{
    public class Vehicles
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Stretch { get; set; }
        public double Speed { get; set; }

        public Vehicles(int iD, string name)
        {
            ID = iD;
            Name = name;
            Stretch = 0;
            Speed = 120;
        }
        private static int Participants;
        public async void Drive()
        {
            Console.WriteLine("The car with the name {0} started driving\n",Name);
            Participants++;
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            bool test = true;
            while (test)
            {
                if (sw.Elapsed.TotalSeconds > 15)
                {
                    EventHandler();
                    sw.Restart();
                }

                if (Stretch <= 10000)
                {
                    Stretch += ((Speed / 3.6));
                    Thread.Sleep(500);
                }
                else
                {
                    if (Participants == 2)
                    {
                        Console.WriteLine("{0} won the race\n",Name);
                    }
                    else
                    {
                        Console.WriteLine("A car with the name {0} finished the race\n", Name);
                    }
                    Participants--;
                    sw.Stop();
                    test = false;
                }            
            }
        }
        public void EventHandler()
        {
            Random random= new Random();

            int rnd1 = random.Next(1, 51);
            int rnd2 = random.Next(1, 26);
            int rnd3 = random.Next(1, 11);
            int rnd4 = random.Next(1, 6);

            if (rnd1 == 1)
            {
                Console.WriteLine("{0} is out of gas and needs to refill the tank\n",Name);
                Thread.Sleep(30000);
            }
            else if(rnd2 == 1)
            {
                Console.WriteLine("{0}s tires exploded and they need to be replaced\n",Name);
                Thread.Sleep(20000);
            }
            else if (rnd3 == 1)
            {
                Console.WriteLine("{0} got a bird on the windscreen wich needs to be cleaned\n",Name);
                Thread.Sleep(10000);
            }
            else if (rnd4 == 1)
            {
                Console.WriteLine("{0} got an engine error and goes down a 1km/h\n",Name);
                Speed--;
            }
        }
    }
}
