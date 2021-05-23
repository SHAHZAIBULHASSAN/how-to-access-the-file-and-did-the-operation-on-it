using System;
using System.Threading;
using System.Threading.Tasks;

namespace tasktypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AnotheFun();
        }

        private static void AnotheFun()
        {
            var text1 = Task.Run(() =>
         {
          int y=   GetNumberb();
             return y;

         });


            var e = Task.Run(() =>

              {
         
              int b=    GetNumber2();
                  return b;
              }


            );
            Task.WaitAll(text1, e);
            var aa = text1.GetAwaiter();
            
                var number1= aa.GetResult();

            
                
            var bb = e.GetAwaiter();
            
            
            var number2 = bb.GetResult();
            Sum(number1, number2);
        }

        private static void Sum(int number1, int number2)
        {
            Thread.Sleep(3000);
            Console.WriteLine($" sum of two numbers ==={number2+number1}");
           
        }

        private   static int  GetNumber2()
        {
            Console.WriteLine("please enter number a");
            string a = Console.ReadLine();
            int aa = Convert.ToInt32(a);
           
            return aa;
        }

        private static int GetNumberb()
        {
            Console.WriteLine("please enter number b");
            string b = Console.ReadLine();
            int bb = Convert.ToInt32(b);
            return bb;
        }
    }
}
