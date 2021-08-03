using ProjectPractice.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectPractice.Orders
{
    public record AssignedOrder(Car Car, Order Order)
    {
        public string ToDisplayString()
        {
            return $"{Order} назначениее {Car}";
        }
    }

    
}
