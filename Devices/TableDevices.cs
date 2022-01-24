using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSavushkin.Devices
{
    class TableDevices
    {
        public TableDevices()
        {
            Devices = new Dictionary<ulong, IDevice>();
            CounterID = 0;
        }

        public void AddDevice(IDevice device)
        {
            Devices.Add(++CounterID, device);
        }

        public bool RemoveDevice(UInt64 ID)
        {
            return Devices.Remove(ID);
        }

        public void EditName(UInt64 ID, string newName)
        {
            Devices[ID].EditName(newName);
        }

        public void EditPrice(UInt64 ID, UInt64 newPrice)
        {
            Devices[ID].EditPrice(newPrice);
        }


        //------------------------------------------

        public UInt64 CounterID { get; set; } 

        private Dictionary<UInt64, IDevice> Devices;
    }
}
