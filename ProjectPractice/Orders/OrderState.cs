using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Orders
{
    public enum OrderState : byte
    {
        AQ = 0,
        Qeue = 1,
        Open = 2,
        Closed = 3,
        Canseled = 4

    }
}
