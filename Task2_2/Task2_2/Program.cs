using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<String> list = new List<string>();
            list = GetLine();
            Console.WriteLine("Count of Integer:");
            Console.WriteLine(FindInteger(list).Count);
            Console.WriteLine("Count of Double:");
            Console.WriteLine(FindDouble(list).Count);

            Console.WriteLine("All integer and avg:");
            Display(list, 1);
            Console.WriteLine("All double and avg:");
            Display(list, 2);
            Console.WriteLine("String:");
            Display(list, 3);
            Console.ReadLine();
        }

        public static List<String> GetLine()
        {
            String line = "";
            List<String> list = new List<string>();
            Console.WriteLine("Enter the string to exit enter 'end' ");
            while (!line.Equals("end"))
            {
                line = Console.ReadLine();
                if (!line.Equals("end"))
                {
                    list.Add(line);
                }

            }

            return list;

        }

        public static double AverageOfInt(List<String> list)
        {
            int sum = 0;
            List<int> listOfInt = new List<int>(FindInteger(list));
            foreach (var item in listOfInt)
            {
                sum += item;
            }

            int count = listOfInt.Count;

            return (double)sum / (double)count;
        }

        public static double AverageOfDouble(List<String> list)
        {
            double sum = 0;
            List<double> listOfDouble = new List<double>(FindDouble(list));

            foreach (var item in listOfDouble)
            {
                sum += item;
            }

            int count = listOfDouble.Count;

            return sum / count;

        }


        public static List<int> FindInteger(List<string> list)
        {
            List<int> listOfInteger = new List<int>();
            int num;
            foreach (var item in list)
            {
                if (Int32.TryParse(item, out num))
                {
                    listOfInteger.Add(num);
                }


            }
            return listOfInteger;
        }

        public static List<double> FindDouble(List<string> list)
        {
            List<double> listOfDouble = new List<double>();
            String sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            double num;
            String[] mark = { ".", "," };
          
            foreach (var item in list)
            {
                if (item.Contains(mark[0]) || item.Contains(mark[1]))
                {
                    if (mark[0].Equals(sep))
                    {

                        if (AddDouble(sep, mark[0], mark[1], item) != Double.PositiveInfinity)
                        {
                            listOfDouble.Add(AddDouble(sep, mark[0], mark[1], item));
                        }

                    }
                    else
                    {

                        if (AddDouble(sep, mark[1], mark[0], item) != Double.PositiveInfinity)
                        {
                            listOfDouble.Add(AddDouble(sep, mark[1], mark[0], item));
                        }
                    }

                }
            }         
               return listOfDouble;
        }


        public static double AddDouble (string sep, string mark1,string mark2, string item)
        {
            double num;
            if (item.Contains(mark1))
            {
                if (Double.TryParse(item, out num))
                {
                    return num;
                }

            }
            else
            {

                var tempitem = item.Replace(mark2, mark1);

                if (Double.TryParse(tempitem, out num))
                {
                    return num;
                }


            }
            return Double.PositiveInfinity;
        }


        public static IEnumerable<string> FindString(List<string> list)
        {
            List<string> listOfString = new List<string>();
            double num;
            foreach (var item in list)
            {
                if (!Double.TryParse(item, out num))
                {
                    listOfString.Add(item);
                }


            }
            var listOfString2 = listOfString.OrderBy(x => x.Length).ThenBy(x => x);
            return listOfString2;
        }

        private static void Display(List<string> list, int flag)
        {
          
            switch (flag)
            {
                case 1:
                    if (FindInteger(list).Count != 0)
                    {
                       
                        foreach (var item in FindInteger(list))
                        {
                            string formatString = String.Format("{0,50:G}", item);
                            Console.WriteLine(formatString);
                        }

                        string formatString2 = String.Format("{0,50:G}", AverageOfInt(list));
                        Console.WriteLine(formatString2);
                    }
                    break;
                case 2:
                    if (FindDouble(list).Count != 0)
                    {
                        
                        foreach (var item in FindDouble(list))
                        {
                            Console.WriteLine(item.ToString("0.00").PadLeft(90));
                        }

                        Console.WriteLine(AverageOfDouble(list).ToString("0.00").PadLeft(90));

                    }
                    break;
                case 3:
                    foreach (var item in FindString(list))
                    {

                        Console.WriteLine(item);
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

           

            }

        }
    }

