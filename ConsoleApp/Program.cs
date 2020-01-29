using System.Collections.Generic;
using ConsoleApp.Pages;

namespace ConsoleApp
{
    class Program
    {
        private static List<string> _Pipe;

        static void Main()
        {
            // Initial set up
            _Pipe = new List<string>();

            MainPage.Display();
        }
    }
}
