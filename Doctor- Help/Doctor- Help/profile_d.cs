using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Doctor__Help
{
    public partial class profile_d : Form
    {
        string n;
        public profile_d(string name)
        {
            n = name;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new pers_details_d(n);
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new login();
            f.Show();
            this.Hide();
        }

        private void profile_d_Load(object sender, EventArgs e)
        {
            label2.Text ="Dr."+ n;
        }
    }
}
