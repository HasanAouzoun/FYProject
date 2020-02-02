using System;

namespace ConsoleApp.Pages
{
    class MainPage
    {
        public static void Display()
        {
            // Console UI
            Console.Clear();
            Console.WriteLine("Welcome!! -- ToDo: added brife description");

            // Actions
            Console.WriteLine("1) Start");
            Console.WriteLine("2) Help");
            Console.WriteLine("3) Exit");

            // Request Action
            var action = RequestAction();

            switch (action)
            {
                case '1':
                    StartRequest();
                    break;
                case '2':
                    HelpRequest();
                    break;
                case '3':
                    ExitRequest();
                    break;
            }
        }

        private static void StartRequest()
        {
            // To Do
            StartPage.Display();
        }

        private static void HelpRequest()
        {
            // To Do
            Console.WriteLine($"you have selected: Help (ToDo)");
            System.Environment.Exit(0);
        }

        private static void ExitRequest()
        {
            Console.Clear();
            Console.WriteLine($"Exiting...");
        }

        private static char RequestAction()
        {
            // Request Input
            Console.CursorVisible = true;
            Console.Write("What would you like to do? ");
            var request = Console.ReadKey();
            Console.WriteLine();
            Console.CursorVisible = false;

            // Process the Request
            switch (request.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                    return request.KeyChar;
                default:
                    // if wrong action selected
                    Console.WriteLine($"You have selected a wrong action, please select 1, 2 or 3.");
                    return RequestAction();
            }
        }
    }
}
