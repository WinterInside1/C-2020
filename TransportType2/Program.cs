using System;

namespace TransportType2
{
    static class Program
    {
        private delegate Car Choose(Car first, Car second);
        private delegate void MessageHandler(string message);
        static void Main(string[] args)
        {
            var myCar = new BMW("Auto", "Black", "high", 2019,
                4, 80, BMW.Model.M3, Car.CarType.Sedan);
            var myEngine = new Car.Engine(2500, 6, 80, "EURO 0");
            myCar.Calculate();

            var friendsCar = new Mercedes("Auto", "Silver", "medium",
                2012, 4, 400, Mercedes.Model.W140,
                Car.CarType.Sedan);
            var friendsEngine = new Car.Engine(1700, 4, 66, "EURO 5");
            friendsCar.Calculate();

            Choose choice = IsBetter;

            MessageHandler handler = Console.WriteLine;
            handler("Enter the sum you would like to add:");
            int money;
            try
            {
                int.TryParse(Console.ReadLine(), out money);
                if (money <= 0)
                    throw new Exception("You've entered invalid data!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            myCar.Purchase(money);
            friendsCar.Purchase(money);
            var result = choice(myCar, friendsCar);
            handler("Nice choice!");
        }

        private static Car IsBetter(Car first, Car second)
        {
            var firstPoints = 0;
            var secondPoints = 0;

            if (first.NumberOfSeats > second.NumberOfSeats)
                firstPoints++;
            else if (first.NumberOfSeats < second.NumberOfSeats)
                secondPoints++;
            else
            {
                firstPoints++;
                secondPoints++;
            }
            if (first.ComfortLevel == "high" && (second.ComfortLevel == "medium" 
                                                 || second.ComfortLevel == "low") ||
                first.ComfortLevel == "medium" && second.ComfortLevel == "low")
                firstPoints++;
            else if (first.ComfortLevel == second.ComfortLevel)
            {
                firstPoints++;
                secondPoints++;
            }
            else
                secondPoints++;
            
            if (first.YearMade > second.YearMade)
                firstPoints++;
            else if (first.YearMade == second.YearMade)
            {
                firstPoints++;
                secondPoints++;
            }
            else
                secondPoints++;
            
            if (firstPoints > secondPoints)
                return first;
            if (firstPoints == secondPoints)
            {
                Console.WriteLine("The cars are equal, which one would like to choose?");
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                    {
                        return first;
                    }

                    case 2:
                    {
                        return second;
                    }

                    default:
                    {
                        Console.WriteLine("Error!");
                        break;
                    }
                }
            }
            else
                return second;

            return null;
        }
    }
}