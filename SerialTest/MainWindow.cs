using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using SerialTest.Panels;

namespace SerialTest
{
    public partial class MainWindow : Form
    {
        // ============================================================================================================================= //

        #region MEMBERS

        const int nChannels = 6;

        #endregion

        // ----------------------------------------------------------------------------------------------------------------------------- //

        #region CONSTRUCTOR

        public MainWindow()
        {
            InitializeComponent();
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
    

        byte ComputeChecksum(byte[] packet)
        {
            sbyte checksum = 0;

            unchecked
            {
                for (int i = 0; i < packet.Length - 1; i++)
                {
                    checksum += (sbyte)packet[i];
                }
            }
            return (byte)(-checksum);
        }

        int downsample = 1;
        long samplecount = 0;

        /// Event method to handle incoming serial data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Read what is in the buffer
                int nBytes = serialPort.Read(buffer, 0, buffer.Length);

                // If the packet is valid from a good checksum
                if (ComputeChecksum(buffer) == buffer[9] && (samplecount % downsample == 0))
                {
                    // Unpack the packets into channel data
                    int[] values = Unpack8bitTo12bit(buffer, nChannels);

                    // Plot what is in the buffer
                    if (InvokeRequired)
                    {
                        BeginInvoke(new MethodInvoker(() => signalPlotter.PlotData(values)));
                    }
                    else
                    {
                        signalPlotter.PlotData(values);
                    }
                }

                // Flush what is in the buffer
                serialPort.DiscardInBuffer();

                // Increment samplecount
                samplecount++;

            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    default:
                        Console.WriteLine(ex.Message);
                        break;
                }
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