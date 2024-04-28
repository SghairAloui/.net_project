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
    public partial class Fabricants : Form
    {
        public Fabricants()
        {
            InitializeComponent();
            afficher();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aloui\Documents\Mapharmacie.mdf;Integrated Security=True;Connect Timeout=30");

        private void Reinitialiser()
        {
            NomTb.Text = "";
            AddTb.Text = "";
            DescTb.Text = "";
            TelTb.Text = "";
            Cel = 0;
        }
        private void afficher()
        {
                con.Open();
                String Req = "select * from FabricantTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Req, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FabricantsDGV.DataSource = ds.Tables[0];
                con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || AddTb.Text == "" || DescTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Completez les information s'il vous plait");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "insert into FabricantTbl values('" + NomTb.Text + "','" + AddTb.Text + "','" + DescTb.Text + "','" + TelTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant ajouter avec success");
                    
                    con.Close();
                    afficher();
                    Reinitialiser();
                }
                catch(Exception Ex)
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

        private void FabricantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = FabricantsDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddTb.Text = FabricantsDGV.SelectedRows[0].Cells[2].Value.ToString();
            DescTb.Text = FabricantsDGV.SelectedRows[0].Cells[3].Value.ToString();
            TelTb.Text = FabricantsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (NomTb.Text == "")
                Cel = 0;
            else
                Cel = Convert.ToInt32(FabricantsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cel == 0)
            {
                MessageBox.Show("Sélectionnez le Fabricant a éffacer");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "delete from FabricantTbl where FabNum="+Cel+"";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant Supprimer avec success");
                    
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
            if (NomTb.Text == "" || AddTb.Text == "" || DescTb.Text == "" || TelTb.Text == "")
            {
                MessageBox.Show("Informations manquantes");
            }
            else
            {
                try
                {
                    con.Open();
                    String Req = "update FabricantTbl set FabNom ='"+NomTb.Text+"' , FabAd ='" + AddTb.Text+ "' ,FabDescr ='" + DescTb.Text + "',FabTel ='" + TelTb.Text + "' where FabNum="+Cel+";";
                    SqlCommand cmd = new SqlCommand(Req, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant Modifier avec success");

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
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();
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
    }
}
