using System;

using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;


namespace RGB_Controller
{
    public partial class RB : Form
    {
        bool isConnected = false;
        SerialPort port;

        private Color defaultColor = Color.FromArgb(0, 0, 0);
        public RB()
        {
            InitializeComponent();
            String[] ports = SerialPort.GetPortNames();

            foreach (String port in ports)
            {
                comboBox1.Items.Add(port);
            }
        }


        private void connect()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            this.SetColor(defaultColor);
            button2.Text = "DISCONNECT";
            

        }

        private void disconnect()
        {
            isConnected = false;
            this.SetColor(defaultColor);
            port.Close();
            button2.Text = "CONNECT";
            

        }

        private void SetColor(Color color)
        {
            
            panel1.BackColor = color;

          
            port.Write(new[] { color.R, color.G, color.B }, 0, 3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                SetColor(color);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connect();
            }
            else
            {
                disconnect();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
