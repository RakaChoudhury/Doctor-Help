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
    public partial class Registration : Form
    {
        
       OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Registration()
        {
            InitializeComponent();
        }
       

        private void Registration_Load(object sender, EventArgs e)
        {

        }
        public void connect()
        {
            string oracledb = "Data Source=TP-L420;User ID=vaishali;Password=vaishali";
            con = new OracleConnection(oracledb);
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new login();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =" ";
            
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Int64 contact = Int64.Parse(textBox2.Text);
            string password = textBox3.Text;
            string repassword = textBox4.Text;
            if (password != repassword)
                MessageBox.Show("Password values do not match");
            else
            {
                string gender;
                if( radioButton1 .Checked==true )
                 gender="M";
            else  gender="F";
                int age=int.Parse (textBox5 .Text );
                
                connect();
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "select patient_id from patient_pers";
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da = new OracleDataAdapter(cmd.CommandText, con);
                da.Fill(ds, "patient_pers");
                dt = ds.Tables["patient_pers"];

                int t = dt.Rows.Count;
                dr = dt.Rows[t - 1];
               string patpers = (dr["patient_id"].ToString());
               int n1 = int.Parse(patpers) + 1;
              
               label11.Visible = true;
               label10.Visible = true;
               label11.Text = n1.ToString();

                cmd.CommandText = "insert into patient_pers values (:pa1,:pa2,:pa3,:pa4,:pa5,:pa6)";
                cmd.CommandType = CommandType.Text;

                OracleParameter p1 = new OracleParameter();
                p1.DbType = DbType.String;
                p1.ParameterName = "pa1";
                p1.Value = n1;


                OracleParameter p2 = new OracleParameter();
                p2.DbType = DbType.String;
                p2.ParameterName = "pa2";
                p2.Value = password;

                OracleParameter p3 = new OracleParameter();
                p3.DbType = DbType.String;
                p3.ParameterName = "pa3";
                p3.Value = name;


                OracleParameter p4 = new OracleParameter();
                p4.DbType = DbType.String;
                p4.ParameterName = "pa4";
                p4.Value = age;

                OracleParameter p5 = new OracleParameter();
                p5.DbType = DbType.String;
                p5.ParameterName = "pa5";
                p5.Value = gender;

                OracleParameter p6 = new OracleParameter();
                p6.DbType = DbType.String;
                p6.ParameterName = "pa6";
                p6.Value = contact;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);


                cmd.ExecuteNonQuery();

                MessageBox.Show("You have been registered. Your user id/username=" + n1.ToString());
                con.Close();
            }



        }
    }
}
