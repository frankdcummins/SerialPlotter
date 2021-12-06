
namespace SerialTest
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.main_splitContainer = new System.Windows.Forms.SplitContainer();
            this.connect_btn = new System.Windows.Forms.Button();
            this.comPort_comboBox = new System.Windows.Forms.ComboBox();
            this.signalPlotter = new SerialTest.Panels.SignalPlotter();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.main_splitContainer)).BeginInit();
            this.main_splitContainer.Panel1.SuspendLayout();
            this.main_splitContainer.Panel2.SuspendLayout();
            this.main_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_splitContainer
            // 
            this.main_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.main_splitContainer.Name = "main_splitContainer";
            this.main_splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // main_splitContainer.Panel1
            // 
            this.main_splitContainer.Panel1.Controls.Add(this.connect_btn);
            this.main_splitContainer.Panel1.Controls.Add(this.comPort_comboBox);
            // 
            // main_splitContainer.Panel2
            // 
            this.main_splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.main_splitContainer.Panel2.Controls.Add(this.signalPlotter);
            this.main_splitContainer.Size = new System.Drawing.Size(800, 450);
            this.main_splitContainer.SplitterDistance = 96;
            this.main_splitContainer.TabIndex = 0;
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(140, 13);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(121, 23);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // comPort_comboBox
            // 
            this.comPort_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPort_comboBox.FormattingEnabled = true;
            this.comPort_comboBox.Location = new System.Drawing.Point(13, 13);
            this.comPort_comboBox.Name = "comPort_comboBox";
            this.comPort_comboBox.Size = new System.Drawing.Size(121, 21);
            this.comPort_comboBox.TabIndex = 0;
            this.comPort_comboBox.SelectedIndexChanged += new System.EventHandler(this.comPort_comboBox_SelectedIndexChanged);
            this.comPort_comboBox.Click += new System.EventHandler(this.comPort_comboBox_Click);
            // 
            // signalPlotter
            // 
            this.signalPlotter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalPlotter.Location = new System.Drawing.Point(0, 0);
            this.signalPlotter.Name = "signalPlotter";
            this.signalPlotter.Size = new System.Drawing.Size(800, 350);
            this.signalPlotter.TabIndex = 0;
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 230400;
            this.serialPort.PortName = "COM6";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_splitContainer);
            this.Name = "MainWindow";
            this.Text = "Serial Test App";
            this.main_splitContainer.Panel1.ResumeLayout(false);
            this.main_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_splitContainer)).EndInit();
            this.main_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer main_splitContainer;
        private System.Windows.Forms.ComboBox comPort_comboBox;
        private System.Windows.Forms.Button connect_btn;
        private System.IO.Ports.SerialPort serialPort;
        private Panels.SignalPlotter signalPlotter;
    }
}

