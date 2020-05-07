using System;

namespace TransportType2
{
    internal static class Example
    {
        static void Main(string[] args)
        {
            var myCar = new Bmw("Auto", "Black", "high", 2019, 4, 80,  Bmw.Model.M3, Car.CarType.Sedan);
            var myEngine = new Car.Engine(2500, 6, 80, "EURO 0");
            myCar.Calculate();
            
            Console.WriteLine("The info about the vehicle:");
            Console.WriteLine($"1. Type: {myCar.Name}.\n2. Color: {myCar.Color}\n3. Year of production: {myCar.YearMade}");
            Console.WriteLine($"4. Model: {myCar.CurrentModel}\n5. Car Type: {myCar.CurrentType}\n6. Comfort level: {myCar.ComfortLevel}]n\n");

            Console.WriteLine("The vehicle's technical characteristics: ");
            Console.WriteLine($"1. Number of seats: {myCar.NumberOfSeats}\n2. Engine volume: {myEngine.Volume}\n3. Engine cylinders number: {myEngine.Cylinders}");
            Console.WriteLine($"4. Engine power: {myEngine.Power}\n5. Engine ecology class: {myEngine.EcoClass}\n");
            Console.WriteLine($"The price is {myCar.Price}\n\n");

            var friendsCar = new Mercedes("Auto", "Silver", "medium", 2012, 4, 400, Mercedes.Model.W140, Car.CarType.Sedan);
            var friendsEngine = new Car.Engine(1700, 4, 66, "EURO 5");
            friendsCar.Calculate();

            Console.WriteLine("The info about your friend's vehicle:");
            Console.WriteLine($"1. Type: {friendsCar.Name}.\n2. Color: {friendsCar.Color}\n3. Year of production: {friendsCar.YearMade}");
            Console.WriteLine($"4. Model: {friendsCar.CurrentModel}\n5. Car Type: {friendsCar.CurrentType}\n6. Comfort level: {friendsCar.ComfortLevel}\n\n");

            Console.WriteLine("The vehicle's technical characteristics: ");
            Console.WriteLine($"1. Number of seats: {friendsCar.NumberOfSeats}\n2. Engine volume: {friendsEngine.Volume}\n3. Engine cylinders number: {friendsEngine.Cylinders}");
            Console.WriteLine($"4. Engine power: {friendsEngine.Power}\n5. Engine ecology class: {friendsEngine.EcoClass}\n");
            Console.WriteLine($"The price is {friendsCar.Price}\n\n");
			
			
            Console.WriteLine("Additional functions: ");
            Console.WriteLine("The program will show all models available:");
            myCar.ShowModels();
            friendsCar.ShowModels();
            
            IModels testCar = new Bmw("Auto", "Green", "low", 2010, 4, 65,  Bmw.Model.X5, Car.CarType.SUV);
            IModels.Restore(testCar.Available);
            IModels.Buy(testCar.Available);
            Console.WriteLine(testCar.Available);
            
            IMovable anotherCar = new Mercedes("Auto", "Silver", "medium", 2012, 4, 400, Mercedes.Model.W140, Car.CarType.Sedan);
            anotherCar.MaxSpeed = int.Parse(Console.ReadLine()!);
            Console.WriteLine("The time it takes the vehicle to get to destination point is: {0}", anotherCar.GetTime(250, anotherCar.MaxSpeed));
        }
    }
}