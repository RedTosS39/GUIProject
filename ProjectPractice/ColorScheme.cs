using System;

namespace ProjectPractice
{
    public class ColorScheme
    { 
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor FontColor { get; set;  }

        public ColorScheme(ConsoleColor backColor, ConsoleColor fontColor)
        {
            BackColor = backColor;
            FontColor = fontColor;
        }

        public static ColorScheme Default
            = new ColorScheme(ConsoleColor.Black, ConsoleColor.White);

        public static ColorScheme FromConsole()
            => new ColorScheme(Console.BackgroundColor, Console.ForegroundColor);

        public static ColorScheme ActiveButtonSheme
            => new ColorScheme(ConsoleColor.White, ConsoleColor.Black);

        public static ColorScheme InputTextScheme
            => new ColorScheme(ConsoleColor.White, ConsoleColor.DarkGray);
    }
}
