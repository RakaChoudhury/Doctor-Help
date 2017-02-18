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
    public partial class doc_details : Form
    {
        string n;
        string docName;
        OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public doc_details(string name,string dname)
        {
            n = name;
            docName = dname;
            InitializeComponent();
        }

        public void connect()
        {
            string oracledb = "Data Source=TP-L420;User ID=vaishali;Password=vaishali";
            con = new OracleConnection(oracledb);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new dept_list_p(n);
            f.Show();
            this.Hide();
        }

        private void doc_details_Load(object sender, EventArgs e)
        {
            label1.Text = n;
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from doc_prof pf,doc_pers ps where pf.doc_id=ps.doc_id and ps.name=" + "'" + docName+ "'";
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da = new OracleDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "patient_pers");
            dt = ds.Tables["patient_pers"];
            int t = dt.Rows.Count;
            
            dr = dt.Rows[0];
            textBox1.Text = dr["name"].ToString ();
            textBox3.Text = dr["h_address"].ToString();
            textBox4.Text = dr["o_address"].ToString();
            textBox5.Text = dr["department"].ToString();
            textBox6.Text = dr["grad_clg"].ToString();
            textBox7.Text = dr["degree"].ToString();
            textBox8.Text = dr["experience"].ToString();
            textBox9.Text = dr["contact"].ToString();
            con.Close();

          

        }
    }
}
