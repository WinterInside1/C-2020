using System;

namespace TransportType2 
{
    internal interface IModels
    {	
        public static void Buy(bool inStock)
        {
            if(inStock)
            {
                Console.WriteLine("You successfully bought this one!");
                inStock = false;
            }
			
            else
                Console.WriteLine("Sorry, this one is out of stock!");
        }
		
        public static void Restore(bool inStock)
        {
            if(!inStock)
                inStock = true;
        }
		
        public void ShowModels();
        bool Available { get; set; }
    }
}