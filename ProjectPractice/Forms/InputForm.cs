﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProjectPractice.Forms
{
    public class InputForm<T> : Message where T: new()
    {
        public TextElement[] Elements { get; }

        public T Value { get; }

        private int HintLength { get; }

        public InputForm(string message) 
            : base(message, MessageType.Info)
        {
            Value = new T();

            var properties = typeof(T).GetProperties(
                  BindingFlags.Public 
                | BindingFlags.Instance 
                | BindingFlags.SetProperty 
                | BindingFlags.GetProperty);

            Elements = properties.Select(p => GetElement(p)).Where(el => el != null).ToArray();

            HintLength = Elements.Max(el => el.Hint.Length);



            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].Y = Lines.Length + i * 2 + 4;
            }
        }

        private TextElement GetElement(PropertyInfo property)
        {
            if (property.PropertyType.Name == nameof(String))
            {
                return new TextElement(property.GetHint(), value => property.SetValue(Value, value));
            }

            else if (property.PropertyType.Name == nameof(Int32))
            {
                return new DigitElement(property.GetHint(), (int value) => property.SetValue(Value, value));
            }

            else if (property.PropertyType.Name == nameof(Decimal))
            {
                return new DigitElement(property.GetHint(), (decimal value) => property.SetValue(Value, value));
            }

            else if (property.PropertyType.Name == nameof(DateTime))
            {
                return new DateElement(property.GetHint(), value => 
                    property.SetValue(Value, value));
            }

            return null;
        }

        public bool Show() 
        {

            Printer.Clear();

            Printer.PrintTopEdge();

            Printer.PrintEmptyLine();

            Printer.PrintMessage(Lines, Type.GetSheme());

            Printer.PrintEmptyLine();

            for (int i = 0; i < Elements.Length; i++)
            {
                Printer.PrintMiddleLine();
                Printer.PrintMessage(new[] { $"{Elements[i].Hint.PadLeft(HintLength, ' ')}: " }, ColorScheme.Default);
            }

            Printer.PrintBottomEdge();

            (int oldX, int oldY) = Console.GetCursorPosition();

            foreach (TextElement elements in Elements)
            {
                Console.SetCursorPosition(HintLength + 4, elements.Y);
                if (!elements.Input())
                    return false;
            }

            Console.SetCursorPosition(oldX, oldY);

            return true;
        }
    }
}
