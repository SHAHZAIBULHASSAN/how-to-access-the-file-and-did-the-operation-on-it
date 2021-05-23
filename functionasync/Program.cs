using System;
using System.Threading.Tasks;

namespace functionasync
{
    class Program
    {
        static void Main(string[] args)
        {
         //   Console.WriteLine("Hello World!");
            Method1();
            Method2();
            Console.ReadKey();
        }
            public static async Task Method1()
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(" Method 1");
                        // Do something
                     //   Task.Delay(100).Wait();
                    }
                });
            }


            public static void Method2()
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(" Method 2");
                    // Do something
                    Task.Delay(100).Wait();
                }
            }
        }
    }

