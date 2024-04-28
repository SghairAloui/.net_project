using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapharmacyy
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Pass.Text=="")
            {
                MessageBox.Show("Entrer le mot de passe administateur");
            }
            else if(Pass.Text == "Admin")
            {
                Dashbord Da = new Dashbord();
                Da.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contacter l'administrateur");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
