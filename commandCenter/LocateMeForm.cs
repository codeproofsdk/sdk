using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using commandCenter.GeocodeService;

namespace commandCenter
{
    public partial class LocateMeForm : Form
    {
        public string lacationInfo
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public LocateMeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ReverseGeocodePoint(lacationInfo);
        }

        private string ReverseGeocodePoint(string locationString)
        {
            string results = "";
            string key = "Am_qwaGQRh4tOT1wCX_lWd2EzqKl1_PuXjX9nuMQZFWehKYgcXqT99avIJhvAGmx";
            ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();

            // Set the credentials using a valid Bing Maps key
            reverseGeocodeRequest.Credentials = new GeocodeService.Credentials();
            reverseGeocodeRequest.Credentials.ApplicationId = key;

            // Set the point to use to find a matching address
            GeocodeService.Location point = new GeocodeService.Location();
            string[] digits = locationString.Split(',');

            if (digits.Length == 2 &&
                digits[0].Length > 0 && digits[1].Length > 0)
            {
                point.Latitude = double.Parse(digits[0].Trim());
                point.Longitude = double.Parse(digits[1].Trim());

                reverseGeocodeRequest.Location = point;

                // Make the reverse geocode request
                GeocodeServiceClient geocodeService = new GeocodeServiceClient();
                GeocodeResponse geocodeResponse = geocodeService.ReverseGeocode(reverseGeocodeRequest);

                if (geocodeResponse.Results.Length > 0)
                    results = geocodeResponse.Results[0].DisplayName;
                else
                    results = "Location data not available";

                return results;
            }
            else
            {
                return "Location data not available";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = lacationInfo;
        }

        private void LocateMeForm_Load(object sender, EventArgs e)
        {

        }

    }
}
