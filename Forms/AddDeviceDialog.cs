using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TaskSavushkin.Forms
{
    public partial class AddDeviceDialog : Form
    {
    
        public AddDeviceDialog(Dictionary<string, Type> tableTypesDevices)
        {
            InitializeComponent();

            TableTypesDevices = tableTypesDevices;


            foreach (var type in TableTypesDevices)
            {
                comboBox_Types.Items.Add(type.Key);
            }

            comboBox_Types.SelectedIndex = 0;
        }

        private void button_AddDevice_Click(object sender, EventArgs e)
        {
            NewDevice = Device.getObject(TableTypesDevices[comboBox_Types.SelectedItem.ToString()]);
            NewDevice.EditName(textBox1.Text);
            NewDevice.EditPrice(UInt64.Parse(textBox2.Text));

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //-------------------------------------------
        public IDevice NewDevice { get; set; }

        private Dictionary<string, Type> TableTypesDevices { get; }
    }
}
