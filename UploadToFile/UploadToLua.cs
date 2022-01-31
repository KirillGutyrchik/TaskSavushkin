using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskSavushkin.Devices;

namespace TaskSavushkin.UploadToFile
{
    internal class UploadToLua
    {

        static string Tab = "\t";
        static string Ret = "\n";

        string data;

        public UploadToLua(TableDevices devices)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.ShowDialog();

            data = "data = function()" + Ret +
                   Tab + "return"      + Ret + 
                   Tab + "{"           + Ret;
    
            foreach(var device in devices.Devices)
            {
                UploadDevice(device.Value);
            }

            data = data.Substring(0, data.Length - 2);
            data +=
                Ret +
                Tab + "}" + Ret +
                "end";

            File.WriteAllText(fileDialog.FileName, data);
        }

        private void UploadDevice(IDevice device)
        {
            data += 
                Tab + Tab + "{" + Ret +
                Tab + Tab + Tab + "ExternalName = \"" + device.ExternalNameType                        + "\"," + Ret +
                Tab + Tab + Tab + "Name = \""         + device.Name                                    + "\"," + Ret +
                Tab + Tab + Tab + "Price = "          + device.Price.ToString("0.##").Replace(',','.') + ","   + Ret;

            UploadProperties(device.DefaultProperties, device.Properties);
            data +=
                Tab + Tab + "}," + Ret;
        }



        private void UploadProperties(
            Dictionary<string, string> defaultProperties,
            Dictionary<string, string> properties)
        {
            data +=
                Tab + Tab + Tab + "Properties = " + Ret +
                Tab + Tab + Tab + "{" + Ret;

            foreach(var property in defaultProperties)
            {
                data +=
                    Tab + Tab + Tab + Tab + property.Key + " = \"" + property.Value + "\"," + Ret;
            }

            foreach (var property in properties)
            {
                data +=
                    Tab + Tab + Tab + Tab + property.Key + " = \"" + property.Value + "\"," + Ret;
            }
            data = data.Substring(0, data. Length - 2);
            data +=
                Ret +
                Tab + Tab + Tab + "}" + Ret;
        }


    }
}
