using GUIProject.Forms;
using ProjectPractice.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Navigation
{
    public class CarMenu : NavigationMenu
    {

        private const string _CAR_PARK = "Парк Машин";

        public OurData Data { get; set; }

        public View<Car> View { get; }



        public CarMenu(OurData data) : base(_CAR_PARK)
        {
            Data = data;
            AddItems(
                ("Просмотр машин", ViewCars),
                ("Ввод новой машины", InputNewCar),
                ("В главное меню", Empty));
            
        }

        public void ViewCars()
        {
            var newMenu = new NavigationMenu<Car>("Все машины, которые у нас есть");
            newMenu.BindItems(Data.GetData<Car>(), selectAction: c =>
            {
                View.Show(c);
                newMenu.Show();
            });

            newMenu.AddItems(("Возврат", Empty));
            newMenu.Show();
        }

        public void InputNewCar()
        {
            var carForm = new InputForm<Car>("Введите информацию о новой машине");
            if (carForm.Show())
            {
                Data.GetData<Car>().Add(carForm.Value);
                Data.SaveItem(carForm.Value);
            }
            this.Show();
        }
    }
}
