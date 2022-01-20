using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ScanNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

            /*         int i = 200;
                     string txtIP = siticoneTextBox1.Text;
                     IPAddress iPAddress = IPAddress.Parse("192.168.5.200");
                     IPHostEntry iPHostEntry = Dns.GetHostEntry(iPAddress);
                     var x = iPHostEntry.AddressList;
                     MessageBox.Show("" + x);
                     MessageBox.Show("اكتملت عملية البحث" + iPAddress + "  :   " + iPHostEntry.HostName.ToString());*/

            siticoneDataGridView1.Rows.Clear();
            try
            {
                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            Ping ping;
            IPAddress iPAddress;
            PingReply pingReply;
            IPHostEntry iPHostEntry;
            string name;
            string txtIP = siticoneTextBox1.Text;

            
                Parallel.For(0, 256, (i, LoopState) =>
                {
                    ping = new Ping();
                    pingReply = ping.Send(siticoneTextBox1.Text + i.ToString());
                    this.BeginInvoke((Action)delegate ()
                    {
                        if (pingReply.Status == IPStatus.Success)
                        {
                            try
                            {
                                iPAddress = IPAddress.Parse(txtIP + i.ToString());
                                iPHostEntry = Dns.GetHostEntry(iPAddress);
                                name = iPHostEntry.HostName;
                                siticoneDataGridView1.Rows.Add(siticoneTextBox1.Text + i.ToString(), name, "Active");
                            }
                            catch (Exception ex)
                            {
                                name = "?";
                                siticoneDataGridView1.Rows.Add(siticoneTextBox1.Text + i.ToString(), name, "Active");
                                MessageBox.Show(ex.Message); 
                            }
                        }
                    });
                });
            
            MessageBox.Show("اكتملت عملية البحث");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
