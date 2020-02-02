using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Pages
{
    class ProjectPage
    {
        public static void Display()
        {
            // Set up new project - To Do

            // Get List Page (mandatory for a new project)
            GetListPage.Display();
            Console.WriteLine($"Current List contains: {Program.GetPipeCount()} items");
            // Actions - To Do
        }
    }
}
