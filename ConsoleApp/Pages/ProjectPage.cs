using System;
using System.Threading;
using ConsoleApp.Helpers;

namespace ConsoleApp.Pages
{
    class ProjectPage
    {
        public static bool IsNewProject = true;

        public static void Display()
        {
            // Page set up
            Console.Clear();

            // Get List Page (mandatory for a new project) -- i.e. empty list
            if (IsNewProject)
            {
                NewProjectSetUp();
            }

            // Display curret list count
            Console.WriteLine($"Current List contains: {Program.GetPipeCount()} items");

            // Actions
            Console.WriteLine("Actions available:");
            Console.WriteLine("\t1) Filter list");
            Console.WriteLine("\t2) Sort list");
            Console.WriteLine("\t3) Output list to file");
            Console.WriteLine("\t4) Get new list");
            Console.WriteLine("\t5) Back to main page");

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
                    OutputListRequest();
                    break;
                case '4':
                    GetNewListRequest();
                    break;
                case '5':
                    BackToMainPageRequest();
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

            IsNewProject = false;
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

        private static void OutputListRequest()
        {
            // Display the page
            OutputListPage.Display();

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

        private static void BackToMainPageRequest()
        {
            Console.Clear();
            Console.WriteLine($"Going back to Main page . . .");
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
            Console.Write("What would you like to do? ");
            var request = Console.ReadKey();
            Console.WriteLine();

            // Process the Request
            switch (request.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                    return request.KeyChar;
                default:
                    // if wrong action selected, ask again
                    Console.WriteLine($"You have selected a wrong action, please select a number between 1 to 5.");
                    return RequestAction();
            }
        }

        private static bool ConfirmRequest(char requestNumber)
        {
            // Request confirmation
            Console.Write($"Please confirm your request number {requestNumber}. (y/n) ");
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
                    // if wrong confirmation action selected, ask again
                    Console.WriteLine($"Please type 'y' for yes, or 'n' for no.");
                    return ConfirmRequest(requestNumber);
            }
        }
    }
}
