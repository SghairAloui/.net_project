using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Mapharmacyy
{
    public partial class connection : Form
    {
        public connection()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aloui\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(NomUt.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("Entrer un nom d'utilisateur et un Mot De Pass ");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from AgentTbl  where AgNom='" + NomUt.Text + "' and AgPass ='" + Pass.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Medicaments Med = new Medicaments();
                    Med.Show();
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Mot De Pass Incorrect");
                }
                con.Close();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

            AdminLogin Log = new AdminLogin();
            Log.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connection_Load(object sender, EventArgs e)
        {

        }
    }
}
