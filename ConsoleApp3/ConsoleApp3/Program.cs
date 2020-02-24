using System;
using System.Globalization;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //1-й формат
            string date;
            //kjhgf
            var dt = DateTime.Today;
            Console.WriteLine(dt.Date);
            date = Convert.ToString(dt.Date);
            int i = 0, j =0;
            char symb = '0';
            var t = DateTime.Now;
            Console.WriteLine(t.TimeOfDay+"\n");
           // t.ToString("HH:mm:ss tt zz", CultureInfo.GetCultureInfo("fr-FR"));
            string time = Convert.ToString(t);
            while (j < 10)
            {
                foreach (Char ch in date)
                {
                    if (ch == symb ) i++;
                }

                foreach (Char ch in time)
                {
                    if (ch == symb) i++;
                }
                Console.WriteLine(j + " : " + i);
                i = 0;
                symb++;
                j++;
            }
            Console.WriteLine("-----------");
            //2-й формат
            dt = DateTime.Now;            
            date = Convert.ToString(dt.Day) + "." + Convert.ToString(dt.Month) + "."+ Convert.ToString(dt.Year);
            Console.WriteLine(date);
            t = DateTime.Now;            
            time = Convert.ToString(t.Hour) + ":" + Convert.ToString(t.Minute) + ":" + Convert.ToString(t.Second);
            Console.WriteLine(time);
            
            symb = '0';
            j = 0; i = 0;
            while (j < 10)
            {
                foreach (Char ch in date)
                {
                    if (ch == symb) i++;
                }

                foreach (Char ch in time)
                {
                    if (ch == symb) i++;
                }
                Console.WriteLine(j + " : " + i);
                i = 0;
                symb++;
                j++;
            }
            Console.ReadKey();
        }
    }
}
    
