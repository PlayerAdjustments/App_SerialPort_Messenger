using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Security.Policy;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using App_SerialPort_Messenger.bin.Debug.Logs;
using System.IO.Ports;

namespace App_SerialPort_Messenger
{
    public partial class Main_Dashboard : MaterialForm
    {
        private SerialPort serialPort;

        public Main_Dashboard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500, Accent.Pink400, TextShade.WHITE);

        }

        private void Main_Dashboard_Load(object sender, EventArgs e)
        {

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("../Poppins/Poppins-Regular.ttf");

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], c.Font.Size, c.Font.Style);
            }

            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
            serialPort.PortName = "COM5";
            serialPort.Open();
            Message_Receiver_manager messageManager = new Message_Receiver_manager(serialPort);

        }

        private void UsersList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtBox_Message_Click(object sender, EventArgs e)
        {

        }
    }
}
