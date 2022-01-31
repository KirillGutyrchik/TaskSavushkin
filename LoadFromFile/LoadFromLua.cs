using NLua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskSavushkin.LoadFromFile
{
    internal class LoadFromLua
    {
        private Lua lua { get; set; }

        private IDevice _Device { get; set; }

        private Dictionary<string, Type> _ExternalNameTypeTable;

        private List<IDevice> _DevicesList;

        public LoadFromLua(Dictionary<string, Type> externalNameTypeTable)
        {
            lua = new Lua();

            _ExternalNameTypeTable = externalNameTypeTable;

            _DevicesList = new List<IDevice>();

            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            
            lua.DoFile(fileDialog.FileName);

           
            lua.DoString(@"
             function DataHandler()
                devices = data()
                for i, device in pairs( devices ) do
                    AddDevice(device.ExternalName, device.Name, device.Price)
                    
                    for property, value in pairs( device.Properties ) do
                        AddProperty(property, value)    
                    end
                end
            end
            ");

            lua.RegisterFunction("AddDevice", this, typeof(LoadFromLua).GetMethod("AddDevice"));
            lua.RegisterFunction("AddProperty", this, typeof(LoadFromLua).GetMethod("AddProperty"));

            (lua["DataHandler"] as LuaFunction).Call();
        }

        public List<IDevice> Result()
        {
            return _DevicesList;
        }

        public void AddDevice(string externalName, string name, double price)
        {
            _Device = Device.GetObject(_ExternalNameTypeTable[externalName]);
            _Device.Name = name;
            _Device.Price = price;
            
            _DevicesList.Add(_Device);
        }

        public void AddProperty(string property, object value)
        {
            _Device.AddOrUpdateProperty(property, value.ToString());
        }
    }
}
