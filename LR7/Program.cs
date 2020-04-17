using System;
using System.Collections;

 


namespace lab_7
{

    class Operations : IComparable, IComparer
    {
        private int numerator;
        private int denominator;
       

        public Operations(int num, int denum)
        {
            numerator = num;
            denominator = denum;
           
        }

        public Operations(int num)
        {
            numerator = num;
            denominator = 1;
        }
        
        public static Operations operator +(Operations obj1, Operations obj2)
        {

            Operations res = new Operations(1,1);
            if (obj1.denominator == obj2.denominator)
            {
                res.numerator = obj1.numerator + obj2.numerator;
                res.denominator = obj1.denominator;
                return res;
            }
            else
            {
                res.numerator = obj1.numerator * obj2.denominator;
                res.numerator += obj2.numerator * obj1.denominator;
                
                res.denominator = obj1.denominator * obj2.denominator;
                return res;
            }             
        }

        public static Operations operator -(Operations obj1, Operations obj2)
        {
            Operations res = new Operations(1, 1);
            if (obj1.denominator == obj2.denominator)
            {
                res.numerator = obj1.numerator - obj2.numerator;
                res.denominator = obj1.denominator;
                return res;
            }
            else
            {
                res.numerator = obj1.numerator * obj2.denominator;
                res.numerator -= obj2.numerator * obj1.denominator;

                res.denominator = obj1.denominator * obj2.denominator;
                return res;
            }
        }

        public static Operations operator *(Operations obj1, Operations obj2)
        {
            Operations res = new Operations(1, 1);
            res.numerator = obj1.numerator * obj2.numerator;
            res.denominator = obj1.denominator * obj2.denominator;
            return res;
        }

        public static Operations operator /(Operations obj1, Operations obj2)
        {
            Operations res = new Operations(1, 1);
            res.numerator = obj1.numerator * obj2.denominator;
            int temp;
            temp = obj2.numerator * obj1.denominator;
            if (temp > 0)
               res.denominator = temp;
            else
            {
                res.denominator = Math.Abs(temp);
                res.numerator = 0 - res.numerator;
            }
            return res;
        }

        public static bool operator ==(Operations obj1, Operations obj2)
        {
            if(obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator == obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator == obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }
        public static bool operator !=(Operations obj1, Operations obj2)
        {
            if (obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator != obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator != obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator >=(Operations obj1, Operations obj2)
        {
            if (obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator >= obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator >= obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }
        public static bool operator <=(Operations obj1, Operations obj2)
        {
            if (obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator <= obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator <= obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator >(Operations obj1, Operations obj2)
        {
            if (obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator > obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator > obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }

        public static bool operator <(Operations obj1, Operations obj2)
        {
            if (obj1.denominator == obj2.denominator)
            {
                if (obj1.numerator < obj2.numerator)
                    return true;
                else
                    return false;
            }
            else
            {
                if (obj1.numerator * obj2.denominator < obj2.numerator * obj1.denominator)
                    return true;
                else
                    return false;
            }
        }

        public void enter()
        {
            string str;
            str = Console.ReadLine();
            string[] strs = new string[2];
            strs = str.Split('/');
            int a, b;
            try
            { a = Convert.ToInt32(strs[0]); }
            catch(System.FormatException)
            {
                Console.WriteLine("Неверное выражение");
                return;
            }
            a = Convert.ToInt32(strs[0]);
            numerator = a;
            try
            { b = Convert.ToInt32(strs[1]); }
            catch (System.FormatException)
            {
                Console.WriteLine("Неверное выражение");
                return;
            }
            b = Convert.ToInt32(strs[1]);
            denominator = b;
        }
        private int NOD(int a, int b)
        {
            
            
            while(a!=b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;                
            }
            return a;
        }

        private void Reduce()
        {
            int N = NOD(Math.Abs(numerator), denominator);
            while (N != 1)
            {
                N = NOD(Math.Abs(numerator), denominator);
                numerator /= N;
                denominator /= N;
            }
        }
        public string Fraction()
        {

            if (numerator % denominator == 0)
            {
                return Convert.ToString(numerator / denominator);
            }
            else
            {
                Reduce();
                return (Convert.ToString(numerator) + "/" + Convert.ToString(denominator));
            }
        }
        
        public int CompareTo(object obj)
        {
            Operations temp = (Operations)obj;
            if (this > temp) return 1;
            if (this < temp) return -1;
            return 0;
        }

        public int Compare(object obj1, object obj2)
        {
            if ((Operations)obj1 == (Operations)obj2)
                return 1;
            else
                return 0;
        }

        public static explicit operator int(Operations obj)
        {
            return obj.numerator / obj.denominator;
        }

        public static explicit operator double(Operations obj)
        {
            return obj.numerator / obj.denominator;
        }

        public void enter(string str)
        {
            bool yes = false;
            foreach (char ch in str)
                if (ch == '/') yes = true;
            if (yes == true)
            {
                string[] strs = new string[2];
                strs = str.Split('/');
                int a, b;
                try
                { a = Convert.ToInt32(strs[0]); }
                catch (System.FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return;
                }
                a = Convert.ToInt32(strs[0]);
                numerator = a;
                try
                { b = Convert.ToInt32(strs[1]); }
                catch (System.FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return;
                }
                b = Convert.ToInt32(strs[1]);
                denominator = b;
            }
            else
            {
                int c;
                try { c = Convert.ToInt32(str); }
                catch(System.FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return;
                }
                c = Convert.ToInt32(str);
                numerator = c;
                denominator = 1;
            }           

        }
        public void enter(char[] s)
        {
            bool Yes = false;
            foreach (char ch in s)            
                if (ch == '/')
                {
                    Yes = true;
                    break;
                }
            
            if(Yes == true)
            {
                char[] str1 = new char[20];
                char[] str2 = new char[20];
                int i = 0;
                while(s[i] != '/')
                {
                    str1[i] = s[i];
                    i++;
                }
                int j = 0;i++;
                for (; i < s.Length; j++, i++)
                {
                    str2[j] = s[i];
                }

                int temp = 0;
                for(int k = 0; str1[k] != '\0'; k++)
                {
                    temp += (str1[k] - 48)*(int) Math.Pow(10, k);
                }
                numerator = temp;
                temp = 0;
                for (int k = 0; str1[k] != '\0'; k++)
                {
                    temp += (str2[k] - 48)*(int)Math.Pow(10, k);
                }
                denominator = temp;
            }
            else
            {
                int c;
                try { c = Convert.ToInt32(s); }
                catch (System.FormatException)
                {
                    Console.WriteLine("Неверное выражение");
                    return;
                }
                c = Convert.ToInt32(s);
                numerator = c;
                denominator = 1;
            }

        }
    }

    class Program
    {
        static bool Exist(string str, char s)
        {
            foreach (char ch in str)
                if (ch == s)
                    return true;                
            return false;
        }
        static void menu()
        {

            Operations[] mas = new Operations[1];
            int i = 0;
            bool result = true;
            char symb;
            while (result == true)
            {
                string str;
                bool res = true;
                Console.WriteLine("1 - Ввести дробь");
                Console.WriteLine("2 - Провести операции");
                Console.WriteLine("3 - Сравнить 2 дроби");
                Console.WriteLine("4 - Верно ли что?");
                Console.WriteLine("0 - Выход");
                
                str = Console.ReadLine();
                while (res == true)
                {
                    res = false;

                    try
                    {
                        symb = Convert.ToChar(str);
                    }
                    catch (System.FormatException)
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
                        mas[i].enter();
                        i++;
                        Array.Resize<Operations>(ref mas, i+1);
                        break;
                    case '2':
                        Console.Write("Введите строку с операцией между дробями");
                        string drob = Console.ReadLine();
                        string[] arr = new string[2];
                        if (Exist(drob, '+') == true)
                        {
                            arr = drob.Split('+');
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[0]);
                            i++;
                            Array.Resize<Operations>(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[1]);
                            Operations resulting = mas[i-1] + mas[i];
                            i++;

                            Console.WriteLine(arr[0] + " + " + arr[1] + " = " + resulting.Fraction());
                        }
                        else
                        if (Exist(drob, '-') == true)
                        {
                            arr = drob.Split('-');
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[0]);
                            i++;
                            Array.Resize<Operations>(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[1]);
                            Operations resulting = mas[i-1] - mas[i];
                            i++;

                            Console.WriteLine(arr[0] + " - " + arr[1] + " = " + resulting.Fraction());
                        }
                        else
                        if (Exist(drob, '*') == true)
                        {
                            arr = drob.Split('*');
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[0]);
                            i++;
                            Array.Resize<Operations>(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(arr[1]);
                            Operations resulting = mas[i-1] * mas[i];
                            i++;

                            Console.WriteLine(arr[0] + " * " + arr[1] + " = " + resulting.Fraction());
                        }
                        else
                        {
                            char[] str1 = new char[20];
                            char[] str2 = new char[20];
                            int count = 0;
                            foreach (char ch in drob)
                                if (ch == '/') count++;
                            if (count > 2)
                            {
                                int j = 0;
                                int k = 0;
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
                                int m = 0;
                                while (j<drob.Length)
                                {
                                    str2[m] = drob[j];
                                    j++;
                                    m++;
                                }
                            }
                            
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(str1);
                            i++;
                            Array.Resize<Operations>(ref mas, i + 2);
                            mas[i] = new Operations(1, 1);
                            mas[i].enter(str2);
                            Operations resulting = mas[i - 1] / mas[i];
                            i++;

                            Console.WriteLine( " = " + resulting.Fraction());
                        }                                               

                        break;
                    case '3':
                        Console.WriteLine("Введите дроби для сравнения ");
                        string st1, st2;
                        st1 = Console.ReadLine();
                        st2 = Console.ReadLine();
                        mas[i] = new Operations(1, 1);
                        mas[i].enter(st1);
                        i++;
                        Array.Resize<Operations>(ref mas, i + 2);
                        mas[i] = new Operations(1, 1);
                        mas[i].enter(st2);
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
                        
                        foreach (char ch in s1)
                        {
                            if(ch == '>')
                            {
                                arr = s1.Split('>');
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[0]);
                                i++;
                                Array.Resize<Operations>(ref mas, i + 2);
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[1]);
                                i++;
                                if (mas[i - 2] > mas[i - 1])
                                    Console.WriteLine("Да");
                                else
                                    Console.WriteLine("Нет");
                            }

                            if (ch == '<')
                            {
                                arr = s1.Split('<');
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[0]);
                                i++;
                                Array.Resize<Operations>(ref mas, i + 2);
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[1]);
                                i++;
                                if (mas[i - 2] < mas[i - 1])
                                    Console.WriteLine("Да");
                                else
                                    Console.WriteLine("Нет");
                            }

                            if (ch == '=')
                            {
                                arr = s1.Split('=');
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[0]);
                                i++;
                                Array.Resize<Operations>(ref mas, i + 2);
                                mas[i] = new Operations(1, 1);
                                mas[i].enter(arr[1]);
                                i++;
                                if (mas[i - 2] == mas[i - 1])
                                    Console.WriteLine("Да");
                                else
                                    Console.WriteLine("Нет");
                            }
                        }
                        break;
                    case '0': return;
                    default: Console.WriteLine("Вы ввели неверное значение. Повторите попытку"); break;
                }


            }
        }



        static void Main(string[] args)
        {
            Operations op1 = new Operations(1,2);
            Operations op2 = new Operations(2, 4);
            Operations res = op1 + op2;
            
            menu();
        }
    }
}
