using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace file
{
    class Program
    {
        private static string f = string.Empty;
        private static string h = string.Empty;
        private static string str = @"C:\Users\shahzaib.hassan\Desktop";

        static void Main(string[] args)



        {


            DirectoryInfo directoryInfo;



            //Console.WriteLine("1--------------create directory");
            //Console.WriteLine("2--------------create subdirectory");
            //string ame = Console.ReadLine();
            //int   me = Int16.Parse(ame);
            //switch (me)

            //{
            //    case 1:
            //        Createdir();
            //        break;
            //    case 2:
            //        CreateSubdir();
            //        break;
            //    default:
            //        break;
            //}



            
            f = @"C:\Users\shahzaib.hassan\Desktop\File\Myfile.txt";
            h = @"C:\Users\shahzaib.hassan\Desktop\File\file.txt";
            Console.WriteLine("1--------------writefrom the file");
            Thread Thread = new Thread(new ThreadStart(Function1));
    //   System.Threading.Timer timer=new Timer(Function1,10,1,3000)
            Thread.Start();

            using (FileStream file = new FileStream(h, FileMode.Create, FileAccess.Write))
            {

                Console.WriteLine("please enter your desire text");
                string userName = Console.ReadLine();
                //     Console.ReadLine();

                Byte[] nm = Encoding.ASCII.GetBytes(userName);

                file.Write(nm, 0, nm.Length);



                //file.WriteByte(65);

                Console.WriteLine("main file is written");
                Console.WriteLine("you are successfuly save the text");
                //ile.Close();
          //    Thread.Abort();
            }
            #region comment
            //Console.WriteLine("1--------------read from the file");
            //Thread hread = new Thread(new ThreadStart(Function));
            //Thread.Start();



            //    f = @"C:\Users\shahzaib.hassan\Desktop\File\Myfile.txt";
            //    if (File.Exists(f))
            //    {
            //        Console.WriteLine("file is exists in current location");


            //        using (FileStream file = new FileStream(f, FileMode.Open, FileAccess.Read))
            //        {
            //            String a = File.ReadAllText(f);
            //            Console.WriteLine($"{a} ");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("file is not found");
            //        Console.ReadLine();
            //    }


            //Console.ReadLine();

            //    Console.WriteLine("2--------------write from the file");
            //    Console.WriteLine("3--------------write from the file");
            //    string Name = Console.ReadLine();
            //    int rName = Int16.Parse(Name);

            //    switch (rName)
            //    {
            //        case 1:
            //            Function();
            //            break;
            //        case 2:

            //        case 3:
            //            //Thread hread = new Thread(Function2);
            //            //hread.Start();
            //            //break;

            //        default:
            //            Console.WriteLine("you enter the wrong key");
            //            break;
            //    }




            //}
            #endregion

        }

        private static void CreateSubdir()
        {
            DirectoryInfo info = new DirectoryInfo(str);
            //     string t = @"C:\Users\shahzaib.hassan\Desktop\File";
            info.CreateSubdirectory("sub directory");
            DirectoryInfo[] infos = info.GetDirectories();
            foreach (var m in infos)
            {
                Console.WriteLine(m);
            }
           
        }

        private static void Createdir()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(str);
            directoryInfo.Create();
            Console.WriteLine("1--------------obtained the all information about directory");
            Console.WriteLine("2--------------read directory");
            Console.WriteLine("3-------------writedirectory");
            Console.WriteLine("4--------------delete the  directory");
            string Name = Console.ReadLine();
            int rName = Int16.Parse(Name);

            switch (rName)
            {
                case 1:
                    Console.WriteLine($"Name::{directoryInfo.Name} and Fullname =={directoryInfo.FullName}\n"+
                        $"sub directory=={directoryInfo.GetDirectories()} and get all files=={directoryInfo.GetFiles()}" +
                        $" Root =={directoryInfo.Root} and attribute=={directoryInfo.Attributes}" +
$"parent=={directoryInfo.Parent} lastaccess time =={directoryInfo.LastAccessTime} and{directoryInfo.LastWriteTime}");
 break;
                case 2:



                    Function1();
                    break;
                case 3:



                    break;
                case 4:



                    directoryInfo.Delete(true);
                    break;

                default:
                    Console.WriteLine("you enter the wrong key");
                    break;
            }



        }

        /// <summary>
        /// write
        /// </summary>
        public  static void Function1()
        {
           
            using (FileStream file = new FileStream(f, FileMode.Create, FileAccess.Write))
            {

             // Console.WriteLine("please enter your desire text");
                string userName = Console.ReadLine();
                //     Console.ReadLine();
               
                Byte[] nm = Encoding.ASCII.GetBytes(userName);

                file.Write(nm, 0, nm.Length);



                //file.WriteByte(65);

                Console.WriteLine("inner file is created");
                Console.WriteLine("you are successfuly save the text");
           //   file.Close();

            }
     //     Console.ReadLine();
        }
        /// <summary>
        /// function2
        /// </summary>
        private static void Function2()
        {
            using (FileStream file = new FileStream(h, FileMode.Create, FileAccess.Write))
            {

                Console.WriteLine("please enter your desire text");
                string userName = Console.ReadLine();
                //     Console.ReadLine();
       //       Thread.Sleep(2000);
                Byte[] nm = Encoding.ASCII.GetBytes(userName);

                file.Write(nm, 0, nm.Length);



                //file.WriteByte(65);

                Console.WriteLine("file is created");
                Console.WriteLine("you are successfuly save the text");
        //      file.Close();

            }
           

        }
        /// <summary>
        /// reading 
        /// </summary>
        private static void Function()
        {
            h = @"C:\Users\shahzaib.hassan\Desktop\File\file.txt";
            if (File.Exists(f))
            {
                Console.WriteLine("file is exists in current location");


                using (FileStream file = new FileStream(h, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        if (sr.Peek() > 0)

                        {
                            Console.WriteLine("charchtrer is available i n file "); String a = File.ReadAllText(h);

                            Console.WriteLine($"{a} ");
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("file is not found");
                Console.ReadLine();
            }

            }


                 


            }
        }
    

