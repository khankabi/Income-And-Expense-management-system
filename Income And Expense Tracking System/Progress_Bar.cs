using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Income_And_Expense_Tracking_System
{
    public partial class Progress_Bar : Form
    {
        public Progress_Bar()
        {
            InitializeComponent();
        }

        private void Progress_Bar_Load(object sender, EventArgs e)
        {
            timer1.Start();           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(3);
            label3.Text = progressBar1.Value.ToString()+" %";
            if(progressBar1.Value >= 100) 
            {
                timer1.Stop();
                Dashboard Obj = new Dashboard();
                this.Hide();
                Obj.Show();
            }
            
        }
    }
}
