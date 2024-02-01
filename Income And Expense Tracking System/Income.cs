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
using System.Data.SqlClient;

namespace Income_And_Expense_Tracking_System
{
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
            GetTotInc();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Desktop\.NET FRAMEWORK\Income-And-Expense-management-system\database\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            IncNameTb.Text = "";
            IncAmtTb.Text = "";
            IncDescTb.Text = "";
            CatCb.SelectedIndex = 0;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IncNameTb.Text == "" || IncAmtTb.Text == "" || IncDescTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName,IncAmt,IncCat,IncDate,IncDesc,IncUser)values(@IN,@IA,@IC,@ID,@IDe,@IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", IncNameTb.Text);
                    cmd.Parameters.AddWithValue("@IA", IncAmtTb.Text);
                    cmd.Parameters.AddWithValue("@IC", CatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", IncDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDe", IncDescTb.Text);
                    cmd.Parameters.AddWithValue("@IU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Added !!!", "Great",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Con.Close();
                    GetTotInc();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExpLbl_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();
        }

        private void ViewIncLbl_Click(object sender, EventArgs e)
        {
            ViewIncome Obj = new ViewIncome();
            Obj.Show();
            this.Hide();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AddCatLbl.Text != "")
            {
                CatCb.Items.Add(AddCatLbl.Text);
                AddCatLbl.Text = "";
                CatCb.Sorted = true;    
            }
            else
            {
                MessageBox.Show("Missing Information,Please Enter Category", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveCatBtn_Click(object sender, EventArgs e)
        {
            if (AddCatLbl.Text != "")
            {
                CatCb.Items.Remove(AddCatLbl.Text);
                AddCatLbl.Text = "";
                CatCb.Sorted = true;
            }
            else
            {
                MessageBox.Show("Missing Information,Please Enter Category", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void GetTotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {
                Con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
