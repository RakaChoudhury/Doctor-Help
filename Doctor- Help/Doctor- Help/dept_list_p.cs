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
    public partial class dept_list_p : Form
    {
        string n;
        OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
       // int i = 0;
        public dept_list_p(string name)
        {
            n = name;
            InitializeComponent();
        }
        public void connect()
        {
            string oracledb = "Data Source=TP-L420;User ID=vaishali;Password=vaishali";
            con = new OracleConnection(oracledb);
            con.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            linkLabel3.Visible = false;
            linkLabel4.Visible = false;

            

            string a = comboBox1.SelectedItem.ToString();
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select name from doc_prof pf,doc_pers ps where pf.doc_id=ps.doc_id and department=" + "'" + a + "'";
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da = new OracleDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "patient_pers");
            dt = ds.Tables["patient_pers"];
            int t = dt.Rows.Count;
            switch (t)
            {
                 case 4:
                        linkLabel1.Visible = true;
                        dr = dt.Rows[t-1];
                        linkLabel1.Text = dr["name"].ToString();
                        
                        linkLabel2.Visible = true;
                        dr = dt.Rows[t-2];
                        linkLabel2.Text = dr["name"].ToString();
                       
                        linkLabel3.Visible = true;
                        dr = dt.Rows[t-3];
                        linkLabel3.Text = dr["name"].ToString();
                       
                        linkLabel4.Visible = true;
                        dr = dt.Rows[t-4];
                        linkLabel4.Text = dr["name"].ToString();
                        break;
                    

                case 3:
                         linkLabel1.Visible = true;
                        dr = dt.Rows[t-1];
                        linkLabel1.Text = dr["name"].ToString();
                       
                        linkLabel2.Visible = true;
                        dr = dt.Rows[t-2];
                        linkLabel2.Text = dr["name"].ToString();
                        
                        linkLabel3.Visible = true;
                        dr = dt.Rows[t-3];
                        linkLabel3.Text = dr["name"].ToString();
                        break;
                    

                case 2:
                         linkLabel1.Visible = true;
                        dr = dt.Rows[t-1];
                        linkLabel1.Text = dr["name"].ToString();
                       
                        linkLabel2.Visible = true;
                        dr = dt.Rows[t-2];
                        linkLabel2.Text = dr["name"].ToString();
                        break;
                    

                case 1:
                    
                        linkLabel1.Visible = true;
                        dr = dt.Rows[t-1];
                        linkLabel1.Text = dr["name"].ToString();
                        break;
                    }
            



            }
        

        private void dept_list_p_Load(object sender, EventArgs e)
        {
            label1 .Text =n;
        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string a1 = linkLabel1.Text;
            Form f = new doc_details(n,a1);
            f.Show();
            this.Hide();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string a1 = linkLabel2.Text;
            Form f = new doc_details(n, a1);
            f.Show();
            this.Hide();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string a1 = linkLabel3.Text;
            Form f = new doc_details(n, a1);
            f.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string a1 = linkLabel4.Text;
            Form f = new doc_details(n, a1);
            f.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form f = new profile_p(n);
            f.Show();
            this.Hide();
        }

       
    }
}
