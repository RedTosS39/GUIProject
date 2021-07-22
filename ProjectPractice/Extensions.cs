using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    public static class Extensions
    {

        public static ColorSheme GetSheme(this MessageType type)
        {
            switch (type)
            {

                case MessageType.Info:
                    return ColorSheme.Default;

                case MessageType.Warning:
                    return new ColorSheme(ConsoleColor.Black, ConsoleColor.Yellow);

                case MessageType.Error:
                    return new ColorSheme(ConsoleColor.Black, ConsoleColor.Red);

                default:
                    throw new ArgumentException("The type of message not valid" + type);
            }
        }

        public static void Apply(this ColorSheme sheme)
        {
            Console.BackgroundColor = sheme.BackColor;
            Console.ForegroundColor = sheme.FontColor;
        }

        public static void Apply(this ColorSheme sheme, Action printAction)
        {
            if (printAction is null)
            {
                throw new ArgumentNullException(nameof(printAction));
            }

            if (sheme.BackColor == Console.BackgroundColor && sheme.FontColor == Console.ForegroundColor)
            { 
                printAction();
                return;
            }

            var oldSheme = ColorSheme.FromConsole();
            sheme.Apply();

            try
            {
                printAction();
            }
            finally 
            { 
                oldSheme.Apply(); 
            }
        }
        
    }
}
