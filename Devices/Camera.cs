using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class Camera : Device
    {

        public Camera()
            : base(
                    "Камера",
                    "camera",
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
