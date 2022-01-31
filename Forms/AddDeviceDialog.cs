using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TaskSavushkin.Forms
{
    public partial class AddDeviceDialog : Form
    {
        public IDevice NewDevice { get; set; }
        private Dictionary<string, Type> TableTypesDevices { get; }


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
            NewDevice = Device.GetObject(TableTypesDevices[comboBox_Types.SelectedItem.ToString()]);
            NewDevice.Name = textBox1.Text;
            NewDevice.Price = double.Parse(textBox2.Text);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
