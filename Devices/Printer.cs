using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class Printer : Device
    {
        public Printer()
               : base(
                    "Принтер",
                    "printer",
                    new Dictionary<string, string>()
                    {
                        { "ip", "" },
                        { "port", "" }
                    }
                  )
        {


        }
    }
}
