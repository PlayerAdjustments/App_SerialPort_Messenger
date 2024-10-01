using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_SerialPort_Messenger
{
    public partial class Inicio_sesion : Form
    {
        private string selected_item;
        public Inicio_sesion()
        {
            InitializeComponent();
            list_users();
        }

        private void Inicio_sesion_Load(object sender, EventArgs e)
        {

        }

        private void list_users()
        {
            List<string> users = new List<string>() { "alpha", "beta", "mu", "xi", "pi", "omega" };
            foreach (string user in users)
            {
                listBox1.Items.Add(user);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_entrar.Enabled = true;
            selected_item = listBox1.SelectedItem.ToString();
        }

        private void Btn_entrar_Click(object sender, EventArgs e)
        {
            Form dashboard = new Main_Dashboard(selected_item);
            dashboard.Show();
            this.Hide();
        }
    }
}
