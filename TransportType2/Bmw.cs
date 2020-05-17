using System;

namespace TransportType2
{
    class BMW : Car, IMovable
    {
        //fields
        public enum Model
        {
            Z8,
            I8,
            M5,
            M3,
            X5
        }

        private bool _available = true;

        //constructor
        public BMW(string name, string color, string comfortLevel, uint YearMade, uint numberOfSeats, 
            uint trunkSize, Model NeededModel, CarType NeededType)
        {
            Name = name;
            Color = color;
            ComfortLevel = comfortLevel;
            yearMade = YearMade;
            NumberOfSeats = numberOfSeats;
            TrunkSize = trunkSize;
            CurrentModel = NeededModel;
            CurrentType = NeededType;
        }


        public Model CurrentModel { get; }

        public CarType CurrentType { get; }

        public bool Available { get; set; }

        //methods
        public override void Beep()
        {
            Console.WriteLine("E-RON-DON-DON!!!\a\n");
        } 
        
        public static void ShowModels()
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