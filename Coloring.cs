using System;

namespace FlashCardApp
{
    public static class Coloring
    {
        public static string Error(string message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
            
            return message;
        }
        public static string Title(string message)
        {           
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message);
            Console.ResetColor();     

            return message;
        }

        public static string FeedBack(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            
            return message;
        }
    }
}
    