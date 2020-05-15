using System;

namespace TransportType2
{
    class Mercedes : Car, IMovable
    {
        

        public enum Model
        {
            W123,
            W201,
            W140,
            W210,
            Gelandewagen
        }
        
        public Mercedes(string name, string color, string comfortLevel, uint YearMade, uint numberOfSeats,
            uint trunkSize, Model neededModel, CarType neededType)
        {
            Name = name;
            Color = color;
            ComfortLevel = ComfortLevel;
            yearMade = YearMade;
            NumberOfSeats = numberOfSeats;
            TrunkSize = trunkSize;
            CurrentModel = neededModel;
            CurrentType = neededType;
        }
        
        private Model CurrentModel { get; }

        private CarType CurrentType { get; }
        
        public override void Beep()
        {
            Console.WriteLine("Get low, get low, get looow!");
        }

        public static void ShowModels()
        {
            Console.WriteLine("The models of Mercedes are: ");
            for (Model toShow = Model.W123; toShow <= Model.Gelandewagen; toShow++)
            {
                Console.WriteLine(toShow);
            }

            Console.WriteLine();
        }
        public bool Available { get; set; }

        public delegate void PurchaseHandler(string message);

        public event PurchaseHandler Notify;

        public void Purchase(int money)
        {
            if (money < Price)
                Notify?.Invoke("Something went wrong!");
            else
                Console.WriteLine("Successful!");
        }
    }
}