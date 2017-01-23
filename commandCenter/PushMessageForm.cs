using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using commandCenter.CodeproofService;

namespace commandCenter
{
    public partial class PushMessageForm : Form
    {
        public CPID selectedDevice { get; set; }
        public Authenticate authObj { get; set; }

        public PushMessageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Pleas enter a message");
                textBox1.Focus();
                return;
            }

            button1.Enabled = false;

            //send push message command

            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            CommandRecord cmd = new CommandRecord();

            cmd.Command ="sendmessage";//do not change this

            cmd.CommandName = "SDK send message test";
            cmd.Param1 = textBox1.Text;
            cmd.Notes = "SDK sample test command";

            CommandRecord cmdupdated = cpservice.ExecuteCommand(authObj, selectedDevice, cmd);

            MessageBox.Show(cmdupdated.Status);
            
            button1.Enabled = true;
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
