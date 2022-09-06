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
    public partial class DashBoardSkydelis : Form
    {
        public DashBoardSkydelis()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Margar\Documents\LibraryDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void BookStock_Click(object sender, EventArgs e)
        {

        }

        private void DashBoardSkydelis_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTable", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            UserStock.Text = dt.Rows[0][0].ToString(); // ČIA YRA KINTAMASIS KURIS SAUGO VARTOTOJU SKAICIU
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from BookTable", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            BookStock.Text = dt2.Rows[0][0].ToString(); // ČIA YRA KINTAMASIS KURIS SAUGO KNYGU SKAICIU
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from BillTable", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            BillStock.Text = dt3.Rows[0][0].ToString(); // ČIA YRA KINTAMASIS KURIS SAUGO PIRKIMU SKAICIU
            Con.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void label9_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Billing log = new Billing();
            log.Show();
            this.Hide();
        }
    }
}
