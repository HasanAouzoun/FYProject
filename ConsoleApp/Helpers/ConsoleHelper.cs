using System;

namespace ConsoleApp.Helpers
{
    class ConsoleHelper
    {
        public static void RequestAnyInputToProceed()
        {
            Console.CursorVisible = true;
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
            Console.CursorVisible = false;
        }
    }
}
