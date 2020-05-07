using System;

namespace TransportType2
{
    class Mercedes : Car, IMovable, IModels
    {
        
        public enum Model
        {
            W123,
            W201,
            W140,
            W210,
            Gelandewagen
        }

       
        public Mercedes(string name, string color, string comfortLevel, uint yearMade, uint numberOfSeats, uint trunkSize, Model neededModel, CarType neededType)
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

       
        public Model CurrentModel { get; }

        public CarType CurrentType { get; }

       
        public override void Beep()
        {
            Console.WriteLine("Get low, get low, get looow!");
        }
		
        public void ShowModels()
        {
            Console.WriteLine("The models of Mercedes are: ");
            for (var toShow = Model.W123; toShow <= Model.Gelandewagen; toShow++)
            {
                Console.WriteLine(toShow);
            }
            Console.WriteLine();
        }

        public bool Available { get; set; }
    }
}