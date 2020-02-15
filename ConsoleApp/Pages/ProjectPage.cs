using System;
using System.Threading;
using ConsoleApp.Helpers;

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
                NewProjectSetUp();
            }

            // Display curret list count
            Console.WriteLine($"Current List contains: {Program.GetPipeCount()} items");

            // Actions
            Console.WriteLine("Actions available:");
            Console.WriteLine("\t1) Filter");
            Console.WriteLine("\t2) Sort");
            Console.WriteLine("\t3) Get New List");
            Console.WriteLine("\t4) End");

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
                    GetNewListRequest();
                    break;
                case '4':
                    EndRequest();
                    break;
            }
        }

        private static void NewProjectSetUp()
        {
            Console.WriteLine("To start a new project you need a list of strings to perform the filters on it.");
            ConsoleHelper.RequestAnyInputToProceed();

            // Display Get List Page
            GetListPage.Display();

            // Side note
            Console.WriteLine("Note: As a new list, we advise to sort it first, to better analyse the output of this software.");
            ConsoleHelper.RequestAnyInputToProceed();

            Console.Clear();
        }

        private static void FilterRequest()
        {
            // Display Filter Page
            FilterPage.Display();

            // return to project page
            Display();
        }

        private static void SortRequest()
        {
            // Display sort page
            SortPage.Display();

            // return to project page
            Display();
        }

        private static void GetNewListRequest()
        {
            // Display Get List Page
            GetListPage.Display();
            
            // Side note
            Console.WriteLine("Note: As a new list, we advise to sort it first, to better analyse the output of this software.");
            ConsoleHelper.RequestAnyInputToProceed();

            // Return to Project Page
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
                case '4':
                    return request.KeyChar;
                default:
                    // if wrong action selected, ask again
                    Console.WriteLine($"You have selected a wrong action, please select a number between 1 to 4.");
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
                    // if wrong confirmation action selected, ask again
                    Console.WriteLine($"Please type 'y' for yes, or 'n' for no.");
                    return ConfirmRequest(requestNumber);
            }
        }
    }
}
