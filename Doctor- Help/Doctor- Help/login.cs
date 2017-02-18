using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Doctor__Help
{
    public partial class login : Form
    {  OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public login()
        {
            InitializeComponent();
        }
        public void connect()
        {
            string oracledb = "Data Source=TP-L420;User ID=vaishali;Password=vaishali";
            con = new OracleConnection(oracledb);
            con.Open();
        }

        private void b_reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = " ";
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new Registration();
            f.Show();
            this.Hide();
        }

        private void b_submit_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text) / 1000;
            
            connect();
            cmd = new OracleCommand();
            if (x == 1)
            {
               
                cmd.CommandText = "select * from patient_pers";
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da = new OracleDataAdapter(cmd.CommandText, con);
                da.Fill(ds, "patient_pers");
                dt = ds.Tables["patient_pers"];
                int t = dt.Rows.Count;
               
                for (i = 0; i < t; i++)
                {
                    dr = dt.Rows[i];
                    if ((textBox1.Text == dr["patient_id"].ToString()) && (textBox2.Text == dr["password"].ToString()))
                    {

                        string a = dr["name"].ToString();
                        Form f = new profile_p(a);
                        f.Show();
                        this.Hide();
                        break;
                    }
                }
                if (i == t)
                {
                    label2.Visible = true;
                }
            }
            else if (x == 2)
            {
                cmd.CommandText = "select * from doc_pers";
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da = new OracleDataAdapter(cmd.CommandText, con);
                da.Fill(ds, "doc_pers");
                dt = ds.Tables["doc_pers"];
                int t = dt.Rows.Count;

                for (i = 0; i < t; i++)
                {
                    dr = dt.Rows[i];
                    if ((textBox1.Text == dr["doc_id"].ToString()) && (textBox2.Text == dr["password"].ToString()))
                    {

                        string a = dr["name"].ToString();
                        Form f = new profile_d(a);
                        f.Show();
                        this.Hide();
                        break;
                    }
                }
                if (i == t)
                {
                    label2.Visible = true;
                }
            }
            else label2.Visible = true;
        

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void lbl_user_name_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
