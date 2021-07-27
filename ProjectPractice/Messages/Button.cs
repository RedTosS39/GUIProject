using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice
{
    public enum Button
    {
        [Description("OK")]
        OK = 0,
        [Description("ОТМЕНА")]
        Cancel = 1,
        [Description("ДА")]
        Yes = 2,
        [Description("НЕТ")]
        No = 3,
        [Description("ПРИНЯТЬ")]
        Accept = 4,
        [Description("ОТКЛОНИТЬ")]
        Decline = 5
    }
}
