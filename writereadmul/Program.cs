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

            //  string task = MethodA("THREAD 1");
            Task<string> task = MethodA("THREAD 2");
            //    Task<>
            //task.Start();

            ////    Task<int> task = ReadFile(filePath);
            ///



            Console.WriteLine(" Thread one is started");
            Task<string> le = task;
            //  string length =  task;
            //   Console.WriteLine($"Thread is write text==={length.Length}");
            Console.WriteLine($"Thread is write text==={le.IsCompletedSuccessfully} and ==={le.Result} and=={le.Status}");
            Task<int> tas = ReadFile(filePath);
            /// Reading size of file;


            //    tas.Start();
            int len = await tas;
            if (len != 0)
            {


                Console.WriteLine(" Total length: " + len);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                   

                }
            } Console.WriteLine(" done");
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
                   outStream.WriteLineAsync("This was written by thread: " + str);



                    //Thread.Sleep(3000);
                    Task.Delay(5000);
                     

                }
            }
            //string h = "hello";
            //stri = await lockThis;

            return stri;
        }
    }
}