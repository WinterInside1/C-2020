using System;

namespace TransportType2
{
     class Car : Transport, IComparable
    {
        public const int minSpeed = 0;
        private static int _maxSpeed = 80;
		
        public int MaxSpeed
        {
            get => _maxSpeed;
            set => _maxSpeed = value;
        }

        private static uint Price { get; set; }
        public uint NumberOfSeats { get; set; }
        public uint TrunkSize { get; set; }

        public enum CarType
        {
            Sedan,
            Universal,
            Hatchback,
            Pickup,
            Crossover,
            Suv
        }

        public readonly struct Engine
        {
            private readonly uint _volume;
            private readonly uint _power;
            private readonly uint _cylinders;
            private readonly string _ecoClass;
            public Engine(uint volume, uint cylinders, uint power, string ecoClass)
            {
                _volume = volume;
                _cylinders = cylinders;
                _power = power;
                _ecoClass = ecoClass;
            }

        public uint Volume => _volume;

        public uint Power => _power;

        public uint Cylinders => _cylinders;

        public string EcoClass => _ecoClass;
        }

        protected Car()
        {
            Price = 0;
            NumberOfSeats = 0;
            TrunkSize = 0;
        }
        public virtual void Beep() {Console.WriteLine("BEEP!\a");}
       
        public void Calculate()
        {
            Price = NumberOfSeats * 2000 + TrunkSize * 2;
            switch (ComfortLevel)
            {
                case "high":
                    Price *= 3;
                    break;
                case "medium":
                    Price *= 2;
                    break;
            }
        }
        public int CompareTo(object o)
        {
            if(o is Car c )
				return Price.CompareTo(Price);
            throw new Exception("Error. Unable to compare these objects.");
        }
        public delegate void PurchaseHandler(string message);
        public static event PurchaseHandler Notify;
        public static void Purchase(int money)
        {
            Notify?.Invoke(money > Price ? "Success" : "Something went wrong!");
        }
        
    }
}