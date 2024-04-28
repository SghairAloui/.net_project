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
    public partial class Factures : Form
    {
        public Factures()
        {
            InitializeComponent();
            RemplirAg();
            afficher();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aloui\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");


        private void RemplirAg()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select AgNum from AgentTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AgNum", typeof(int));
            dt.Load(Rdr);
            AgCb.ValueMember = "AgNum";
            AgCb.DataSource = dt;

            con.Close();
        }

        private void Reinitialiser()
        {
            MtTb.Text = "";
            AgCb.Text = "";
            //Cel = 0;
        }
        private void afficher()
        {
            con.Open();
            String Req = "select * from FactureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FactsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NomTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MtTb.Text == "" ||  AgCb.SelectedIndex == -1)
            {
                MessageBox.Show("Completez les information s'il vous plait");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "insert into FactureTbl values(" + AgCb.SelectedValue.ToString() + ",'" + ExpDate.Value.Date + "','" + MtTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Facture ajouter avec success");

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
        int Cel = 0;
        private void FactsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MtTb.Text = FactsDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgCb.SelectedValue = FactsDGV.SelectedRows[0].Cells[1].Value.ToString();
            ExpDate.Text = FactsDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (MtTb.Text == "")
                Cel = 0;
            else
                Cel = Convert.ToInt32(FactsDGV.SelectedRows[0].Cells[0].Value.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cel == 0)
            {
                MessageBox.Show("Sélectionnez la facture a éffacer");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "delete from FactureTbl where FactNum=" + Cel + "";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Facture Supprimer avec success");

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

        private void label5_Click_1(object sender, EventArgs e)
        {
            Agentscs Ag = new Agentscs();
            Ag.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Fabricants Fab = new Fabricants();
            Fab.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.Show();
            this.Hide();
        }
    }
 
}
