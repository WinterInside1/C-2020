using System;
using Bmw;
using events;
using trns;

namespace Mersedes
{
    public enum Models
    {
        C190,
        W177,
        W415,
        C117,
        C118,
        C257,
        S205,
        S213,
        X156,
        W464
    }
    public class Mers : Auto, IComparable, IEquatable<Mers>
    {
        //private IComparable comp;
        protected static int counter;
        public string Model { get; set; }
        protected string type_name;
        
       //IEquatable
       public bool Equals(Mers obj)
        {
            return Model == obj.Model && type_name == obj.type_name;
        }


        //Icomparable
        public int CompareTo(object obj)
        {
            Mers m = obj as Mers;
            if (m != null)
                return price.CompareTo(m.price);
            throw new Exception("Невозможно сравнить эти объекты!");
        }

        public Mers()
        {
            name = "Mersedes";
            type_name = "Sedan";
            Model = Enum.GetName(typeof(Models), counter);
            price = 3000;
            comfort = "high";
            speed = 80;
            color = "white";
            fuel = "disel";
            year = 2019;
            counter++;
        }

        public Mers(int _price, string _comfort, double _speed, string _color, string _fuel, int _year)
        {
            name = "Mersedes";
            type_name = var_types[0].type_name;
            Model = Enum.GetName(typeof(Models), counter);
            price = _price;
            comfort = _comfort;
            speed = _speed;
            color = _color;
            fuel = _fuel;
            year = _year;
            counter++;
        }

        public override void show()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Type: " + type_name);
            Console.WriteLine("Model: " + Model);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Speed: " + Convert.ToString(speed));
            Console.WriteLine("Color: " + color);
            Console.WriteLine("Fuel: " + Convert.ToString(fuel));
            Console.WriteLine("Year: " + Convert.ToString(year));
            Console.WriteLine("Comfort: " + comfort);
            Console.WriteLine();
        }

        public override void enter()
        {
            //throw new NotImplementedException();

            Console.Write("Model: ");
            Model = Console.ReadLine();
            Console.Write("Price: ");
            str0 = Console.ReadLine();
            res = true;
            while (res)
            {
                
                res = false;
                try { price = Convert.ToInt32(str0); }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели неверное значение ");
                    Console.Write("Price: ");
                    str0 = Console.ReadLine();
                    res = true;
                }            
            }
            price = Convert.ToInt32(str0);
            Console.Write("Speed: ");
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
                    Console.Write("Speed: ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }
            speed = Convert.ToDouble(str0);
            Console.Write("Color: ");
            TrColor = Console.ReadLine();
            Console.Write("Type of fuel: ");
            fuel = Console.ReadLine();
            Console.Write("Year: ");
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
            Console.WriteLine("-------------------");
        }

        public void ChooseType()
        {
            Console.Write("Номер кузова: ");
            int n;
            str0 = Console.ReadLine();
            res = true;            
            while (res)
            {
                res = false;
                try { n = Convert.ToInt32(str0); }
                catch(FormatException)
                {
                    Console.WriteLine("Неверное значение. Повотрите попытку");
                    Console.Write("Номер кузова: ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }
            n = Convert.ToInt32(str0);

            res = true;
            while (res)
            {
                res = false;
                try { type_name = var_types[n].type_name; }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Такого кузова нет. Повотрите попытку");
                    Console.Write("Номер кузова: ");
                    str0 = Console.ReadLine();
                    
                    while (res)
                    {
                        res = false;
                        try { n = Convert.ToInt32(str0); }
                        catch (FormatException)
                        {
                            Console.WriteLine("Неверное значение. Повотрите попытку");
                            Console.Write("Номер кузова: ");
                            str0 = Console.ReadLine();
                            res = true;
                        }
                    }
                    n = Convert.ToInt32(str0);
                    res = true;
                }

            }
            type_name = var_types[n].type_name;
        }
        
        public virtual void ShowModels()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Convert.ToString(i) + " " + Enum.GetName(typeof(Models), i));
            }
        }

        public virtual void ChooseModel()
        {
            int i;
            Console.Write("Номер модели: ");
            str0 = Console.ReadLine();
            res = true;
            while (res)
            {
                res = false;
                try { i = Convert.ToInt32(str0); }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение. Повотрите попытку");
                    Console.Write("Номер кузова: ");
                    str0 = Console.ReadLine();
                    res = true;
                }
            }
            i = Convert.ToInt32(str0);
            while (i > 9)
            {
                Console.WriteLine("Нет данных об этой модели. Повторите попытку");
                Console.Write("Номер модели: ");
                str0 = Console.ReadLine();
                res = true;
                while (res)
                {
                    res = false;
                    try { i = Convert.ToInt32(str0); }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверное значение. Повотрите попытку");
                        Console.Write("Номер кузова: ");
                        str0 = Console.ReadLine();
                        res = true;
                    }
                }
                i = Convert.ToInt32(str0);
            }
            
            Model = Enum.GetName(typeof(Models), i);
        }
    }
    class Menu
    {
        
        public static void MenuMers(Mers[] mas, int cash)
        {
            bool res = true;
            char symb;
            mas[0] = new Mers();
            int i = 0, j = 0;
            while (res)
            {
                Console.WriteLine("1 - Внести информацию о новом автомобиле");
                Console.WriteLine("2 - Показать все автомобили Мерседес");
                Console.WriteLine("3 - Выбрать цвет для авто");
                Console.WriteLine("4 - Выбрать модель");
                Console.WriteLine("5 - Выбрать тип кузова");
                Console.WriteLine("6 - Показать номер");
                Console.WriteLine("7 - Купить");
                Console.WriteLine("0 - Выход");
                string str3 = Console.ReadLine();
                while(res)
                {
                    res = false;
                    try { symb = Convert.ToChar(str3); }
                    catch(FormatException)
                    {
                        Console.WriteLine("Введено неверное значение. Повторите попытку");
                        str3 = Console.ReadLine();
                        res = true;
                    }
                }
                res = true;
                symb = Convert.ToChar(str3);
                switch (symb)
                {
                    case '1':
                        if (i > 0)
                        {
                            Array.Resize(ref mas, i + 1);
                            mas[i] = new Mers();
                            mas[i].enter();
                            i++;
                        }
                        else
                        {
                            mas[i].enter();
                            i++;
                        }
                        break;
                    case '2':
                        Array.Sort(mas);
                        for (j = 0; j < mas.Length; j++)
                        {
                            mas[j].show();
                        }
                        break;
                    case '3':
                        Console.WriteLine("Введите модель ТС");
                        string ObjName = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == ObjName)
                            {
                                Console.WriteLine();
                                var col = Console.ReadLine();
                                mas[j].GetColor(col);
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '4':
                        mas[i].ShowModels();
                        Console.Write("Выберите модель, которую нужно сменить");
                        string str = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == str)
                            {
                                mas[j].ChooseModel();
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '5':
                        Auto.ShowVariants();
                        Console.Write("Выберите модель, которой нужно сменить кузов");
                        string obj = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == obj)
                            {
                                mas[j].ChooseType();
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '6':
                        Console.WriteLine("Введите модель ТС");
                        string Obj1 = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == Obj1)
                            {
                                Console.WriteLine(mas[j].Number);
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '7':
                        for(int n = 0; n < i; n++)
                        {
                            mas[n].show();
                        }
                        Console.WriteLine("Введите номер желаемого авто");
                        res = true;
                        string s;
                        s = Console.ReadLine();
                        int num;
                        while (res)
                        {
                            res = false;
                            try { num = Convert.ToInt32(s); }
                            catch (FormatException)
                            {
                                Console.WriteLine("Введено неверное значение. Повторите попытку");
                                s = Console.ReadLine();
                                res = true;
                            }
                        }
                        res = true;
                        num = Convert.ToInt32(s);
                        Shop del = x =>
                        {
                            if(x >= mas[num - 1].price)
                            {
                                x -= mas[num - 1].price;
                                Console.WriteLine("Поздравляем с покупкой!");
                                Console.WriteLine("Вы приобрели Mersades " + mas[num - 1].Model);
                                Console.WriteLine("Остаток на счёте: " + Convert.ToString(cash - mas[num - 1].price));
                                cash -= mas[num - 1].price;
                            }
                            else
                            {
                                Console.WriteLine("У Вас недостаточно средств");
                            }

                        };
                        MyEvent evt = new MyEvent();
                        evt.SomeEvent += del;
                        evt.OnSomeEvent(cash);
                        break;
                    case '0': return;
                    default: Console.WriteLine("Неизвестное значение"); break;
                }
            }
        }

        public static void BMWMenu(BMW[] mas, int cash)
        {

            bool res = true;
            char symb;
            mas[0] = new BMW();
            int i = 0, j = 0;
            while (res)
            {
                Console.WriteLine("1 - Внести информацию о новом автомобиле");
                Console.WriteLine("2 - Показать все автомобили BMW");
                Console.WriteLine("3 - Выбрать цвет для авто");
                Console.WriteLine("4 - Выбрать модель");
                Console.WriteLine("5 - Выбрать тип кузова");
                Console.WriteLine("6 - Показать номер");
                Console.WriteLine("7 - Купить");
                Console.WriteLine("0 - Выход");
                string str3 = Console.ReadLine();
                while (res)
                {
                    res = false;
                    try { symb = Convert.ToChar(str3); }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введено неверное значение. Повторите попытку");
                        str3 = Console.ReadLine();
                        res = true;
                    }
                }
                res = true;
                symb = Convert.ToChar(str3);
                switch (symb)
                {
                    case '1':
                        if (i > 0)
                        {
                            Array.Resize(ref mas, i + 1);
                            mas[i] = new BMW();
                            mas[i].enter();
                            i++;
                        }
                        else
                        {
                            mas[i].enter();
                            i++;
                        }
                        break;
                    case '2':
                        for (j = 0; j < mas.Length; j++)
                        {
                            mas[j].show();
                        }
                        break;
                    case '3':
                        Console.WriteLine("Введите модель ТС");
                        string ObjName = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == ObjName)
                            {
                                Console.WriteLine();
                                var col = Console.ReadLine();
                                mas[j].GetColor(col);
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '4':
                        mas[mas.Length - 1].ShowModels();
                        Console.Write("Выберите модель, которую нужно сменить");
                        string str = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == str)
                            {
                                mas[j].ChooseModel();
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '5':
                        Auto.ShowVariants();
                        Console.Write("Выберите модель, которой нужно сменить кузов");
                        string obj = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == obj)
                            {
                                mas[j].ChooseType();
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '6':
                        Console.WriteLine("Введите модель ТС");
                        string Obj2 = Console.ReadLine();
                        for (j = 0; j < mas.Length; j++)
                        {
                            if (mas[j].Model == Obj2)
                            {
                                Console.WriteLine(mas[j].Number);
                            }
                            else
                                if (j + 1 > i) Console.WriteLine("Такого ТС не существует");
                        }
                        break;
                    case '7':

                        for (int n = 0; n < i; n++)
                        {
                            mas[n].show();
                        }
                        Console.WriteLine("Введите номер желаемого авто");
                        res = true;
                        string s;
                        s = Console.ReadLine();
                        int num;
                        while (res)
                        {
                            res = false;
                            try { num = Convert.ToInt32(s); }
                            catch (FormatException)
                            {
                                Console.WriteLine("Введено неверное значение. Повторите попытку");
                                s = Console.ReadLine();
                                res = true;
                            }
                        }
                        res = true;
                        num = Convert.ToInt32(s);
                        Shop del = x =>
                        {
                            if (x >= mas[num - 1].price)
                            {
                                x -= mas[num - 1].price;
                                Console.WriteLine("Поздравляем с покупкой!");
                                Console.WriteLine("Вы приобрели BMW " + mas[num - 1].Model);
                                Console.WriteLine("Остаток на счёте: " + Convert.ToString(cash - mas[num - 1].price));
                                cash -= mas[num - 1].price;
                            }
                            else
                            {
                                Console.WriteLine("У Вас недостаточно средств");
                            }

                        };
                        MyEvent evt = new MyEvent();
                        evt.SomeEvent += del;
                        evt.OnSomeEvent(cash);
                        break;
                    case '0': return;
                    default: Console.WriteLine("Неизвестное значение"); break;
                }
            }
        }
    }
}