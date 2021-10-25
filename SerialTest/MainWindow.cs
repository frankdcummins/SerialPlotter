using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTest
{
    public partial class MainWindow : Form
    {
        // ============================================================================================================================= //

        #region MEMBERS

        const int nChannels = 6;
        const int nPoints = 1;
        public List<ushort> channel1Data = new List<ushort>(nPoints);
        public List<ushort> channel2Data = new List<ushort>(nPoints);
        public List<ushort> channel3Data = new List<ushort>(nPoints);
        public List<ushort> channel4Data = new List<ushort>(nPoints);
        public List<ushort> channel5Data = new List<ushort>(nPoints);
        public List<ushort> channel6Data = new List<ushort>(nPoints);

        #endregion

        // ----------------------------------------------------------------------------------------------------------------------------- //

        #region CONSTRUCTOR

        public MainWindow()
        {
            InitializeComponent();

            // Loop over points
            for (ushort i = 0; i < nPoints; i++)
            {
                channel1Data.Add(i);
                channel2Data.Add(i);
                channel3Data.Add(i);
                channel4Data.Add(i);
                channel5Data.Add(i);
                channel6Data.Add(i);

                chart.Series[0].Points.Add();
                chart.Series[1].Points.Add();
                chart.Series[2].Points.Add();
                chart.Series[3].Points.Add();
                chart.Series[4].Points.Add();
                chart.Series[5].Points.Add();
            }
        }

        #endregion

        // ----------------------------------------------------------------------------------------------------------------------------- //

        #region EVENT METHODS

        /// <summary>
        /// Event method to assign a port name to the serial port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comPort_comboBox.SelectedItem.ToString().StartsWith("COM"))
            {
                serialPort.PortName = comPort_comboBox.SelectedItem.ToString();
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //
        byte[] buffer = new byte[10];
        /// <summary>
        /// Event method to handle incoming serial data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int nBytes = serialPort.Read(buffer, 0, buffer.Length);

                if (nBytes == 10)
                {
                    foreach (byte item in buffer)
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine("$$$");

                    // Plot what is in the buffer
                    if (InvokeRequired)
                    {
                        BeginInvoke(new MethodInvoker(() => PlotData(buffer)));
                    }
                    else
                    {
                        PlotData(buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Method to plot the data
        /// </summary>
        public void PlotData (byte[] data)
        {
            // Unpack the packets into channel data
            int[] values = Unpack8bitTo12bit(data, nChannels);

            if (values.Length == nChannels)
            {
                for (int i = 0; i < nChannels; i++)
                {
                    chart.Series[i].Points[0].YValues[0] = values[i];
                }
                chart.Refresh();
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Event method to handle connect/disconnecting from serial port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connect_btn_Click(object sender, EventArgs e)
        {
            switch (connect_btn.Text)
            {
                case "Connect":

                    if (serialPort.PortName.StartsWith("COM") && serialPort.IsOpen == false)
                    {
                        serialPort.Open();

                        connect_btn.Text = "Disconnect";
                    }
                    else
                    {
                        MessageBox.Show("Please select a COM port from the pull-down menu", "Select Port");
                    }
                    break;

                case "Disconnect":

                    serialPort.Close();
                    connect_btn.Text = "Connect";

                    break;
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Event method to handle loading of available serial ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_comboBox_Click(object sender, EventArgs e)
        {
            comPort_comboBox.Items.Clear();
            comPort_comboBox.Items.AddRange(SerialPort.GetPortNames());
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// Method to unpack 8-bit packet into 12 bit values
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="outSize"></param>
        /// <returns></returns>
        private int[] Unpack8bitTo12bit(byte[] inputArray, int outSize)
        {
            int[] outputArray = new int[outSize];

            int bidx = outSize * 12 - 4;

            while(bidx >= 0)
            {
                int validx = (bidx / 12);
                int arridx = (bidx / 8);
                int shiftVal = (bidx % 8);

                outputArray[validx] |= ((inputArray[arridx] >> shiftVal) & 0x0F) << (bidx % 12);

                bidx -= 4;
            }

            return outputArray;
        }

        // ----------------------------------------------------------------------------------------------------------------------------- //

        #endregion

        // ============================================================================================================================= //


    }
}