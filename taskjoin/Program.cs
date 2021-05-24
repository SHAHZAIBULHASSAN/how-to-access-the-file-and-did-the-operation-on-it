using System;
using System.Threading;

namespace taskjoin
{

    class Program
    {
        int total = 0;
        static void Run()
        {
            for (int i = 0; i < 2; i++) Console.Write("C#corner");
        }
        static void Main(string[] args)
        {
            Thread th = new Thread(Run);
             Console.WriteLine("please enter the number ");
            int obj = Convert.ToInt32(Console.ReadLine());
            number n = new number(obj);
            Thread thread = new Thread(new ThreadStart(n.function));
            //Console.WriteLine("please enter the number ");
            //object obj = Convert.ToInt32(Console.ReadLine());
            int ob = 12;

            ///parameterized thread start  delegate
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(n.functon1);
            Thread th3 = new Thread(parameterizedThreadStart);
            th3.Start(ob);

            ///thread start delegate
            
           
            #region join function
       Thread th1 = new Thread(new ThreadStart(n.function2));
          //  Thread th2 = new Thread(number(obj));
            th1.Start();th1.Join(1000);
            #endregion
           
            thread.Start();

            ///thread is alive or abort
            ///
            #region is alive or abort
 if (th1.IsAlive) 
            {
                Console.WriteLine("thread is not exit"); 
            }
            #endregion

            #region thread start delegate
Thread t1 = new Thread(new ThreadStart(n.fun));
            t1.Start();
           Thread t2 = new Thread(n.fun);
            t2.Start();

            Thread t3 = new Thread(n.fun);
            t3.Start();
           



            th.Start();
            th.Join();
            #endregion
            

            Console.WriteLine("Thread t has terminated !");
            Console.Read();
        }
    }
    class number
    {
        int b;

        public int total = 0;
        static object _lock=new object();

        public void fun()
        {
            for (int i = 0; i < 10; i++)
              {  bool t = false;
            //apply Monitor
                // or lock(this)
                try
                {
                    Monitor.Enter(_lock, ref t);
                    total++;
                    Console.WriteLine(total);if (t)
                    {
                    Monitor.Exit(_lock);
                    } 
                }
                catch (Exception ex)
                {

                    
                }
                //lock (_lock) {}
                    
            

            }
            Console.WriteLine(total);
        }

        public number(int a)
        {
             b = a;
        }
        public void function()
        {
            Console.WriteLine("this is function in class number");
        }
        public void function2()
        {
            Console.WriteLine(b);
            Thread.Sleep(3000);
        }
        public void functon1(object j)
        {
           int  nmber = 0;
           if( int.TryParse(j.ToString(), out nmber))
            {
                for (int i = 0; i < nmber; i++)
                {
                    Console.WriteLine("number"+i);
                }
            }
            
            
        }
    }
}