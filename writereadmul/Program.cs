using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace writereadmul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AnotheFun();

        }

        private static async void AnotheFun()
        { string filePath = @"C:\Users\shahzaib.hassan\Desktop\File\One.txt";

            Task<string> task = MethodA("THREAD 1");
            //task.Start();
           
            ////    Task<int> task = ReadFile(filePath);
            ///
           


            Console.WriteLine(" Thread one is started");
           
            string length = await task;
            Console.WriteLine($"Thread is write text==={length.Length}");
        Task<int> tas = ReadFile(filePath);
            /// Reading size of file;


        //    tas.Start();
           
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine( i);
                int len = await tas;

            Console.WriteLine(" Total length: " + len);

            }
            Console.WriteLine(" done");
       


          
        }

        static async Task<int> ReadFile(string file)
        {
            int length = 0;

            Console.WriteLine(" File reading is stating");
            using (StreamReader reader = new StreamReader(file))
            {
                // Reads all characters from the current position to the end of the stream asynchronously    
                // and returns them as one string.
                //string str = "";
                //while ((str=reader.ReadLine())!=null)
                //{
                //    length = str.Length;
                //}
                
                string s = await reader.ReadToEndAsync();
                
                length = s.Length;
            }
            Console.WriteLine(" File reading is completed");
            return length;
          //  Thread.Sleep(3000);

            //task.join
            
        }
       

        static async Task<string> MethodA(string str)
        { System.Object lockThis = new System.Object(); string stri = "";
            lock (lockThis)
            {
                using (StreamWriter outStream = File.AppendText(@"C:\Users\shahzaib.hassan\Desktop\File\One.txt"))
                {
                    outStream.WriteLine("This was written by thread: " + str);
                    
                       
                    
                    Thread.Sleep(3000);
                     

                }
            }
            //string h = "hello";
            //stri = await lockThis;

            return stri;
        }
    }
}