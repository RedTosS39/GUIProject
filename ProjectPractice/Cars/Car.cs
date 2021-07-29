using ProjectPractice.Cars;
using ProjectPractice.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    class Car
    {
        [Hint("Введите бренд")]
        public string Brand { get; set; }


        [Hint("Введите потребление топлива")]
        public decimal BaseCpnsimption { get; set; }


        [Hint("Введите размер бака")]
        public int Fuel { get; set; }


        [Hint("Введите регистрационный номер")]
        public string PlateNumber { get; set; }

        [Hint("Введите дату выпуска")]
        public DateTime ReleaseDate { get; set; }

        public Position CurrentPosition { get; set; }
    }
}
