////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Codeproof Mobile Device Management API sample usage program. For questions, please email to support@codeproof.com 
//
// Copyright (C) 2013, Codeproof Technologies Inc. All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;

using commandCenter.CodeproofService;

namespace commandCenter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = listView1.ListViewItemSorter as ListViewItemComparer;

            if (sorter == null)
            {
                sorter = new ListViewItemComparer(e.Column);
                listView1.ListViewItemSorter = sorter;
            }
            else
            {
                sorter.Column = e.Column;
            }

            listView1.Sort();
        }

        private void InitializeComponent()
        {            
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendScreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataWipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locateDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codeproof Account Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "API Key:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Get Device Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(185, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(263, 20);
            this.textBox2.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 125);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(766, 470);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device Name";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Phone Number";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Device Id";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Manufacturer";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Model";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "OS Name";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "OS Version";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Last CheckinTime";
            this.columnHeader8.Width = 126;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.sendScreamToolStripMenuItem,
            this.lockToolStripMenuItem,
            this.dataWipeToolStripMenuItem,
            this.locateDeviceToolStripMenuItem,
            this.devicePropertiesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 136);
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Push Message";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
            // 
            // sendScreamToolStripMenuItem
            // 
            this.sendScreamToolStripMenuItem.Name = "sendScreamToolStripMenuItem";
            this.sendScreamToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.sendScreamToolStripMenuItem.Text = "Send Scream";
            this.sendScreamToolStripMenuItem.Click += new System.EventHandler(this.sendScreamToolStripMenuItem_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.lockToolStripMenuItem.Text = "Lock Screen";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // dataWipeToolStripMenuItem
            // 
            this.dataWipeToolStripMenuItem.Name = "dataWipeToolStripMenuItem";
            this.dataWipeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dataWipeToolStripMenuItem.Text = "Data Wipe";
            this.dataWipeToolStripMenuItem.Click += new System.EventHandler(this.dataWipeToolStripMenuItem_Click);
            // 
            // locateDeviceToolStripMenuItem
            // 
            this.locateDeviceToolStripMenuItem.Name = "locateDeviceToolStripMenuItem";
            this.locateDeviceToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.locateDeviceToolStripMenuItem.Text = "Locate Device";
            this.locateDeviceToolStripMenuItem.Click += new System.EventHandler(this.locateDeviceToolStripMenuItem_Click);
            // 
            // devicePropertiesToolStripMenuItem
            // 
            this.devicePropertiesToolStripMenuItem.Name = "devicePropertiesToolStripMenuItem";
            this.devicePropertiesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.devicePropertiesToolStripMenuItem.Text = "Device Properties";
            this.devicePropertiesToolStripMenuItem.Click += new System.EventHandler(this.devicePropertiesToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(12, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "(C) 2013, Codeproof Technologies Inc, All rights reserved.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(464, 54);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get API key here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Close App";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 637);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Mobile Device Management API Sample App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please enter valid Codeproof Account email-id");
                textBox1.Focus();
                return;
            }
            else 
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please enter valid Codeproof API Key");
                textBox2.Focus();
                return;
            }

            button1.Enabled = false;
            listView1.Items.Clear();

            Authenticate authObj = new Authenticate();
            authObj.userid = textBox1.Text;
            authObj.apikey = textBox2.Text;
           
            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            //get Codeproof device identifiers
            CPID[] cpids = cpservice.GetCPIDs(authObj);

            foreach (CPID deviceRecord in cpids)
            {
                DeviceProperty dp = cpservice.GetDeviceProperty(authObj, deviceRecord);

                List<string> items = new List<string>();

                items.Add(GetPropValue(dp.DeviceInformations, "DeviceName"));
                items.Add(GetPropValue(dp.DeviceInformations, "PhoneNumber"));

                string id = GetPropValue(dp.DeviceInformations, "UDID");
                if (id == null)
                {
                    items.Add(GetPropValue(dp.DeviceInformations, "SecureAndroidId"));
                }
                else
                {
                    items.Add(id);
                }

                items.Add(GetPropValue(dp.DeviceInformations, "Manufacturer"));
                   
                items.Add(GetPropValue(dp.DeviceInformations, "ModelName"));
                   
                items.Add(GetPropValue(dp.DeviceInformations, "OSName"));
                 
                items.Add(GetPropValue(dp.DeviceInformations, "OSVersion"));

                items.Add(dp.LastCheckinTime);

                ListViewItem listViewItem1 = new ListViewItem(items.ToArray());

                listViewItem1.Tag = new object[] { authObj, deviceRecord, dp.DeviceInformations}; //pass object array

                listView1.Items.AddRange(new ListViewItem[] {listViewItem1});
            }

            button1.Enabled = true;
        }
        
        public string GetPropValue(NameValue[] DeviceInformations, string name)
        {
            foreach (NameValue prop in DeviceInformations)
            {
                if (prop.Name == name)
                {
                    return prop.Value;
                }
            }

            return null;
        }

      
        private void dataWipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to delete all the data in the device?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CodeproofServiceClient cpservice = new CodeproofServiceClient();

                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    Authenticate authObj = (Authenticate)((object[])item.Tag)[0];
                    CPID selectedDevice = (CPID)((object[])item.Tag)[1];

                    CommandRecord cmd = new CommandRecord();

                    cmd.Command = "datawipe";//do not change this

                    cmd.CommandName = "SDK data wipe cmd test";
                    cmd.Notes = "SDK sample test command";

                    CommandRecord cmdupdated = cpservice.ExecuteCommand(authObj, selectedDevice, cmd);
                    MessageBox.Show(cmdupdated.Status);

                    break;
                }
            }
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedMenuItem = sender as ToolStripItem;
            
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Authenticate authObj = (Authenticate)((object[])item.Tag)[0];
                CPID selectedDevice = (CPID)((object[])item.Tag)[1];

                PushMessageForm pushMesgForm = new PushMessageForm();

                pushMesgForm.authObj = authObj;
                pushMesgForm.selectedDevice = selectedDevice;

                pushMesgForm.ShowDialog();
                break;
            }
        }

        private void sendScreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Authenticate authObj = (Authenticate)((object[])item.Tag)[0];
                CPID selectedDevice = (CPID)((object[])item.Tag)[1];

                CommandRecord cmd = new CommandRecord();

                cmd.Command = "sendscream";//do not change this

                cmd.CommandName = "SDK send scream cmd test";
                cmd.Notes = "SDK sample test command";

                CommandRecord cmdupdated = cpservice.ExecuteCommand(authObj, selectedDevice, cmd);
                MessageBox.Show(cmdupdated.Status); 
                break;
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Authenticate authObj = (Authenticate)((object[])item.Tag)[0];
                CPID selectedDevice = (CPID)((object[])item.Tag)[1];

                CommandRecord cmd = new CommandRecord();

                cmd.Command = "screenlock";//do not change this

                cmd.CommandName = "SDK screen lock cmd test";
                cmd.Notes = "SDK sample test command";

                CommandRecord cmdupdated = cpservice.ExecuteCommand(authObj, selectedDevice, cmd);
                MessageBox.Show(cmdupdated.Status); 
                break;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save settings.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            app.Settings.Remove("userid");
            app.Settings.Add("userid", textBox1.Text);

            app.Settings.Remove("apikey");
            app.Settings.Add("apikey", textBox2.Text);
            config.Save(ConfigurationSaveMode.Modified);

            this.Close();
        }


        private void locateDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                NameValue[] deviceProps = (NameValue[])((object[])item.Tag)[2];

                string locationIfo = GetPropValue(deviceProps, "Latitude") + "," + GetPropValue(deviceProps, "Longitude");

                LocateMeForm locateMeForm = new LocateMeForm();

                locateMeForm.lacationInfo = locationIfo;
                locateMeForm.ShowDialog();
                break;
            }
        }

        private void devicePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                NameValue[] deviceProps = (NameValue[])((object[])item.Tag)[2];

                DevicePropertiesForm propsForm = new DevicePropertiesForm();

                //collect all props;
                StringBuilder props = new StringBuilder();
                foreach (NameValue prop in deviceProps)
                {
                    props.Append(prop.Name + "=" + prop.Value + "\r\n");
                }

                propsForm.deviceProps = props.ToString();
                propsForm.ShowDialog();
                break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Load settings

          
                textBox1.Text = ConfigurationManager.AppSettings["userid"];
                textBox2.Text = ConfigurationManager.AppSettings["apikey"];
                string version = ConfigurationManager.AppSettings["version"];

                if (version == null)
                {
                    MessageBox.Show("Failed to load App config file");
                }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }

    public class ListViewItemComparer : IComparer
    {
        private int column;
        private bool numeric = false;

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public bool Numeric
        {
            get { return numeric; }
            set { numeric = value; }
        }

        public ListViewItemComparer(int columnIndex)
        {
            Column = columnIndex;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;

            if (itemX == null && itemY == null)
                return 0;
            else if (itemX == null)
                return -1;
            else if (itemY == null)
                return 1;

            if (itemX == itemY) return 0;

            if (Numeric)
            {
                decimal itemXVal, itemYVal;

                if (!Decimal.TryParse(itemX.SubItems[Column].Text, out itemXVal))
                {
                    itemXVal = 0;
                }
                if (!Decimal.TryParse(itemY.SubItems[Column].Text, out itemYVal))
                {
                    itemYVal = 0;
                }

                return Decimal.Compare(itemXVal, itemYVal);
            }
            else
            {
                string itemXText = itemX.SubItems[Column].Text;
                string itemYText = itemY.SubItems[Column].Text;

                return String.Compare(itemXText, itemYText);
            }
        }
    }
}