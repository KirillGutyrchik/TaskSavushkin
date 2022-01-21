using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class Camera : Device
    {

        public Camera() : base()
        {
            addProperty("ip", "");
            addProperty("port", "");
        }

        static public string getTypeName()
        {
            return ("Камера");
        }
    }
}
