using System;

namespace TransportType2 
{
    abstract class Models
    {
        public void Buy(bool inStock)
        {
            try
            {
                if (inStock)
                {
                    Console.WriteLine("You successfully bought this one!");
                    inStock = false;
                }

                else
                {
                    throw new Exception("The car is out of stock, you need to restore it first!");
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
		
        public void Restore(bool inStock)
        {
            if(!inStock)
                inStock = true;
        }
		
        public abstract void ShowModels();
        bool Available { get; set; }
    }
}