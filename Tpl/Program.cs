using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace tpl
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Run
           var a =Task.Run(()=>
             Console.WriteLine("hello")
            
            );
            #endregion
            #region task
            var b = new Task(() =>

            // call the new function
                Functon()
                )  ;
            b.Start();
            #endregion
              #region task factory startnew
             var c = Task.Factory.StartNew(Function2).ContinueWith((prev) => Functon3(1, 2));
            var n = Task.Factory.StartNew(Function2).ContinueWith((prev) => Functon3(7, 8));
            var j = new List<Task> { c, n };
            #endregion
            #region waitall
             Task.WaitAll(j.ToArray());
            #endregion

            #region for and parallel for differnce
              for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("simple number {0}", i);
            }
            //use the parallell for
            int no = 10;
            Parallel.For(0, no, i =>
            {
                Console.WriteLine("this is the value of i  {0}",i);
            }

            );
            int ii = 12;
            Parallel.For(0, ii, i =>
             {
                 Console.WriteLine( "value of other i  =={0}",i);
             });
            #endregion

            #region  foreach and parallel 


          int[] arr = new int[] { 1, 2, 3, 4, 5, 6,7, 8 };
            foreach (var item in arr)
            {
                Console.WriteLine("this is foreach function =={0}",item);

            }
            //  parallell foreach
            Parallel.ForEach(arr, i =>

             {
                 Console.WriteLine("this is for each in parallell=={0}",i);
             }

            );
            #endregion





            #region parallell invoke function
         Parallel.Invoke(() =>
            {
                Console.WriteLine("This code is running on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            });
            #endregion
           
            


            Console.ReadLine();

        }

        private static void Functon3(int v1, int v2)
        {
            Console.WriteLine($"value of {v1} and value of two {v2}");
        }

        private static void Function2()
        {
            Console.WriteLine("this is task factory start new function");
        }

        private static void Functon()
        {
            Console.WriteLine("this is new function");
        }
    }
}
