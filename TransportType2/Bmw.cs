using System;

namespace TransportType2
{
    class Bmw : Car, IMovable, IModels
    {
      
        public enum Model
        {
            Z8,
            I8,
            M5,
            M3,
            X5
        }

        private bool _available = true;
        public bool Available { get; set; }
        public Model CurrentModel { get; }
        public CarType CurrentType { get; }
        
        public Bmw(string name, string color, string comfortLevel, uint yearMade, uint numberOfSeats, uint trunkSize, Model neededModel, CarType neededType)
        {
            Name = name;
            Color = color;
            ComfortLevel = comfortLevel;
            this.yearMade = yearMade;
            NumberOfSeats = numberOfSeats;
            TrunkSize = trunkSize;
            CurrentModel = neededModel;
            CurrentType = neededType;
        }

       
        ~Bmw() { Console.WriteLine("Destroyed!"); }
        public override void Beep()
        {
            Console.WriteLine("BEEP<BEEP\a\n");
        } 
        
        public void ShowModels()
        {
            Console.WriteLine("The models of BMW are: ");
            for (var toShow = Model.Z8; toShow <= Model.X5; toShow++)
            {
                Console.WriteLine(toShow);
            }
            Console.WriteLine();
        }		
    }
}