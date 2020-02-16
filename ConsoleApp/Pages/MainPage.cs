using System;
using System.Collections.Generic;
using ConsoleApp.Helpers;

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
            Console.WriteLine("1) Start New Project");
            Console.WriteLine("2) Continue Project");
            Console.WriteLine("3) Help");
            Console.WriteLine("4) Exit");

            // Request Action
            var action = RequestAndCheckAction();

            switch (action)
            {
                case '1':
                    StartNewProject();
                    break;
                case '2':
                    ContinueProject();
                    break;
                case '3':
                    HelpRequest();
                    break;
                case '4':
                    ExitRequest();
                    break;
            }
        }

        private static void StartNewProject()
        {
            Program._Pipe = new List<string>();
            ProjectPage.IsNewProject = true;
            ProjectPage.Display();
        }

        private static void ContinueProject()
        {
            ProjectPage.Display();
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
            Console.WriteLine($"Exiting . . .");
        }

        private static char RequestAndCheckAction()
        {
            // Request Action
            var action = RequestAction();

            // Check Action check
            if (CheckRequest(action) == false)
            {
                action = RequestAndCheckAction();
            }

            return action;
        }

        private static char RequestAction()
        {
            // Request Input
            Console.Write("\nWhat would you like to do? ");
            var request = Console.ReadKey();
            Console.WriteLine();

            // Process the Request
            switch (request.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                    return request.KeyChar;
                default:
                    // if wrong action selected
                    Console.WriteLine($"You have selected a wrong action, please select a number between 1 to 4.");
                    return RequestAction();
            }
        }

        private static bool CheckRequest(char action)
        {
            // if start new project and there is a previous project - ask for confirmation
            // if continue - check that there was a project already
            // if Exiting - ask for confirmation
            // 

            if(action == '1') // start new project
            {
                if(ProjectPage.IsNewProject == false)
                {
                    // If already has a list - ask for confirmation
                    Console.WriteLine("Would you like to start a new project? You will lose the current progress.");
                    return ConsoleHelper.InputConfirmation();
                }
                // otherwise allow action
                return true;
            }

            if (action == '2') // continue project
            {
                if(ProjectPage.IsNewProject == false)
                {
                    // allow if there is a project to continue
                    return true;
                }

                Console.WriteLine("There is no project to continue. Please start a new one.");
                return false;
            }

            if (action == '4') // Exit
            {
                Console.WriteLine("Would you like to close the app?");
                return ConsoleHelper.InputConfirmation();
            }

            // allow any other valid request
            return true;
        }
    }
}
