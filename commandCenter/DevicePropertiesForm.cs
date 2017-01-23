using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace commandCenter
{
    public partial class DevicePropertiesForm : Form
    {
        public string deviceProps
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public DevicePropertiesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
