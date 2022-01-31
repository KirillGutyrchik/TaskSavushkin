using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq.Expressions;
using TaskSavushkin.Forms;
using TaskSavushkin.Devices;
using TaskSavushkin.LoadFromFile;
using TaskSavushkin.UploadToFile;

namespace TaskSavushkin
{


    public partial class MainForm : Form
    {
        private Dictionary<string, Type> UINameTypeTable;

        private Dictionary<string, Type> ExternalNameTypeTable;

        private TableDevices Devices;


        public MainForm()
        {
            InitializeComponent();

            UINameTypeTable = new Dictionary<string, Type>();
            ExternalNameTypeTable = new Dictionary<string, Type>(); 
            Devices = new TableDevices();


            var allDeviceTypes = typeof(Device).Assembly.GetTypes().Where(t => t.BaseType == typeof(Device));
            foreach (var type in allDeviceTypes)
            {
                var NamesType = Device.GetUINameType(type);

                UINameTypeTable.Add(NamesType.Item1, type);
                ExternalNameTypeTable.Add(NamesType.Item2, type);
            }
        }


        private ulong CurrentDeviceID
        {
            get
            {
               return (dataGridView_Devices.Rows.Count > 0 
                       && dataGridView_Devices.CurrentRow.Cells[0].Value != null) ?
                    ulong.Parse(dataGridView_Devices.CurrentRow.Cells[0].Value.ToString())
                    : 0;
            } 
        }


        private void DeleteDevice(object sender, EventArgs e)
        {
            if (dataGridView_Devices.Rows.Count > 0)
            {
                Devices.RemoveDevice(CurrentDeviceID);
                dataGridView_Devices.Rows.Remove(dataGridView_Devices.CurrentRow);
            }
        }

        private void AddDevice(object sender, EventArgs e)
        {
            var dialog = new AddDeviceDialog(UINameTypeTable);


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Devices.AddDevice(dialog.NewDevice);

                dataGridView_Devices.CurrentCell =
                   dataGridView_Devices
                   .Rows[dataGridView_Devices.Rows.Add(Devices.CounterID,
                                                       dialog.NewDevice.UINameType,
                                                       dialog.NewDevice.Name,
                                                       dialog.NewDevice.Price)]
                   .Cells[2];

                SelectedDevice(null,  new DataGridViewCellEventArgs(0,0));
            }
        }

        private void DeviceSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "price")
            {
                e.SortResult = double.Parse(e.CellValue1.ToString())
                               .CompareTo(double.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
            else if (e.Column.Name == "number")
            {
                e.SortResult = ulong.Parse(e.CellValue1.ToString())
                               .CompareTo(ulong.Parse(e.CellValue2.ToString()));
            }



        }

        private void AddDeviceProperty(object sender, EventArgs e)
        {
            if (dataGridView_Devices.Rows.Count > 0)
            {
                dataGridView_DevicePropertys.CurrentCell =
                    dataGridView_DevicePropertys.Rows[dataGridView_DevicePropertys.Rows.Add()]
                    .Cells[0];

                dataGridView_DevicePropertys.CurrentCell.ReadOnly = false;
            }
        }

        private void PropertyChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Devices[CurrentDeviceID]
                        .AddOrUpdateProperty(
                            dataGridView_DevicePropertys.Rows[e.RowIndex].Cells[0].Value?.ToString(),
                            dataGridView_DevicePropertys.Rows[e.RowIndex].Cells[1].Value?.ToString()
                            );

                if (e.ColumnIndex == 0)
                    dataGridView_DevicePropertys.CurrentCell.ReadOnly = true;
            }
        }

        private void DeleteDeviceProperty(object sender, EventArgs e)
        {
            if(dataGridView_DevicePropertys.Rows.Count > 0)
            {
                if (Devices[CurrentDeviceID]
                    .RemoveProperty(dataGridView_DevicePropertys.CurrentRow.Cells[0].Value.ToString()))
                {
                    dataGridView_DevicePropertys.Rows.Remove(dataGridView_DevicePropertys.CurrentRow);
                }
            }

        }

        
        private void SelectedDevice(object sender, EventArgs e)
        {
            if (dataGridView_Devices.Rows.Count > 0)
            {
                dataGridView_DevicePropertys.Rows.Clear();

                foreach (var property in Devices[CurrentDeviceID].DefaultProperties)
                {
                    dataGridView_DevicePropertys.Rows.Add(property.Key, property.Value);
                }

                foreach (var property in Devices[CurrentDeviceID].Properties)
                {
                    dataGridView_DevicePropertys.Rows.Add(property.Key, property.Value);
                }
            }
        }

        private void LoadInLua(object sender, EventArgs e)
        {
            new UploadToLua(Devices);
        }

        private void ExportFromLua(object sender, EventArgs e)
        {
            foreach(var device in new LoadFromLua(ExternalNameTypeTable).Result())
            {
                Devices.AddDevice(device);
                dataGridView_Devices.Rows.Add(Devices.CounterID,
                                              device.UINameType,
                                              device.Name,
                                              device.Price);
            }
        }
    }
}
