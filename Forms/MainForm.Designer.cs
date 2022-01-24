
namespace TaskSavushkin
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView_Devices = new System.Windows.Forms.DataGridView();
            this.dataGridView_DevicePropertys = new System.Windows.Forms.DataGridView();
            this.property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Devices = new System.Windows.Forms.GroupBox();
            this.button_deleteDevice = new System.Windows.Forms.Button();
            this.button_addDevice = new System.Windows.Forms.Button();
            this.groupBox_DevicePropertys = new System.Windows.Forms.GroupBox();
            this.button_deleteDeviceProperty = new System.Windows.Forms.Button();
            this.button_addDeviceProperty = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Devices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DevicePropertys)).BeginInit();
            this.groupBox_Devices.SuspendLayout();
            this.groupBox_DevicePropertys.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Devices
            // 
            this.dataGridView_Devices.AllowUserToAddRows = false;
            this.dataGridView_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.type,
            this.title,
            this.price});
            this.dataGridView_Devices.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_Devices.Name = "dataGridView_Devices";
            this.dataGridView_Devices.Size = new System.Drawing.Size(510, 246);
            this.dataGridView_Devices.TabIndex = 0;
            this.dataGridView_Devices.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_Devices_SortCompare);
            // 
            // dataGridView_DevicePropertys
            // 
            this.dataGridView_DevicePropertys.AllowUserToAddRows = false;
            this.dataGridView_DevicePropertys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DevicePropertys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.property,
            this.value});
            this.dataGridView_DevicePropertys.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_DevicePropertys.Name = "dataGridView_DevicePropertys";
            this.dataGridView_DevicePropertys.Size = new System.Drawing.Size(503, 246);
            this.dataGridView_DevicePropertys.TabIndex = 1;
            // 
            // property
            // 
            this.property.HeaderText = "свойсво";
            this.property.Name = "property";
            // 
            // value
            // 
            this.value.HeaderText = "значение";
            this.value.Name = "value";
            // 
            // groupBox_Devices
            // 
            this.groupBox_Devices.Controls.Add(this.button_deleteDevice);
            this.groupBox_Devices.Controls.Add(this.button_addDevice);
            this.groupBox_Devices.Controls.Add(this.dataGridView_Devices);
            this.groupBox_Devices.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Devices.Name = "groupBox_Devices";
            this.groupBox_Devices.Size = new System.Drawing.Size(522, 330);
            this.groupBox_Devices.TabIndex = 2;
            this.groupBox_Devices.TabStop = false;
            this.groupBox_Devices.Text = "Устройства";
            // 
            // button_deleteDevice
            // 
            this.button_deleteDevice.Location = new System.Drawing.Point(100, 286);
            this.button_deleteDevice.Name = "button_deleteDevice";
            this.button_deleteDevice.Size = new System.Drawing.Size(75, 23);
            this.button_deleteDevice.TabIndex = 2;
            this.button_deleteDevice.Text = "Удалить";
            this.button_deleteDevice.UseVisualStyleBackColor = true;
            this.button_deleteDevice.Click += new System.EventHandler(this.button_deleteDevice_Click);
            // 
            // button_addDevice
            // 
            this.button_addDevice.Location = new System.Drawing.Point(19, 286);
            this.button_addDevice.Name = "button_addDevice";
            this.button_addDevice.Size = new System.Drawing.Size(75, 23);
            this.button_addDevice.TabIndex = 1;
            this.button_addDevice.Text = "Добавить";
            this.button_addDevice.UseVisualStyleBackColor = true;
            this.button_addDevice.Click += new System.EventHandler(this.button_addDevice_Click);
            // 
            // groupBox_DevicePropertys
            // 
            this.groupBox_DevicePropertys.Controls.Add(this.button_deleteDeviceProperty);
            this.groupBox_DevicePropertys.Controls.Add(this.button_addDeviceProperty);
            this.groupBox_DevicePropertys.Controls.Add(this.dataGridView_DevicePropertys);
            this.groupBox_DevicePropertys.Location = new System.Drawing.Point(540, 12);
            this.groupBox_DevicePropertys.Name = "groupBox_DevicePropertys";
            this.groupBox_DevicePropertys.Size = new System.Drawing.Size(515, 330);
            this.groupBox_DevicePropertys.TabIndex = 3;
            this.groupBox_DevicePropertys.TabStop = false;
            this.groupBox_DevicePropertys.Text = "Свойства";
            // 
            // button_deleteDeviceProperty
            // 
            this.button_deleteDeviceProperty.Location = new System.Drawing.Point(100, 285);
            this.button_deleteDeviceProperty.Name = "button_deleteDeviceProperty";
            this.button_deleteDeviceProperty.Size = new System.Drawing.Size(75, 23);
            this.button_deleteDeviceProperty.TabIndex = 3;
            this.button_deleteDeviceProperty.Text = "Удалить";
            this.button_deleteDeviceProperty.UseVisualStyleBackColor = true;
            // 
            // button_addDeviceProperty
            // 
            this.button_addDeviceProperty.Location = new System.Drawing.Point(19, 285);
            this.button_addDeviceProperty.Name = "button_addDeviceProperty";
            this.button_addDeviceProperty.Size = new System.Drawing.Size(75, 23);
            this.button_addDeviceProperty.TabIndex = 2;
            this.button_addDeviceProperty.Text = "Добавить";
            this.button_addDeviceProperty.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // number
            // 
            this.number.HeaderText = "№";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.number.Width = 50;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // title
            // 
            this.title.HeaderText = "Название";
            this.title.Name = "title";
            // 
            // price
            // 
            this.price.HeaderText = "цена";
            this.price.Name = "price";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 581);
            this.Controls.Add(this.groupBox_DevicePropertys);
            this.Controls.Add(this.groupBox_Devices);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Devices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DevicePropertys)).EndInit();
            this.groupBox_Devices.ResumeLayout(false);
            this.groupBox_DevicePropertys.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Devices;
        private System.Windows.Forms.DataGridView dataGridView_DevicePropertys;
        private System.Windows.Forms.GroupBox groupBox_Devices;
        private System.Windows.Forms.Button button_addDevice;
        private System.Windows.Forms.GroupBox groupBox_DevicePropertys;
        private System.Windows.Forms.Button button_deleteDevice;
        private System.Windows.Forms.Button button_addDeviceProperty;
        private System.Windows.Forms.Button button_deleteDeviceProperty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn property;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
    }
}

