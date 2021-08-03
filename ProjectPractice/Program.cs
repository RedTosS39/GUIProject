using ProjectPractice.Cars;
using ProjectPractice.Forms;
using ProjectPractice.Navigation;
using ProjectPractice.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectPractice
{

    class Program
    {
        /*
        public static string BaseDirectory = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ProjectPractice");

        public static string CarDirectory =
               Path.Combine(BaseDirectory, "Cars"); 

        public static string OrderDirectory =
           Path.Combine(BaseDirectory, "Orders");
        */
       
     /*   public static string[] MainMenu =
        {
            "Парк машин",
            "Добавление заказа",
            "Назначение заказа",
            "Выход из программы"
        };


        public static string[] SubMenu =
        {
             "Просмотр машин",
             "Ввод новой машины",
             "Назначение заказа",
             "В главное меню"
        };
    */


        static void Main(string[] args)
        {
            var paths = new Paths();
            var numerator = new Numerator(paths);

            numerator.LoadNumbers();
            var order = new Order(numerator);
            numerator.SaveNumbers();


            var data = new OurData();
            var carMenu = new CarMenu(data.Cars);
            new MainMenu(data, carMenu).Show();
        }


        /*static void OldMain(string[] args)
        {
            CheckDirectories();

            Cars = LoadCars();
            Orders = LoadOrders();
            AssignedOrder = LoadAssignedOrder();

            var mainMenu = new Menu("Выберите пункт меню", MainMenu);
            var subMenu = new Menu("Парк машин ", SubMenu);

            int currentMenu = mainMenu.Show();

            while (true)
            {
                switch (currentMenu)
                {
                    case 0:
                        int currentSubMenu = subMenu.Show();
                        while (currentSubMenu < 2)
                        {
                            switch (currentSubMenu)
                            {
                                case 0:
                                    //Вывели список всех машин
                                    var carMenu = new Menu("Все машины в наличии ", Cars.Select(c => c.ToString()).Concat(new[] { "Возврат"}).ToArray());

                                    int selectedCar = carMenu.Show();
                                    while (selectedCar < Cars.Count)
                                    {
                                        selectedCar = carMenu.Show();
                                    }

                                    break;

                                case 1:

                                    var carForm = new InputForm<Car>("Введите информацию о новой машине");
                                    carForm.Show();

                                    if (carForm.Show())
                                    {
                                        Cars.Add(carForm.Value);
                                    }
                                    break;
                            }
                            currentMenu = mainMenu.Show();
                        }
                        break;

                    case 1:
                        var orderForm = new InputForm<Order>("Введите информацию о заказе");

                        if (orderForm.Show())
                        {
                            var newOrder = orderForm.Value;
                            Orders.Add(newOrder);
                            Dialog.ShowMessage("Создан новый заказ" + newOrder);
                        }
                        break;

                    case 2:
                        var orderMenu = new Menu("Введите заказ", Orders.Select(o => o.ToString()).Concat(new[] { "Назад" }).ToArray());
                        var index = orderMenu.Show();
                        if (index == Orders.Count)
                                 break;
                            var selectedOrder = Orders[index];

                        var carSubMenu = new Menu("Все машины в наличии ", Cars.Select(c => c.ToString()).Concat(new[] { "Возврат" }).ToArray());
                        index = carSubMenu.Show();
                        if (index == Cars.Count)
                            break;

                        var assignedOrder = new AssignedOrder(Cars[index], selectedOrder);
                        Dialog.ShowMessage(assignedOrder.ToDisplayString());
                        break;
             

                    case 3:
                        if (Dialog.ShowQuestion("Вы действительно хотите выйти и программы") == Button.Yes)
                            return;
                        break;
                }
                currentMenu = mainMenu.Show();

            }
        }
        */

    }
    
}
