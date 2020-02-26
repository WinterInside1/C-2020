using System;
namespace trns
{
    delegate void Shop(int x); 
    class MyEvent
    {
        public event Shop SomeEvent;
        public void OnSomeEvent(int x)
        {
            SomeEvent?.Invoke(x);
        }
    }

    class Demo
    {
        public  static void Handler()
        {   
            Console.WriteLine("Поздравляем с покупкой");
        }
    }
}