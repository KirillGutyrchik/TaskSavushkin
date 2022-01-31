using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class TableDevices
    {
        public ulong CounterID { get; set; }

        public Dictionary<ulong, IDevice> Devices { get; }

        
        public TableDevices()
        {
            Devices = new Dictionary<ulong, IDevice>();
            CounterID = 0;
        }

        public void AddDevice(IDevice device)
        {
            Devices[++CounterID] = device;
        }

        public IDevice this[ulong ID]
        {
            get => Devices[ID];
            set => Devices[ID] = value;
        }

        public bool RemoveDevice(ulong ID)
        {
            return Devices.Remove(ID);
        }

        public void EditName(ulong ID, string newName)
        {
            Devices[ID].Name = newName;
        }

        public void EditPrice(ulong ID, ulong newPrice)
        {
            Devices[ID].Price = newPrice;
        }

    }
}
