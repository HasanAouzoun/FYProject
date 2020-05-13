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
            Console.WriteLine("Filter App - Used to filter a list of strings using a regular expression string\n");

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
            Console.Clear();

            Console.WriteLine($"Help and Information Page:" +
                $"\n\nThis app was developed to filter a list of passwords to remove" +
                $"\nthe passwords categorised as invalid for a Replacement Pattern." +
                $"\nThe output of this app is used as an input for a script that identifies" +
                $"\nreplcement patterns. This was created for the final year project at the" +
                $"\nUniversity of salford." +
                
                $"\n\nHow to use:" +
                $"\n\tFirstly you need a list of strings. This needs to conatin strings separated" +
                $"\n\tby line." +
                $"\n\tThen you have several options to choose from:" +
                $"\n\t1) Sort: to sort the list. Either by ascending or descending order." +
                $"\n\t2) Filter: to filter it using a regular expresion." +
                $"\n\t3) Output: to output the current list to the file." +
                $"\n\t4) Get New: to get a new list." +

                $"\nEach option displays more information when they are chosen." +
                
                $"\n\nPress any key to go back...");

            Console.ReadKey();
            Display();
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
