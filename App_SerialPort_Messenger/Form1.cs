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

namespace App_SerialPort_Messenger
{
    public partial class Main_Dashboard : MaterialForm
    {

        public Main_Dashboard(string you)
        {
            InitializeComponent();
            EnableYou(you);
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

        }

        private void UsersList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnableYou(string you)
        {
            Dictionary<string, Button> botones = new Dictionary<string, Button>()
            {
                { "alpha", Btn_ContactUser_Alpha}, {"beta", Btn_ContactUser_Beta}, 
                {"mu", Btn_ContactUser_Mu }, {"xi", Btn_ContactUser_Xi}, {"pi", Btn_ContactUser_Pi}, 
                {"omega", Btn_ContactUser_Omega}
            };

            botones[you].Enabled = false;
        }
    }
}
