using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Pages
{
    class ProjectPage
    {
        public static void Display()
        {
            // Page set up
            Console.Clear();

            // Get List Page (mandatory for a new project) -- i.e. empty list
            if (Program.GetPipeCount().Equals(0))
            {
                GetListPage.Display();
                Console.WriteLine("Note: As a new list, we advise to sort it first, to better analyse the output of this software.");
            }

            // Display curret list count
            Console.WriteLine($"Current List contains: {Program.GetPipeCount()} items");

            // Actions
            Console.WriteLine("Actions available:");
            Console.WriteLine("\t1) Filter");
            Console.WriteLine("\t2) Sort");
            Console.WriteLine("\t3) End");

            // Request and confirm Action
            var action = RequestConfirmAction();

            // Process Request
            switch (action)
            {
                case '1':
                    FilterRequest();
                    break;
                case '2':
                    SortRequest();
                    break;
                case '3':
                    EndRequest();
                    break;
            }
        }

        private static void FilterRequest()
        {
            // To Do
            Console.WriteLine($"you have selected: Filter (ToDo)");
            Thread.Sleep(500); // just a temporary feedback - will be removed when the functionality is implemented

            // return to project page
            Display();
        }

        private static void SortRequest()
        {
            // To Do
            Console.WriteLine($"you have selected: Sort (ToDo)");
            Thread.Sleep(500); // just a temporary feedback - will be removed when the functionality is implemented

            // return to project page
            Display();
        }

        private static void EndRequest()
        {
            Console.Clear();
            Console.WriteLine($"Ending Process . . .");
            Thread.Sleep(500);
            MainPage.Display();
        }

        private static char RequestConfirmAction()
        {
            // Request Action
            var action = RequestAction();

            // Confrim Action check
            if (ConfirmRequest(action) == false)
            {
                action = RequestConfirmAction();
            }

            return action;
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

        private static bool ConfirmRequest(char requestNumber)
        {
            // Request confirmation
            Console.CursorVisible = true;
            Console.Write($"Please confirm your request number {requestNumber}. (y/n) ");
            var confirmation = Console.ReadKey();
            Console.WriteLine();
            Console.CursorVisible = false;

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
                    return ConfirmRequest(requestNumber);
            }
        }
    }
}
