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
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;

namespace App_SerialPort_Messenger
{
    public partial class SetupForms : MaterialForm
    {

        public enum AvailableUsers
        {
            Alpha = 0,
            Beta = 1,
            Mu = 2,
            Xi = 3,
            Pi = 4,
            Omega = 5,
        };


        public class Msg
        {
            public string from;
            public string to;
            public string timestamp;
            public string contents;

            public Msg(string _from, string _to, string _timestamp, string _contents)
            {
                this.from = _from;
                this.to = _to;
                this.timestamp = _timestamp;
                this.contents = _contents;
            }
        }

        public class User
        {
            public uint nodeID;
            public string name;
            public List<Msg> Logs;
            public string json_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "currentUser.json");

            public string COM_Port;

            public User()
            {

            }

            public User(uint _nodeID,  string _name)
            {
                this.nodeID = _nodeID;
                this.name = _name;
                this.Logs = new List<Msg>();
            }
        }

        public SetupForms()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500, Accent.Pink400, TextShade.WHITE);

            LoadAvailablePorts();
        }

        private void LoadAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            SelectCOM.Items.Clear();
            foreach (string port in ports)
            {
                SelectCOM.Items.Add(port);
            }
        }

        private void SetupForms_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Setup_Alpha_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint) AvailableUsers.Alpha, "Alpha");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void Btn_Setup_Beta_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint)AvailableUsers.Beta, "Beta");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void Btn_Setup_Mu_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint)AvailableUsers.Mu, "Mu");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void Btn_Setup_Xi_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint)AvailableUsers.Xi, "Xi");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void Btn_Setup_Pi_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint)AvailableUsers.Pi, "Pi");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void Btn_Setup_Omega_Click(object sender, EventArgs e)
        {
            var currentUser = new User((uint)AvailableUsers.Omega, "Omega");
            currentUser.COM_Port = SelectCOM.GetItemText(this.SelectCOM.SelectedItem);

            string json = JsonConvert.SerializeObject(currentUser);
            File.WriteAllText(currentUser.json_path, json);

            onSelectedUser(currentUser);
        }

        private void SelectCOM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SelectCOM.SelectedItem != null)
            {
                UsersChooseList.Enabled = true;
            }
            else
            {
                UsersChooseList.Enabled = false;
            }
        }

        private void onSelectedUser(User u)
        {
            Main_Dashboard m = new Main_Dashboard();
            m.Show();
            this.Hide();
        }

    }
}
