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

namespace Income_And_Expense_Tracking_System
{
    public partial class viewExpense : Form
    {
        public viewExpense()
        {
            InitializeComponent();
            DispalyExpenses();  
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Desktop\.NET FRAMEWORK\Income-And-Expense-management-system\database\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DispalyExpenses()
        {
            Con.Open();
           // string Query = "Select * from ExpenseTbl where ExpUser='\" + Login.User + \"'\", Con ';
            SqlDataAdapter sda = new SqlDataAdapter("select * from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void dashboardLbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void incomeLbl_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void ExpenseLbl_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();
        }

        private void ViewIncomeLbl_Click(object sender, EventArgs e)
        {
            ViewIncome Obj = new ViewIncome();
            Obj.Show();
            this.Hide();
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "select * from ExpenseTbl where ExpUser='" + Login.User + "' AND  ExpCat='" + ExpName.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }
    }
}
