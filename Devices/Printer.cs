using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class Printer : Device
    {
        public Printer() : base()
        {
            addProperty("ip", "");
            addProperty("port", "");
        }

        static public string getTypeName()
        {
            return ("Принтер");
        }
    }
}
