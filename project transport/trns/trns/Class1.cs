using System;
using @class;
using IClass;
namespace trns
{
    public struct TypesCars : IShow
    {
        public string type_name;
        int seats;
        string bag_size;
        public TypesCars(string name, int _seats, string bag)
        {
            type_name = name;
            seats = _seats;
            bag_size = bag;
        }
      public string Show()
        {
            return "\tType: " + type_name + "\n\tCount of seats: " + Convert.ToString(seats) + "\n\tSize of bagage: " + bag_size; 
        }
    }

    public abstract class Auto : Transport
    {
                       
        protected string fuel;
        
        public Auto()
        {
            Name = "car";
            price = 1000;
            comfort = "high";
            speed = 80;
            color = "white";
            fuel = "disel";
            year = 2019;
        }

        public Auto(string _name, int _speed, string _color, string _fuel, int _year, int _price) : base()
        {
            Name = _name;
            speed = _speed;
            color = _color;
            fuel = _fuel;
            year = _year;
            price = _price;
            comfort = "high";
        }

        public override abstract void show();
        /*{
            
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Speed: " + Convert.ToString(speed));
            Console.WriteLine("Color: " + color);
            Console.WriteLine("Fuel: " + Convert.ToString(fuel));
            Console.WriteLine("Year: " + Convert.ToString(year));
            Console.WriteLine("Comfort: " + comfort);
            Console.WriteLine();
            
        }*/

        public override abstract void enter();
        /*{
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Price: ");
            price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Speed: ");
            speed = Convert.ToDouble(Console.ReadLine());
            Console.Write("Color: ");
            TrColor = Console.ReadLine();
            Console.Write("Type of fuel: ");
            fuel = Console.ReadLine();
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------");
        }*/

        protected static TypesCars[] var_types = new TypesCars[8];
        static void Initializ()
        {
            var_types[0] = new TypesCars("Sedan", 5, "medium");
            var_types[1] = new TypesCars("HatchBack", 5, "medium");
            var_types[2] = new TypesCars("Universal", 5, "big");
            var_types[3] = new TypesCars("SUV", 5, "very big");
            var_types[4] = new TypesCars("Jeep", 5, "big");
            var_types[5] = new TypesCars("Minivan", 7, "big");
            var_types[6] = new TypesCars("Kupe", 2, "small");
            var_types[7] = new TypesCars("Cabriolete", 5, "small");
        }

        public static void ShowVariants()
        {
            Initializ();
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine(Convert.ToString(i+1) + " " + var_types[i].Show() + "\n---------------------");
            }
        }
    }
}