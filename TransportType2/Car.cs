using System;

namespace TransportType2
{
     class Car : Transport, IComparable
    {
        public const int minSpeed = 0;
        private static int _maxSpeed = 80;
		
        public int MaxSpeed
        {
            get { return _maxSpeed;}
            set { _maxSpeed = value; }
        }
        public uint Price = 0;
        public uint NumberOfSeats { get; set; }
        public uint TrunkSize { get; set; }

        public enum CarType
        {
            Sedan,
            Universal,
            Hatchback,
            Pickup,
            Crossover,
            SUV
        }

        public struct Engine
        {
            private uint _volume;
            private uint _power;
            private uint _cylinders;
            private string _ecoClass;
            public Engine(uint volume, uint cylinders, uint power, string ecoClass)
            {
                _volume = volume;
                _cylinders = cylinders;
                _power = power;
                _ecoClass = ecoClass;
            }

            public uint Volume
            {
                get => _volume;
            }

            public uint Power
            {
                get => _power;
            }

            public uint Cylinders
            {
                get => _cylinders;
            }

            public string EcoClass
            {
                get => _ecoClass;
            }
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
            if(o is Car c)
				return Price.CompareTo(c.Price);
            throw new Exception("Error. Unable to compare these objects.");
        }
    }
}