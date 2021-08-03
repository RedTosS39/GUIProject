using ProjectPractice.Forms;
using ProjectPractice.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Navigation
{
    public class MainMenu : NavigationMenu
    {
        private const string _MAIN_MAIN_MENU = "Выберите пункт меню";

        public OurData Data { get; set; }

        public CarMenu CarMenu { get; }


        public MainMenu(OurData data, CarMenu carMenu) : base(_MAIN_MAIN_MENU)
        {
            Data = data;
            CarMenu = carMenu;

            AddItems(
                ("Парк машин", ShowCarPark),
                ("Добавить заказ", AddOrder),
                ("Назначение заказа", SetAssignedOrder),
                ("Выход из программы", ExitQuastion));


        }


        public void ShowCarPark()
        {
            CarMenu.Show();
            Show();
        }


        public void AddOrder()
        {
            var orderForm = new InputForm<Order>("Введите информацию о заказе");

            if (orderForm.Show())
            {
                var newOrder = orderForm.Value;
                Data.Orders.Add(newOrder);
                Dialog.ShowMessage("Создан новый заказ" + newOrder);
                Show();
            }

        }

        public void SetAssignedOrder()
        {
            var orderMenu = new Menu("Введите заказ", Data.Orders.Select(o => o.ToString()).Concat(new[] { "Назад" }).ToArray());
            var index = orderMenu.Show();
            if (index == Data.Orders.Count)
            {
                Show();
                return;
            }

            var selectedOrder = Data.Orders[index];

            var carSubMenu = new Menu("Все машины в наличии ", Data.Cars.Select(c => c.ToString()).Concat(new[] { "Возврат" }).ToArray());
            index = carSubMenu.Show();
            if (index == Data.Cars.Count)
            {
                Show();
                return;
            }


            var assignedOrder = new AssignedOrder(Data.Cars[index], selectedOrder);
            Dialog.ShowMessage(assignedOrder.ToDisplayString());
            Show();

        }

        public void ExitQuastion()
        {
            if (Dialog.ShowQuestion("Вы действительно хотите выйти из программы?") == Button.No)
                Show();
        }
    }
}
