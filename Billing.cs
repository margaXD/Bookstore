using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            populate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int n = 0;
            //if()
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(BillGrid);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = UsrName.Text;
            newRow.Cells[2].Value = PriceTb.Text;
            BillGrid.Rows.Add(newRow);
            n++;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int key = 0;
        private void BillGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsrName.Text = BookGrid.SelectedRows[0].Cells[1].Value.ToString();
            //Quan.Text = BillGrid.SelectedRows[0].Cells[4].Value.ToString();
            //ClientNameTb.Text = BillGrid.SelectedRows[0].Cells[2].Value.ToString();
            
            PriceTb.Text = BookGrid.SelectedRows[0].Cells[4].Value.ToString();
            if (UsrName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            UsrName.Text = "";
            PriceTb.Text = "";
            ClientNameTb.Text = "";

        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ClientNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 

            if (ClientNameTb.Text == "" || UsrName.Text == "")
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                try
                {
                    Con.Open();
                    string query = "insert into BillTable values('" + UsrName.Text + "','" + ClientNameTb.Text + "','" + tottal + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sąskaita išsaugota");
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
        int prodprice, tottal, pos = 60;

        private void BillGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Books log = new Books();
            log.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Users log = new Users();
            log.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DashBoardSkydelis log = new DashBoardSkydelis();
            log.Show();
            this.Hide();
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Jono ir Ugniaus Biblioteka", new Font("Comic Sans", 12, FontStyle.Bold), Brushes.DarkRed, new Point(70));
            e.Graphics.DrawString("ID KNYGA                   KAINA", new Font("Comic Sans", 10, FontStyle.Bold), Brushes.DarkRed, new Point(26, 40));
            foreach(DataGridViewRow row in BillGrid.Rows)
            {
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                tottal = tottal + prodprice;
                e.Graphics.DrawString("" + prodname, new Font("Comic Sans", 8, FontStyle.Bold), Brushes.YellowGreen, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Comic Sans", 8, FontStyle.Bold), Brushes.YellowGreen, new Point(180, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Iš Viso: " + tottal, new Font("Comic Sans", 12, FontStyle.Bold), Brushes.Black, new Point(60, pos));
            BillGrid.Rows.Clear();
            BillGrid.Refresh();
            pos = 100;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
