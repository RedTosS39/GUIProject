using ProjectPractice.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPractice
{

    class Program
    {
        static void Main(string[] args)
        {


            //UI
            // Console.WriteLine("╔═════════════════════╗");
            // Console.WriteLine("║                     ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║   тут что написано. ║");
            // Console.WriteLine("║                     ║");
            // Console.WriteLine("╚═════════════════════╝");


            //Button.OK.GetDescription();
            //
            //var result = Dialog.ShowQuestion("Sine text", MessageType.Info, Button.OK, Button.Cancel);
            ////new Dialog("Some text").Show();
            //
            //if (result == Button.OK) 
            //{
            //    Console.WriteLine("OK");
            //}

            // var result  = new Menu("Text", "Элемент номер один", "Номер два", "Номер Три", "SomeText").Show();
            //
            // if (result == 0) 
            // {
            //     Console.WriteLine("Выбран первый элемент");
            // }

            InputForm<Car> form = new("Введите Информацию о машине");
            form.Show();

        }

    }
    
}
