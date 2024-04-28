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
    public partial class Medicaments : Form
    {
        public Medicaments()
        {
            InitializeComponent();
            RemplirFab();
            afficher();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aloui\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void RemplirFab()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select FabNum from FabricantTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("FabNum", typeof(int));
            dt.Load(Rdr);
            FabCb.ValueMember = "FabNum";
            FabCb.DataSource = dt;

            con.Close();
        }

        private void Reinitialiser()
        {
            NomTb.Text = "";
            prixTb.Text = "";
            QtTb.Text = "";
            FabCb.Text = "";
            Cel = 0;
        }
        private void afficher()
        {
            con.Open();
            String Req = "select * from MedicamentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FacCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || prixTb.Text == "" || QtTb.Text == "" || FabCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Completez les information s'il vous plait");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "insert into MedicamentTbl values('" + NomTb.Text + "'," + prixTb.Text + "," + QtTb.Text + "," + FabCb.SelectedValue.ToString() + ", '"+ExpDate.Value.Date+"')";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicaments ajouter avec success");

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

        private void label3_Click(object sender, EventArgs e)
        {
            Fabricants Fab = new Fabricants();
            Fab.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reinitialiser();
        }

        int Cel = 0;
        private void MedsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = MedsDGV.SelectedRows[0].Cells[1].Value.ToString();
            prixTb.Text = MedsDGV.SelectedRows[0].Cells[2].Value.ToString();
            QtTb.Text = MedsDGV.SelectedRows[0].Cells[3].Value.ToString();
            FabCb.SelectedValue = MedsDGV.SelectedRows[0].Cells[4].Value.ToString();
            ExpDate.Text = MedsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (NomTb.Text == "")
                Cel = 0;
            else
                Cel = Convert.ToInt32(MedsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cel == 0)
            {
                MessageBox.Show("Sélectionnez le Medicament a éffacer");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "delete from MedicamentTbl where MedNum=" + Cel + "";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicament Supprimer avec success");

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
            if (NomTb.Text == "" || prixTb.Text == "" || QtTb.Text == "" || FabCb.SelectedIndex ==-1 )
            {
                MessageBox.Show("Informations manquantes");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "update MedicamentTbl set MedNom ='" + NomTb.Text + "' , MedPrix =" + prixTb.Text + " ,MedQte =" + QtTb.Text + ",MedFab =" + FabCb.SelectedValue.ToString() + ", MedExp ='"+ExpDate.Value.Date +"' where MedNum=" + Cel + ";";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicament Modifier avec success");

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

        private void label4_Click(object sender, EventArgs e)
        {
            Factures Fact = new Factures();
            Fact.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NomTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
