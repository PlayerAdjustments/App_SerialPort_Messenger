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
       
        List<Button> ContactUserBtns = new List<Button>();
        string CurrentUser = "Mu";
        string ChattingWith = null;

        public Main_Dashboard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500, Accent.Pink400, TextShade.WHITE);

            ContactUserBtns.AddRange(new List<Button> { Btn_ContactUser_Alpha, Btn_ContactUser_Beta, Btn_ContactUser_Mu, Btn_ContactUser_Xi, Btn_ContactUser_Pi, Btn_ContactUser_Omega });

            EnableChats(this.CurrentUser);

        }

        private void Main_Dashboard_Load(object sender, EventArgs e)
        {
            // Puts all fonts as Poppins variants.
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



        /// <summary>
        /// Changes the chat to the correspondent user. 
        /// 
        /// Reads and shows the log of messages related into each user.
        /// </summary>
        /// <param name="UserName"></param>
        private void Switch_Chatting_With(string UserName)
        {

            EnableChats(this.CurrentUser);

            // Changes the Btn_ChattingWith.Text, .Type, and .Enabled properties
            if (UserName == "None" || UserName == null)
            {
                Btn_Chatting_With.Text = $"Chatting with: None";
                Btn_Chatting_With.Enabled = false;
                Btn_Chatting_With.Type = MaterialButton.MaterialButtonType.Outlined;
            }
            else
            {
                Btn_Chatting_With.Text = $"Chatting with: {UserName}";
                Btn_Chatting_With.Enabled = true;
                Btn_Chatting_With.Type = MaterialButton.MaterialButtonType.Contained;

                this.ChattingWith = UserName;
            }

            string filePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Logs", $"Log_{UserName}.txt");

            // Clears the Chat_textbox and prints the lines from 
            Chat_TextBox.Clear();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (true)
                {
                    // Read each line from the file and print it
                    string line = sr.ReadLine();

                    if (line == null) break;

                    Chat_TextBox.AppendText(line + Environment.NewLine);
                }
            }

            TxtBox_Message.Enabled = true;
            Chat_TextBox.SelectionStart = Chat_TextBox.TextLength - 1;
            Chat_TextBox.ScrollToCaret();
        }

        /// <summary>
        /// Sets to enabled all buttons, except for the one where the text is equal to the CurrentUser variable.
        /// 
        /// CurrentUser beign the Node being used. For example: "Alpha"
        /// </summary>
        /// <param name="CurrentUser"></param>
        private void EnableChats(string CurrentUser)
        {
            foreach (MaterialButton b in this.ContactUserBtns)
            {
                b.UseAccentColor = false;
                if (b.Text != this.CurrentUser)
                {
                    b.Enabled = true;
                }
                else
                {
                    b.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Opens the logs, Formats the message in ">> [CurrentUser: DateTime.UtcNow] Message" style
        /// Writes to the logs, and appends the sent message to the chat textbox.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="AdressTo"></param>
        private void SendMessage(string Message, string AdressTo)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Logs", $"Log_{AdressTo}.txt");
            string formattedMsg = $">> [{this.CurrentUser}: {DateTime.UtcNow}] {Message}";

            using (StreamWriter sr = new StreamWriter(filePath, true))
            {
                sr.WriteLine(formattedMsg);
            }

            Chat_TextBox.AppendText(formattedMsg + Environment.NewLine);
            Chat_TextBox.SelectionStart = Chat_TextBox.TextLength - 1;
            Chat_TextBox.ScrollToCaret();
        }

        private void Btn_ContactUser_Alpha_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Alpha.Enabled = false;
            Switch_Chatting_With("Alpha");
            Btn_ContactUser_Alpha.UseAccentColor = true;
        }

        private void Btn_ContactUser_Beta_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Beta.Enabled = false;
            Switch_Chatting_With("Beta");
            Btn_ContactUser_Beta.UseAccentColor = true;
        }

        private void Btn_ContactUser_Mu_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Mu.Enabled = false;
            Switch_Chatting_With("Mu");
            Btn_ContactUser_Mu.UseAccentColor = true;
        }

        private void Btn_ContactUser_Xi_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Xi.Enabled = false;
            Switch_Chatting_With("Xi");
            Btn_ContactUser_Xi.UseAccentColor = true;
        }

        private void Btn_ContactUser_Pi_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Pi.Enabled = false;
            Switch_Chatting_With("Pi");
            Btn_ContactUser_Pi.UseAccentColor = true;
        }

        private void Btn_ContactUser_Omega_Click(object sender, EventArgs e)
        {
            Btn_ContactUser_Omega.Enabled = false;
            Switch_Chatting_With("Omega");
            Btn_ContactUser_Omega.UseAccentColor = true;

        }

        /// <summary>
        /// When Clicking the SendMsg Button, send a message if there is content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SendMsg_Click(object sender, EventArgs e)
        {
            // If the text doesn't contain a message, dont send it
            if (TxtBox_Message.Text.Trim().Length <= 0)
            {
                MessageBox.Show("You must enter a message in order to send the information");
                return;
            }

            // If we have something to send
            SendMessage(TxtBox_Message.Text.Trim(), this.ChattingWith);
        }
    }
}
