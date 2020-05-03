using System;
using System.Collections;
using System.Linq;

namespace LR7
{
    internal static class Program
    {
        private static bool Exist(string str, char s)
        {
            return str.Any(ch => ch == s);
        }

        private static void Menu()
        {

            var mas = new Operations[1];
            var i = 0;
            const bool result = true;
            while (result)
            {
                bool res = true;
                Console.WriteLine("1 - Ввести дробь");
                Console.WriteLine("2 - Провести операции");
                Console.WriteLine("3 - Сравнить 2 дроби");
                Console.WriteLine("4 - Верно ли что?");
                Console.WriteLine("0 - Выход");
                
                var str = Console.ReadLine();
                char symb;
                while (res)
                {
                    res = false;

                    try
                    {
                        symb = Convert.ToChar(str);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неизвестный символ.Повторите попытку");
                        str = Console.ReadLine();
                        res = true;
                    }
                }
                symb = str[0];
               
                switch(symb)
                {
                    case '1':
                        mas[i] = new Operations(1);
                        Console.WriteLine("Введите дробь:");
                        Operations buff;
                        Enter();
                        i++;
                        Array.Resize(ref mas, i+1);
                        break;
                    case '2':
                        Console.Write("Введите строку с операцией между дробями");
                        var drob = Console.ReadLine();
                        string[] arr;
                        if (Exist(drob, '+'))
                        {
                            arr = drob.Split('+');
                            //mas[i] = new Operations(1, 1);
                            //var array = new Operations[i];
                            buff = Enter(arr[0]);
                            mas[i] = buff;
                            i++;
                            Array.Resize(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            buff = Enter(arr[1]);
                            mas[i] = buff;
                            var resulting = mas[i-1] + mas[i];
                            i++;

                            Console.WriteLine(arr[0] + " + " + arr[1] + " = " + resulting.ToString());
                        }
                        else
                        if (Exist(drob, '-'))
                        {
                            arr = drob.Split('-');
                            //var array = new Operations[i];
                            mas[i] = new Operations(1, 1);
                            buff = Enter(arr[0]);
                            mas[i] = buff;
                            i++;
                            Array.Resize(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            buff = Enter(arr[1]);
                            mas[i] = buff;
                            Operations resulting = mas[i-1] - mas[i];
                            i++;
                            Console.WriteLine(arr[0] + " - " + arr[1] + " = " + resulting.ToString());
                        }
                        else
                        if (Exist(drob, '*'))
                        {
                            arr = drob.Split('*');
                            //var array = new Operations[i];
                            mas[i] = new Operations(1, 1);
                            buff = Enter(arr[0]);
                            mas[i] = buff;
                            i++;
                            Array.Resize(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            buff = Enter(arr[1]);
                            mas[i] = buff;
                            Operations resulting = mas[i-1] * mas[i];
                            i++;

                            Console.WriteLine(arr[0] + " * " + arr[1] + " = " + resulting.ToString());
                        }
                        else
                        {
                            var str1 = new char[20];
                            var str2 = new char[20];
                            var count = drob.Count(ch => ch == '/');
                            if (count > 2)
                            {
                                int j = 0, k = 0;
                                
                                while (k < 2)
                                {
                                    if (drob[j] == '/')
                                    {
                                        k++;
                                        if(k != 2) str1[j] = drob[j];
                                    }
                                    else str1[j] = drob[j];
                                    j++;
                                }
                                var m = 0;
                                while (j<drob.Length)
                                {
                                    str2[m] = drob[j];
                                    j++;
                                    m++;
                                }
                            }
                            
                            mas[i] = new Operations(1, 1);
                            buff = Enter(str1);
                            mas[i] = buff;
                            i++;
                            Array.Resize(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            buff = Enter(str2);
                            mas[i] = buff;
                            Operations resulting = mas[i - 1] / mas[i];
                            i++;

                            Console.WriteLine( " = " + resulting.ToString());
                        }                                               

                        break;
                    case '3':
                        Console.WriteLine("Введите дроби для сравнения ");
                        string st1, st2;
                        st1 = Console.ReadLine();
                        st2 = Console.ReadLine();
                        mas[i] = new Operations(1, 1);
                        buff = Enter(st1);
                        mas[i] = buff;
                        i++;
                        Array.Resize(ref mas, i + 2);
                        mas[i] = new Operations(1, 1);
                        buff = Enter(st2);
                        mas[i] = buff;
                        i++;

                        if (mas[i - 2] > mas[i - 1])
                            Console.WriteLine(st1 + " > " + st2);
                        
                        if (mas[i - 2] < mas[i - 1])
                            Console.WriteLine(st1 + " < " + st2);
                        
                        if (mas[i - 2] == mas[i - 1])
                            Console.WriteLine(st1 + " = " + st2);

                        break;
                    case '4':
                        Console.WriteLine("Верно ли что... ");
                        string s1;
                        s1 = Console.ReadLine();
                        
                        foreach (var ch in s1)
                        {
                            switch (ch)
                            {
                                case '>':
                                {
                                    arr = s1.Split('>');
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[0]);
                                    mas[i] = buff;
                                    i++;
                                    Array.Resize(ref mas, i + 2);
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[1]);
                                    mas[i] = buff;
                                    i++;
                                    Console.WriteLine(mas[i - 2] > mas[i - 1] ? "Да" : "Нет");
                                    break;
                                }
                                case '<':
                                {
                                    arr = s1.Split('<');
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[0]);
                                    mas[i] = buff;
                                    i++;
                                    Array.Resize(ref mas, i + 2);
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[1]);
                                    mas[i] = buff;
                                    i++;
                                    Console.WriteLine(mas[i - 2] < mas[i - 1] ? "Да" : "Нет");
                                    break;
                                }
                                case '=':
                                {
                                    arr = s1.Split('=');
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[0]);
                                    mas[i] = buff;
                                    i++;
                                    Array.Resize(ref mas, i + 2);
                                    mas[i] = new Operations(1, 1);
                                    buff = Enter(arr[1]);
                                    mas[i] = buff;
                                    i++;
                                    Console.WriteLine(mas[i - 2] == mas[i - 1] ? "Да" : "Нет");
                                    break;
                                }
                            }
                        }
                        break;
                    case '0': return;
                    default: Console.WriteLine("Вы ввели неверное значение. Повторите попытку"); break;
                }
            }
        }

        private static Operations Enter()
        {
            //var buff = new Operations(); 
            var str = Console.ReadLine();
            var strs = str?.Split("/");
            int a, b;
            try
            {
                a = Convert.ToInt32(strs?[0]);
                b = Convert.ToInt32(strs?[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное выражение");
                return null;
            }
            
            // try
            // {
            //     b = Convert.ToInt32(strs?[1]);
            // }
            // catch (FormatException)
            // {
            //     Console.WriteLine("Неверное выражение");
            //     return null;
            // }
            // b = Convert.ToInt32(strs[1]);
            Operations buff;
            if ( b != 0)
                buff = new Operations(a,b);
            else throw new Exception("U cant enter 0");
            return buff;
        }

         private static Operations Enter(string str)
         {
             Operations buff;
            var yes = false;
            foreach (var ch in str.Where(ch => ch == '/'))
                yes = true;
            if (yes)
            {
                var strs = str.Split('/');
                int a, b;
                try
                {
                    a = Convert.ToInt32(strs[0]);
                    b = Convert.ToInt32(strs[1]);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return null;
                }
                if ( b != 0)
                 buff = new Operations(a,b);
                else throw new Exception("U cant enter 0");

               // a = Convert.ToInt32(strs[0]);
                // buff.SetNumerator(a);
                // try
                // {
                //     
                //     b = Convert.ToInt32(strs[1]);
                //     
                // }
                // catch (FormatException)
                // {
                //     Console.WriteLine("Неверное выражение");
                //     return null;
                // }
                //
                // //b = Convert.ToInt32(strs[1]);
                // buff.SetDenominator(b);
                return buff;
            }
            else
            {
                int c;
                try
                {
                    c = Convert.ToInt32(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return null;
                }
                buff = new Operations(c,1);
                return buff;

                //  c = Convert.ToInt32(str);
                // buff.SetNumerator(c);
                // buff.SetDenominator(1);
            }

            // return buff;
        }

         private static Operations Enter(char[] s)
        {
            // var buff = new Operations();
            Operations buff;
            var yes = s.Any(ch => ch == '/');

            if (yes)
            {
                var str1 = new char[20];
                var str2 = new char[20];
                int i = 0;
                while (s[i] != '/')
                {
                    str1[i] = s[i];
                    i++;
                }

                int j = 0;
                i++;
                for (; i < s.Length; j++, i++)
                {
                    str2[j] = s[i];
                }

                int temp = 0;
                for (int k = 0; str1[k] != '\0'; k++)
                {
                    temp += (str1[k] - 48) * (int) Math.Pow(10, k);
                }
                
                // buff.SetNumerator(temp);
                int temp1 = 0;
                for (int k = 0; str1[k] != '\0'; k++)
                {
                    temp1 += (str2[k] - 48) * (int) Math.Pow(10, k);
                }
                // buff.SetDenominator(temp);
                if ( temp1 != 0)
                    buff = new Operations(temp,temp1);
                else throw new Exception("U cant enter 0");
                
            }
            else
            {
                int c;
                try
                {
                    c = Convert.ToInt32(s);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return null;
                }

                // c = Convert.ToInt32(s);
                // buff.SetNumerator(c);
                // buff.SetDenominator(1);
                buff = new Operations(c,1);
            }

            return buff;
        }
        static void Main(string[] args)
        {
            Operations op1 = new Operations(1,2);
            Operations op2 = new Operations(2, 4);
            Operations res = op1 + op2;
            Menu();
        }
    }
}
