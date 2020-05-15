namespace TransportType2 
{
	interface IMovable
	{
		public double GetTime(double distance, double speed) => distance / speed;
		
	}
}