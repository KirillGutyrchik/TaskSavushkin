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


namespace TaskSavushkin
{
    

    public partial class Form_main : Form
    {



        public Form_main()
        {
            InitializeComponent();

            tableTypesDevices = new Dictionary<string, Type>();
            devices = new List<IDevice>();


            var allDeviceTypes = typeof(Device).Assembly.GetTypes().Where(t => t.BaseType == typeof(Device));
            foreach (var type in allDeviceTypes)
            {
                tableTypesDevices.Add(Device.getMethodTypeName(type)(), type);        
            }

        }


        private void button_deleteDevice_Click(object sender, EventArgs e)
        {
            dataGridView_Devices.Rows.Remove(dataGridView_Devices.CurrentRow);
        }

        private void button_addDevice_Click(object sender, EventArgs e)
        {
            dataGridView_Devices.CurrentCell =
                dataGridView_Devices
                .Rows[dataGridView_Devices.Rows.Add()]
                .Cells[2];
        }

        private void dataGridView_Devices_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = uint.Parse(e.CellValue1.ToString())
                           .CompareTo(uint.Parse(e.CellValue2.ToString()));
            e.Handled = true;
        }




        private Dictionary<string, Type> tableTypesDevices;
        private List<IDevice> devices;
    }
}
