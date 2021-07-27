﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPractice
{
    public abstract class Message
    {
        private string _text;

        public string Text
        {

            get => _text;
            set
            {
                _text = value;
                Lines = SplitText(Text).ToArray();
            }
        }

        public string[] Lines { get; private set; }

        public MessageType Type { get; set; }

        public ConsolePrinter Printer { get; set; }


        public static List<string> SplitText(string text, int maxLength = -4)
        {
            if (maxLength <= 0)
                maxLength += Console.WindowWidth;

            if (text is null)
                text = "";

            if (text.Length <= maxLength)
                return new List<string> { text };

            List<string> result = new List<string>(text.Length / maxLength);  //Выделяем количество элементов для памяти

            int startIndex = 0;
            int index = text.LastIndexOf(' ', maxLength); //Возвращает порядковый номер последнего символа
            while (index > -1)
            {
                result.Add(text.Substring(startIndex, index - startIndex));
                startIndex = index + 1;

                if (maxLength + index >= text.Length)
                    break;

                index = text.LastIndexOf(' ', index + maxLength);
            }

            result.Add(text.Substring(startIndex));
            return result;
        }

        public Message(string message, MessageType type)
        {
            Text = message;
            Type = type;
            Printer = new ConsolePrinter();
        }
    }
}