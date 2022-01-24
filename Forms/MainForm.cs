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


namespace TaskSavushkin
{
    

    public partial class MainForm : Form
    {



        public MainForm()
        {
            InitializeComponent();

            TableTypesDevices = new Dictionary<string, Type>();
            Devices = new TableDevices();


            var allDeviceTypes = typeof(Device).Assembly.GetTypes().Where(t => t.BaseType == typeof(Device));
            foreach (var type in allDeviceTypes)
            {
                TableTypesDevices.Add(Device.getMethodTypeName(type)(), type);        
            }

        }


        private void button_deleteDevice_Click(object sender, EventArgs e)
        {
            if (dataGridView_Devices.Rows.Count > 0)
            {
                Devices.RemoveDevice(ulong.Parse(dataGridView_Devices.CurrentRow.Cells[0].Value.ToString()));
                dataGridView_Devices.Rows.Remove(dataGridView_Devices.CurrentRow);
            }
        }

        private void button_addDevice_Click(object sender, EventArgs e)
        {
            var dialog = new AddDeviceDialog(TableTypesDevices);


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Devices.AddDevice(dialog.NewDevice);

                dataGridView_Devices.CurrentCell =
                    dataGridView_Devices
                    .Rows[dataGridView_Devices.Rows.Add()]
                    .Cells[2];

                dataGridView_Devices.CurrentRow.Cells[0].Value = Devices.CounterID;
                dataGridView_Devices.CurrentRow.Cells[1].Value = dialog.NewDevice.GetTypeName();
                dataGridView_Devices.CurrentRow.Cells[2].Value = dialog.NewDevice.GetName();
                dataGridView_Devices.CurrentRow.Cells[3].Value = dialog.NewDevice.GetPrice();
            }


        }

        private void dataGridView_Devices_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = uint.Parse(e.CellValue1.ToString())
                           .CompareTo(uint.Parse(e.CellValue2.ToString()));
            e.Handled = true;
        }




        private Dictionary<string, Type> TableTypesDevices;


        private TableDevices Devices;
       
    }
}
