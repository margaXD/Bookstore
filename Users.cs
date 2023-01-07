using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Library
{
    public class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }
        readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Margar\Documents\LibraryDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (UsrName.Text == "" || Phone.Text == "" || Address.Text == "" || Passwrd.Text == "")
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTable values(";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vartotojas išsaugotas");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            UserGrid.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            UsrName.Text = "";
            Phone.Text = "";
            Address.Text = "";
            Passwrd.Text = "";
        }
        int key;

        private void DeleteBtn_Click(object sender, EventArgs e)
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
                    string query = "delete from UserTable where UId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vartotojas panaikintas");
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

        private void UserGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            UsrName.Text = UserGrid.SelectedRows[0].Cells[1].Value.ToString();
            Phone.Text = UserGrid.SelectedRows[0].Cells[2].Value.ToString();
            Address.Text = UserGrid.SelectedRows[0].Cells[3].Value.ToString();
            Passwrd.Text = UserGrid.SelectedRows[0].Cells[4].Value.ToString();
            if (UsrName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UsrName.Text == "" || Phone.Text == "" || Address.Text == "" || Passwrd.Text == "")
            {
                MessageBox.Show("Trūksta informacijos");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTable set UName='" + UsrName.Text + "',UPhone='" + Phone.Text + "',UAdd='" + Address.Text + "',UPass=" + Passwrd.Text + " where UId=" + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vartotojo informacija pakeista");
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Books log = new Books();
            log.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Billing log = new Billing();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
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
