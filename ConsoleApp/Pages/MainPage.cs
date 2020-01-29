using System;

namespace ConsoleApp.Pages
{
    class MainPage
    {
        private static bool terminate;

        public static void Display()
        {
            // setup
            terminate = false;

            // Console UI
            Console.Clear();
            Console.WriteLine("Welcome!! -- ToDo: added brife description");

            // Actions
            Console.WriteLine("1) New Project");
            Console.WriteLine("2) Load Project");
            Console.WriteLine("3) Help");
            Console.WriteLine("4) Exit");

            // Request Input
            var request = InputRequset();

            while (terminate == false)
            {
                // Process the Request
                switch (request)
                {
                    case '1':
                        NewProjectRequest();
                        break;
                    case '2':
                        LoadProjectRequest();
                        break;
                    case '3':
                        HelpRequest();
                        break;
                    case '4':
                        ExitRequest();
                        break;
                    default:
                        // if wrong action selected
                        Console.WriteLine($"You have selected a wrong action, please select 1, 2, 3 or 4.");
                        request = InputRequset();
                        break;
                }
            }

            System.Environment.Exit(0);
        }

        private static void NewProjectRequest()
        {
            // To Do
            Console.WriteLine($"you have selected: New Project (ToDo)");
            System.Environment.Exit(0);
        }

        private static void LoadProjectRequest()
        {
            // To Do
            Console.WriteLine($"you have selected: Load Project (ToDo)");
            System.Environment.Exit(0);
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
            terminate = true;
        }

        private static char InputRequset()
        {
            Console.Write("What would you like to do? ");
            var request = Console.ReadKey();
            Console.WriteLine();

            return request.KeyChar;
        }
    }
}
