using ProjectPractice.Cars;
using ProjectPractice.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    public class OurData
    {
        public List<Car> Cars { get; private set; }

        public  List<Order> Orders { get; private set; }

        public  List<AssignedOrder> AssignedOrder { get; private set; }

        public OurData()
        {
            Cars = LoadCars(); 
            Orders = LoadOrders();
            AssignedOrder = LoadAssignedOrder();
        }

        private static List<AssignedOrder> LoadAssignedOrder()
        {
            return new List<AssignedOrder>();
        }

        private static List<Order> LoadOrders()
        {
            return new List<Order>();
        }

        private static List<Car> LoadCars()
        {
            return new List<Car>
            {
                new  Car
                {
                    Brand = "Car1",
                    BaseCpnsimption = 0.1M,
                    CurrentPosition = new Position(12, 19),
                    Fuel = 45,
                    PlateNumber = "x1141xx",
                    ReleaseDate = new DateTime(2001, 2, 2)
                },

                new  Car
                {
                    Brand = "Car2",
                    BaseCpnsimption = 0.2M,
                    CurrentPosition = new Position(5, 34),
                    Fuel = 45,
                    PlateNumber = "x1132xx",
                    ReleaseDate = new DateTime(2000, 1, 1)
                },



                new  Car
                {
                    Brand = "Car3",
                    BaseCpnsimption = 0.2M,
                    CurrentPosition = new Position(20, 18),
                    Fuel = 45,
                    PlateNumber = "x1111xx",
                    ReleaseDate = new DateTime(2000, 1, 1)
                },

                new  Car
                {
                    Brand = "Car4",
                    BaseCpnsimption = 0.2M,
                    CurrentPosition = new Position(1, 10),
                    Fuel = 45,
                    PlateNumber = "x1171xx",
                    ReleaseDate = new DateTime(2000, 1, 1)
                }
            };
        }
    }

    
}
