using System;

namespace ProjectPractice
{
    public class ColorSheme
    { 
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor FontColor { get; set;  }

        public ColorSheme(ConsoleColor backColor, ConsoleColor fontColor)
        {
            BackColor = backColor;
            FontColor = fontColor;
        }

        public static ColorSheme Default
            = new ColorSheme(ConsoleColor.Black, ConsoleColor.White);

        public static ColorSheme FromConsole()
            => new ColorSheme(Console.BackgroundColor, Console.ForegroundColor);

        public static ColorSheme ActiveButtonSheme
            => new ColorSheme(ConsoleColor.White, ConsoleColor.Black);
    }
}
