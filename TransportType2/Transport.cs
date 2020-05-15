using System;
using System.Collections;

namespace TransportType2
{
    abstract class Transport : IEnumerable
    {
        //fields
        private static int SeriesNumber { get; set; }
        private static int[] _registrationNumber; 
        public string Name { get; set; }
        public string Color { get; set; }
        public string ComfortLevel { get; set; }
        protected uint yearMade;
        
        public uint YearMade
        {
            get => yearMade;
            set
            {
                if (value > 2020 || value < 1960)
                    return;
                else
                    yearMade = value;
            }
        }
        public int this[int digit] => _registrationNumber[digit];
        protected Transport()
        {
            _registrationNumber = new int[4];
            var rnd = new Random();
            foreach (var digit in _registrationNumber)
            {
                _registrationNumber[digit] = rnd.Next(0, 9);
            }
            SeriesNumber = rnd.Next(1000, 10000);
        }
        
        public IEnumerator GetEnumerator()
        {
            return _registrationNumber.GetEnumerator();
        }
    }
}