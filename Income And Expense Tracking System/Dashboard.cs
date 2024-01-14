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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();  
            GetNumExp();
            GetNumInc();
            GetIncDate();
            GetExpDate();
            GetMaxInc();
            GetMaxExp();
            GetMinInc();
            GetMinExp();
            GetBalance();
            GetMaxExpCat();
            GetMaxIncCat();


        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");

        int Inc, Exp;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void IncLbl_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void ViewExpLbl_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }
        private void GetTotInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='"+Login.User+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            TotIncLbl.Text = "Rs "+dt.Rows[0][0].ToString();  
            Con.Close();
        }
        private void GetNumInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NumIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetIncDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateIncLbl.Text = dt.Rows[0][0].ToString();
            LastIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaxIncLbl.Text = "Rs "+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMinInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MinIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxIncCat()
        {
            Con.Open();
            string InnerQuery = "select Max(IncAmt) from IncomeTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);
            string Query = "select IncCat from IncomeTbl where IncAmt='" + dt1.Rows[0][0].ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BestIncCatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetTotExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
            TotExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetNumExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NumExpLbl.Text =dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetExpDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateExpLbl.Text = dt.Rows[0][0].ToString();
            LastExpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaxExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMinExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MinExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxExpCat()
        {
            Con.Open();
            string InnerQuery = "select Max(ExpAmt) from ExpenseTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);
            string Query = "select ExpCat from ExpenseTbl where ExpAmt='" + dt1.Rows[0][0].ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BestExpCatLbl.Text =dt.Rows[0][0].ToString();
            Con.Close();
        }



        private void GetBalance()
        {
            double Bal = Inc - Exp;
            BalanceLbl.Text = "Rs "+ Bal;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void DateIncLbl_Click(object sender, EventArgs e)
        {

        }

        private void NumIncLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
