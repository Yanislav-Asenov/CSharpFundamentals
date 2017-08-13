namespace EventImplementation
{
    using EventImplementation.Models;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            handler.SubscribeToDispatcher(dispatcher);

            string input = Console.ReadLine();
            while (input != "END")
            {
                dispatcher.Name = input;

                input = Console.ReadLine();
            }
        }
    }
}
