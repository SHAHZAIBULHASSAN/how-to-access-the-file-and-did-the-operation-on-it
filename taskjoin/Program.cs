using System;
using System.Threading;

namespace taskjoin
{

    class Program
    {
        static void Run()
        {
            for (int i = 0; i < 2; i++) Console.Write("C#corner");
        }
        static void Main(string[] args)
        {
            Thread th = new Thread(Run);
            th.Start();
            th.Join();
            Console.WriteLine("Thread t has terminated !");
            Console.Read();
        }
    }
}