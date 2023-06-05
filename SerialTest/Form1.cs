using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialTest
{
    public partial class Form1 : Form
    {
        private bool commStart = false;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (commStart == false)
            {
                serialPort1.BaudRate = 115200;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.PortName = "COM3";
                try
                {
                    serialPort1.Open();
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();

                    commStart = true;
                    button1.Text = "通信停止";
                }
                catch (Exception)
                {
                    MessageBox.Show("COMポートが使用できません！");
                    //                    throw;
                    return;
                }
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Close();

                commStart = false;
                button1.Text = "通信開始";

                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (commStart == true)
                serialPort1.Write("L");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (commStart == true)
                serialPort1.Write("B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (commStart == true)
                serialPort1.Write("D");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (commStart == true)
                serialPort1.Close();

            this.Close();
        }
    }
}
