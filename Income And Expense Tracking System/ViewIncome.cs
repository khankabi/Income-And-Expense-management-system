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
    public partial class ViewIncome : Form
    {
        public ViewIncome()
        {
            InitializeComponent();
            DispalyIncomes();   
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void DispalyIncomes()
        {
            Con.Open();
            string Query = "Select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void IncLbl_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void ExpLbl_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();
        }

        private void ViewExpLbl_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }
    }
}
