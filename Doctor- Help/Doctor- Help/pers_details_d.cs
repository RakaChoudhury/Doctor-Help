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
    public partial class pers_details_d : Form
    {
        string n;
     
        OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public pers_details_d(string name)
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pers_details_d_Load(object sender, EventArgs e)
        {
            label1.Text = n;
            
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from doc_prof pf,doc_pers ps where pf.doc_id=ps.doc_id and ps.name=" + "'" + n + "'";
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da = new OracleDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "patient_pers");
            dt = ds.Tables["patient_pers"];
            int t = dt.Rows.Count;

            dr = dt.Rows[0];
            textBox1.Text = dr["name"].ToString();
            textBox2.Text = dr["password"].ToString();
            textBox3.Text = dr["h_address"].ToString();
            textBox4.Text = dr["o_address"].ToString();
            textBox9.Text = dr["contact"].ToString();
          
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new profile_d(n);
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            textBox9.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string h_address = textBox3.Text;
            string o_address = textBox4.Text;
            Int64 contact = Int64.Parse(textBox9.Text);
           
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "update doc_pers set password=:pb1,h_address=:pb2,o_address=:pb3,contact=:pb4 where name=:pdn";

            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "pb1";
            pa1.DbType = DbType.String;
            pa1.Value = password;

            OracleParameter pa2 = new OracleParameter();
            pa2.ParameterName = "pb2";
            pa2.DbType = DbType.String;
            pa2.Value = h_address;

            OracleParameter pa3 = new OracleParameter();
            pa3.ParameterName = "pb3";
            pa3.DbType = DbType.String;
            pa3.Value = o_address;

           OracleParameter pa4 = new OracleParameter();
            pa4.ParameterName = "pb4";
            pa4.DbType = DbType.Int64;
            pa4.Value = contact;

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
