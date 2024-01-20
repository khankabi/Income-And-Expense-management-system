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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;


namespace Income_And_Expense_Tracking_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
           

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string User;
        /// <summary>
        /// Determines whether the username meets conditions.
        /// Username conditions:
        /// Must be 1 to 24 character in length
        /// Must start with letter a-zA-Z
        /// May contain letters, numbers or '.','-' or '_'
        /// Must not end in '.','-','._' or '-_' 
        /// </summary>
        /// <param name="userName">proposed username</param>
        /// <returns>True if the username is valid</returns>
        private static Regex sUserNameAllowedRegEx = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9\._\-]{0,23}[^.-]$", RegexOptions.Compiled);
        private static Regex sUserNameIllegalEndingRegEx = new Regex(@"(\.|\-|\._|\-_)$", RegexOptions.Compiled);
        public static bool IsUserNameAllowed(string userName)
        {
            if (string.IsNullOrEmpty(userName)
                || !sUserNameAllowedRegEx.IsMatch(userName)
                || sUserNameIllegalEndingRegEx.IsMatch(userName))

            {
                return false;
            }
            return true;
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text==""||PasswordTb.Text=="")
            {
                MessageBox.Show("Enter both username and password !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!IsUserNameAllowed(UnameTb.Text))
            {
                MessageBox.Show("Not allowed","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + UnameTb.Text + "' and UPass='" + PasswordTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UnameTb.Text;
                    //Dashboard Obj = new Dashboard();
                    Progress_Bar Obj = new Progress_Bar();
                    Obj.Show();
                    this.Hide();
                    //MessageBox.Show("Login Successful","WELCOME",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password !!!");
                    UnameTb.Text = "";
                    PasswordTb.Text = "";
                }
                Con.Close();
            }
            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                PasswordTb.UseSystemPasswordChar = true;
            }
            else
            {
                PasswordTb.UseSystemPasswordChar = false;
            }
            
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
