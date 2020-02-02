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

        public static bool InputConfirmation()
        {
            // Request Confirmation
            Console.Write($"Please confirm. (y/n) ");
            var confirmation = Console.ReadKey();
            Console.WriteLine();

            // Process confirmation
            switch (confirmation.KeyChar)
            {
                case 'y':
                    return true;
                case 'n':
                    return false;
                default:
                    // if wrong confirmation action selected
                    Console.WriteLine($"Please type 'y' for yes, or 'n' for no.");
                    return InputConfirmation();
            }
        }
    }
}
