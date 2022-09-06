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
namespace Library
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Margar\Documents\LibraryDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from BookTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookGrid.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filter()
        {
            Con.Open();
            string query = "select * from BookTable where BCat='"+CSearchList.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookGrid.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveB_Click(object sender, EventArgs e)
        {
            if(BTitleT.Text=="" || ATableT.Text =="" || PTableT.Text =="" || CTableT.SelectedIndex == -1)
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BookTable values('" + BTitleT.Text + "','" + ATableT.Text + "','" + CTableT.SelectedItem.ToString() + "'," + PTableT.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Knyga išsaugota");
                    Con.Close();
                    populate();
                    Reset();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void CSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void RefreshB_Click(object sender, EventArgs e)
        {
            populate();
            CSearchList.SelectedIndex = -1;
        }
        private void Reset()
        {
            BTitleT.Text = "";
            ATableT.Text = "";
            CTableT.SelectedIndex = -1;
            PTableT.Text = "";
        }
        private void ResetB_Click(object sender, EventArgs e)
        {
            Reset();
        }
        int key = 0;
        private void BookGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleT.Text = BookGrid.SelectedRows[0].Cells[1].Value.ToString();
            ATableT.Text = BookGrid.SelectedRows[0].Cells[2].Value.ToString();
            CTableT.SelectedItem = BookGrid.SelectedRows[0].Cells[3].Value.ToString();
            PTableT.Text = BookGrid.SelectedRows[0].Cells[4].Value.ToString();
            if(BTitleT.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteB_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from BookTable where BId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Knyga panaikinta");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditB_Click(object sender, EventArgs e)
        {
            if (BTitleT.Text == "" || ATableT.Text == "" || PTableT.Text == "" || CTableT.SelectedIndex == -1)
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BookTable set BTitle='"+BTitleT.Text+"',BAuthor='"+ATableT.Text+"',BCat='"+CTableT.SelectedItem.ToString()+"',BPrice="+PTableT.Text+" where BId="+key+"";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Knygos informacija pakeista");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void Books_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Users log = new Users();
            log.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Billing log = new Billing();
            log.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DashBoardSkydelis log = new DashBoardSkydelis();
            log.Show();
            this.Hide();
        }
    }
}
