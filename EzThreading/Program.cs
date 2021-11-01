using System;
using System.Threading;

namespace EzThreading
{
    class Program
    {
        static Temperature temp = new Temperature();
        static TimeSpan interval = new TimeSpan(0, 0, 1);
        static Thread t3;
        static char ch = '*';
        static ConsoleKey input = Console.ReadKey().Key;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ShowMessage);
            Thread t2 = new Thread(ShowMessage2);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            t3 = new Thread(ChangeTemperature);
            t3.Start();

            t3.Join();
            if (CheckIfT3IsAlive())
                Environment.Exit(0);

            Thread t4 = new Thread(PrintCH);
            Thread t5 = new Thread(ChangeCH);
            t4.Start();
            t5.Start();
            t4.Join();
            t5.Join();
            Console.ReadKey();
        }

        static void PrintCH()
        {
            while (true)
            {
                Console.Write(ch);
                Thread.Sleep(interval / 2);
            }
        }

        static void ChangeCH()
        {
            while (true)
            {
                char temp = ((char)Console.ReadKey().Key);
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    ch = temp;
                }

            }
        }

        public static bool CheckIfT3IsAlive()
        {
            while (true)
            {
                if (!t3.IsAlive)
                {
                    Console.WriteLine("Alarm tråd termineret!");
                    return false;
                }
                Thread.Sleep(interval * 10);
            }
        }

        public static void ChangeTemperature()
        {
            while (true)
            {
                temp.GenerateRandomTemperature();
                if (temp.Temp < 0 || temp.Temp > 100)
                    Console.WriteLine("Alert!! temperature is: " + temp.Temp);
                else
                    Console.WriteLine($"Temperature is: {temp.Temp}");
                Thread.Sleep(interval);
            }
        }

        static void ShowMessage()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C# trådning er nemt!");
                Thread.Sleep(interval);
            }
        }

        static void ShowMessage2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde");
                Thread.Sleep(interval);

            }
        }
    }
}
