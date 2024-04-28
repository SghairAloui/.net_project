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
    public partial class Agentscs : Form
    {
        public Agentscs()
        {
            InitializeComponent();
            afficher();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aloui\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void Reinitialiser()
        {
            NomTb.Text = "";
            
            TelTb.Text = "";
            PassTb.Text = "";
            GenreCb.SelectedIndex = -1;
            //Cel = 0;
        }
        private void afficher()
        {
            con.Open();
            String Req = "select * from AgentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || GenreCb.SelectedIndex == -1 || PassTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Completez les information s'il vous plait");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "insert into AgentTbl values('" + NomTb.Text + "','" + DDNdate.Value.Date + "','" + TelTb.Text + "','" + GenreCb.SelectedItem.ToString() + "','" + PassTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent ajouter avec success");

                    con.Close();
                    afficher();
                    Reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reinitialiser();
        }

        int Cel = 0;
        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DDNdate.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            TelTb.Text = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenreCb.SelectedItem = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PassTb.Text = AgentsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (NomTb.Text == "")
                Cel = 0;
            else
                Cel = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cel == 0)
            {
                MessageBox.Show("Sélectionnez l'agent a éffacer");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "delete from AgentTbl where AgNum=" + Cel + "";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Supprimer avec success");

                    con.Close();
                    afficher();
                    Reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || GenreCb.SelectedIndex == -1 || PassTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Informations manquantes");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "update AgentTbl set AgNom ='" + NomTb.Text + "' , AdDDn ='" + DDNdate.Value.Date + "' ,AgTel ='" + TelTb.Text + "',AgSex ='" + GenreCb.SelectedItem.ToString() + "', AgPass ='" + PassTb.Text + "' where AgNum=" + Cel + ";";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Modifier avec success");

                    con.Close();
                    afficher();
                    Reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Factures Fact = new Factures();
            Fact.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Fabricants Fab = new Fabricants();
            Fab.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.Show();
            this.Hide();
        }
    }
}
