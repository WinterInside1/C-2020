using System;

namespace TransportType2
{
    class Car : Transport, IComparable
    {
     
        public uint Price { get; set; }
        public uint NumberOfSeats { get; set; }
        public uint TrunkSize { get; set; }

        public enum CarType
        {
            Sedan,
            Universal,
            Crossover,
            SUV
        }

        public readonly struct Engine
        {
            public Engine(uint volume, uint cylinders, uint power, string ecoClass)
            {
                Volume = volume;
                Cylinders = cylinders;
                Power = power;
                EcoClass = ecoClass;
            }

            public uint Volume { get; }

            public uint Power { get; }

            public uint Cylinders { get; }

            public string EcoClass { get; }
        }
        
        protected Car()
        {
            Price = 0;
            NumberOfSeats = 0;
            TrunkSize = 0;
        }
        
         ~Car(){Console.WriteLine("Destroyed!");}
        
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