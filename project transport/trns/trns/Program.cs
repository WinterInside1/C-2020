using System;
namespace trns
{
    public class Transport
    {
        protected string name;
        public int price;
        protected string comfort;
        protected double speed;

        public int year { get; set; }
        protected string color = "нет";

        public int Number
        {
            get { return TransportNumber(); }
            set { ; }
        }

        protected string str0;
        protected bool res = true;

        public string TrColor
        {
            get { return color; }
            set { color = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Transport()
        {
            name = "Transport";
            price = 0;
            comfort = "high";
            speed = 0.0;
            year = 2000;
        }

        public Transport(string _name, int _price, string _comfort, double _speed, int _year)
        {
            name = _name;
            price = _price;
            comfort = _comfort;
            speed = _speed;
            year = _year;
        }

        public virtual void show()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Comfort: " + comfort);
            Console.WriteLine("Speed: " + speed);
            Console.WriteLine("Year: " + year);
            Console.WriteLine();
        }

        public virtual void enter()
        {
            Console.WriteLine("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Price: ");
            str0 = Console.ReadLine();
            res = true;
            while (res )
            {
                res = false;
                try
                {
                    price = Convert.ToInt32(str0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели неверное значение ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }

            price = Convert.ToInt32(str0);
            Console.WriteLine("Comfort: ");
            comfort = Console.ReadLine();
            Console.WriteLine("Speed: ");
            str0 = Console.ReadLine();
            res = true;
            while (res)
            {
                res = false;
                try
                {
                    speed = Convert.ToDouble(str0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели неверное значение ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }

            speed = Convert.ToDouble(str0);
            Console.WriteLine("Year: ");
            str0 = Console.ReadLine();
            res = true;
            while (res)
            {
                res = false;
                try
                {
                    year = Convert.ToInt32(str0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели неверное значение ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }
            year = Convert.ToInt32(str0);
            Console.WriteLine();
        }

        public void GetColor(string cl)
        {
            color = cl;
        }

        public static int TransportNumber()
        {
            int numb;
            Random rand = new Random();
            numb = rand.Next(1000, 10000);
            return numb;
        }

        public static void info()
        {
            Console.WriteLine("Имя: Транспорт\n Содержит базовые характеристики видов транспортных средств");
        }
    }


    namespace trns
    {
        class Program
        {
            static int cash;

            static void menu(Transport[] mas)
            {
                int i = 0, j = 0;
                Console.WriteLine("У вас есть $" + Convert.ToString(cash));
                Console.WriteLine("1 - Информация о классе");
                Console.WriteLine("2 - Ввод новых данных");
                Console.WriteLine("3 - Показать информацию об объектах");
                Console.WriteLine("4 - Выбрать цвет для ТС");
                Console.WriteLine("5 - Показать цвет ТС");
                Console.WriteLine("6 - Показать номер");
                Console.WriteLine("7 - Перейти к выбору автомобилей");
                Console.WriteLine("0 - Выход");

                mas[0] = new Transport();
                string str;
                bool yes = true;
                while (yes)
                {

                    str = Console.ReadLine();
                    char symb;
                    bool res = true;
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
                    symb = Convert.ToChar(str);
                    switch (symb)
                    {
                        case '1':
                            Transport.info();
                            break;
                        case '2':
                            if (i > 0)
                            {
                                Array.Resize(ref mas, i + 1);
                                mas[i] = new Transport();
                                mas[i].enter();
                                i++;
                            }
                            else
                            {
                                mas[i].enter();
                                i++;
                            }

                            break;
                        case '3':
                            for (j = 0; j < mas.Length; j++)
                            {
                                mas[j].show();
                            }

                            break;
                        case '4':
                            Console.WriteLine("Введите название ТС");
                            string ObjName = Console.ReadLine();
                            for (j = 0; j < mas.Length; j++)
                            {
                                if (mas[j].Name == ObjName)
                                {
                                    Console.WriteLine();
                                    var col = Console.ReadLine();
                                    mas[j].GetColor(col);
                                }
                                else if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                            }

                            break;
                        case '5':
                            Console.WriteLine("Введите название ТС");
                            string ObjName1 = Console.ReadLine();
                            for (j = 0; j < mas.Length; j++)
                            {
                                if (mas[j].Name == ObjName1)
                                {
                                    Console.WriteLine(mas[j].TrColor);
                                }
                                else if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                            }

                            break;
                        case '6':
                            Console.WriteLine("Введите название ТС");
                            string ObjName2 = Console.ReadLine();
                            for (j = 0; j < mas.Length; j++)
                            {
                                if (mas[j].Name == ObjName2)
                                {
                                    Console.WriteLine(mas[j].Number);
                                }
                                else if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                            }

                            break;

                        case '7':
                            bool res1 = true;
                            while (res1)
                            {
                                Console.WriteLine("1 - Mersedes");
                                Console.WriteLine("2 - BMW");
                                Console.WriteLine("3 - Cancel");
                                Console.WriteLine("0 - exit");
                                char s1;
                                string str3 = Console.ReadLine();
                                while (res1)
                                {
                                    res1 = false;
                                    try
                                    {
                                        s1 = Convert.ToChar(str3);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Введено неверное значение. Повторите попытку");
                                        str3 = Console.ReadLine();
                                        res1 = true;
                                    }
                                }

                                res1 = true;
                                s1 = Convert.ToChar(str3);
                                switch (s1)
                                {
                                    case '1':
                                        Mers[] arr1 = new Mers[1];
                                        Menu.MenuMers(arr1, cash);
                                        break;
                                    case '2':
                                        BMW[] arr2 = new BMW[1];
                                        Menu.BMWMenu(arr2, cash);
                                        break;
                                    case '3':
                                        res1 = false;
                                        break;
                                    case '0': return;
                                    default:
                                        Console.WriteLine("Неизвестный символ");
                                        break;
                                }
                            }
                            break;
                        case '0':
                            yes = false;
                            return;

                        default:
                            Console.WriteLine("Неизвестный символ");
                            break;
                    }
                    Console.WriteLine("1 - Информация о классе");
                    Console.WriteLine("2 - Ввод новых данных");
                    Console.WriteLine("3 - Показать информацию об объектах");
                    Console.WriteLine("4 - Выбрать цвет для ТС");
                    Console.WriteLine("5 - Показать цвет ТС");
                    Console.WriteLine("6 - Показать номер");
                    Console.WriteLine("7 - Перейти к выбору автомобилей");
                    Console.WriteLine("0 - Выход");
                }
            }

            static void Main(string[] args)
            {
                Transport[] arr = new Transport[1];
                cash = 10000;
                arr[0] = new Transport();
                menu(arr);
                Mers mers = new Mers();
                BMW bmw = new BMW();
                Console.WriteLine("\n" + Convert.ToString(mers.CompareTo(bmw)));

            }
        }
    }
}