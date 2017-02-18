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
    public partial class pers_details_p : Form
    {
        string n;
        OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public pers_details_p(string name)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pers_details_p_Load(object sender, EventArgs e)
        {
            label1.Text = n;
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from patient_pers where name="+"'"+n+"'";
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da = new OracleDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "patient_pers");
            dt = ds.Tables["patient_pers"];
            int t = dt.Rows.Count;
          
            dr = dt.Rows[t-1];
            textBox1.Text = dr["name"].ToString();
            textBox2.Text = dr["password"].ToString();
            textBox3.Text = dr["age"].ToString();
            textBox4.Text = dr["gender"].ToString();
            textBox5.Text = dr["mobile_no"].ToString();
            con.Close();
        }

      

       private void button2_Click(object sender, EventArgs e)
        {
            Form f = new profile_p(n);
            f.Show();
            this.Hide();
        }

       private void button1_Click(object sender, EventArgs e)
       {
           
           textBox2.Enabled = true;
           textBox3.Enabled = true;
           textBox4.Enabled = true;
           textBox5.Enabled = true;
       }

       private void button3_Click(object sender, EventArgs e)
       {
          
           string password = textBox2.Text;
           int age = int.Parse(textBox3.Text);
           string gender = textBox4.Text;
           Int64 mobile_no =  Int64.Parse(textBox5.Text);
          
           connect();
           cmd = new OracleCommand();
           cmd.Connection = con;

           cmd.CommandText = "update patient_pers set password=:pb1,age=:pb2,gender=:pb3,mobile_no=:pb4 where name=:pdn";
          
           OracleParameter pa1 = new OracleParameter();
           pa1.ParameterName = "pb1";
           pa1.DbType = DbType.String;
           pa1.Value = password;

           OracleParameter pa2 = new OracleParameter();
           pa2.ParameterName = "pb2";
           pa2.DbType = DbType.Int16;
           pa2.Value = age;

           OracleParameter pa3 = new OracleParameter();
           pa3.ParameterName = "pb3";
           pa3.DbType = DbType.String;
           pa3.Value = gender;

           OracleParameter pa4 = new OracleParameter();
           pa4.ParameterName = "pb4";
           pa4.DbType = DbType.Int64;
           pa4.Value = mobile_no;


           OracleParameter pa = new OracleParameter();
           pa.ParameterName = "pdn";
           pa.DbType = DbType.String;
           pa.Value = n;

           cmd.Parameters.Add(pa1);
           cmd.Parameters.Add(pa2);
           cmd.Parameters.Add(pa3);
           cmd.Parameters.Add(pa4);
           cmd.Parameters.Add(pa);
           cmd.ExecuteNonQuery();
           MessageBox.Show("updated");
           con.Close();

       }
    }
}
