using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Helpers
{
    class Notes
    {
        public static void processingProgress()
        {
            Console.WriteLine("Hello World!");

            var lenght = 50;
            var rowNumber = Console.CursorTop;
            for (int i = 0; i <= lenght; i++)
            {
                Console.SetCursorPosition(0, rowNumber);

                Console.WriteLine($"processing ... ({i}/{lenght})");

                Thread.Sleep(100);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
