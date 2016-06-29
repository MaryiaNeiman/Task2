using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = FileRes.Path;
           
            try
            {
                Console.WriteLine("Text before changes:");
                Console.WriteLine(File.ReadAllText(path));
                Console.WriteLine("Text after changes:");
                Console.WriteLine(LineBreakAddDate(path));

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error path");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            Console.ReadLine();
        }

        public static String ToLower(string path)
        {
            String text = File.ReadAllText(path);
            text = text.ToLower();
            return text;
            
        }

        public static String LineBreakAddDate(string path)
        {
            String text = ToLower(path);
            Char [] mark = { '.', '!', '?' };
            String text2 = "";
            DateTime localDate;
            String time;
            String cultureNames = "MM / dd / yyyy hh:mm: ss.fff" ;
            while (text.IndexOfAny(mark) != -1)
            {
                
                int index = text.IndexOfAny(mark);
                localDate = DateTime.Now;
                time = localDate.ToString(cultureNames);

                text2 += time + " " + text.Substring(0, index + 1) + "\n";
                text = text.Substring(index + 1);
                
            }
            if (text.Length != 0)
            {
                localDate = DateTime.Now;
                time = localDate.ToString(cultureNames);
                text2 += time + " " + text + "\n";
            }
            return text2;

        }

      

    }
}
