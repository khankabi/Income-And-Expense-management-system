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
using System.Text.RegularExpressions;

namespace Income_And_Expense_Tracking_System
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Desktop\.NET FRAMEWORK\Income-And-Expense-management-system\database\IETSDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
        }
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
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsUserNameAllowed(UnameTb.Text))
            {
                MessageBox.Show("UserName is Not Allowed, It must start with letter and may ends with number or letter no special character is allowed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnameTb.Text = "";
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(UName,UDob,UPhone,UPass,UAddress)values(@UN,@UD,@UP,@UPA,@UA)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UD", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UA", AddressTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added !!!", "welcome");
                    Con.Close();
                    Clear();

                }catch(Exception Ex) 
                {
                    MessageBox.Show(Ex.Message); 

                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
    }
}
