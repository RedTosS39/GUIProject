﻿using ProjectPractice.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ProjectPractice
{
    public static class Extensions
    {

        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute description = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttribute<DescriptionAttribute>();

            if (description is not null)
                return description.Description;
            return "";
        }

        public static string GetHint(this PropertyInfo property)
        {
            HintAttribute hint = property.GetCustomAttribute<HintAttribute>();
            if (hint is not null) return hint.Hint;

            return property.Name;
        }

        public static ColorScheme GetScheme(this MessageType type)
        {
            switch (type)
            {

                case MessageType.Info:
                    return ColorScheme.Default;

                case MessageType.Warning:
                    return new ColorScheme(ConsoleColor.Black, ConsoleColor.Yellow);

                case MessageType.Error:
                    return new ColorScheme(ConsoleColor.Black, ConsoleColor.Red);

                default:
                    throw new ArgumentException("The type of message not valid" + type);
            }
        }

        public static void Apply(this ColorScheme scheme)
        {
            Console.BackgroundColor = scheme.BackColor;
            Console.ForegroundColor = scheme.FontColor;
        }

        public static void Apply(this ColorScheme scheme, Action printAction)
        {
            if (printAction is null)
            {
                throw new ArgumentNullException(nameof(printAction));
            }

            if (scheme.BackColor == Console.BackgroundColor && scheme.FontColor == Console.ForegroundColor)
            { 
                printAction();
                return;
            }

            var oldSheme = ColorScheme.FromConsole();
            scheme.Apply();

            try
            {
                printAction();
            }
            finally 
            { 
                oldSheme.Apply(); 
            }
        }

        public static void Apply(this ColorScheme scheme, int x, int y, Action printAction)
        {
           
            (int oldX, int oldY) = Console.GetCursorPosition();

            Console.SetCursorPosition(x, y);

            if (scheme is not null) 
            {
                scheme.Apply(printAction);
            } 
            else { printAction(); }

            Console.SetCursorPosition(oldX, oldY);
        }


    }
}
