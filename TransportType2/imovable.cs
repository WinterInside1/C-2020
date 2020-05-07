namespace TransportType2 
{
    interface IMovable
    {
        public const int MinSpeed = 0;
        private static int _maxSpeed = 80;
		
        public int MaxSpeed
        {
            get => _maxSpeed;
            set => _maxSpeed = value;
        }
		
        public double GetTime(double distance, double speed) => distance / speed;
		
    }
}