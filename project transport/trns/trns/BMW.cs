using System;
using Mersedes;
namespace Bmw
{
   
enum mod
{
    E34,
    E36,
    E39,
    E40,
    E46,
    X5,
    X6,
    X3
}
public class BMW : Mers
{
        public BMW()
        {
            name = "BMW";
            type_name = "Sedan";
            Model = Enum.GetName(typeof(mod), counter);
            price = 2000;
            comfort = "high";
            speed = 80;
            color = "white";
            fuel = "disel";
            year = 2019;
            counter++;
        }
        public BMW(int _price, string _comfort, double _speed, string _color, string _fuel, int _year) 
        {
            name = "BMW";
            type_name = var_types[0].type_name;
            Model = Enum.GetName(typeof(mod), counter);
            price = _price;
            comfort = _comfort;
            speed = _speed;
            color = _color;
            fuel = _fuel;
            year = _year;
            counter++;
        }

        public override void ShowModels()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(Convert.ToString(i) + " " + Enum.GetName(typeof(mod), i));
            }
        }

        public override void ChooseModel()
        {
            int i = Convert.ToInt32(Console.ReadLine());
            Model = Enum.GetName(typeof(mod), i);
        }
        
    }
}