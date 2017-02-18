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
    public partial class med_details_p : Form
    {
        string n;
        OracleConnection con;
        OracleDataAdapter da;
        OracleCommand cmd;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        int t;
        public med_details_p(string name)
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
        private void med_details_p_Load(object sender, EventArgs e)
        {
            label1.Text = n;
            connect();
            cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select prev_ailments,m.patient_id from patient_medical m,patient_pers p where m.patient_id=p.patient_id and p.name=" + "'" + n + "'";
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da = new OracleDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "patient_medical");
            dt = ds.Tables["patient_medical"];
             t = dt.Rows.Count;
           
            dr = dt.Rows[t - 1];
            richTextBox1.Text = dr["prev_ailments"].ToString();
            i=int.Parse(dr["patient_id"].ToString());
            con.Close();
        }

      
      private void button2_Click_1(object sender, EventArgs e)
      {
          Form f = new profile_p(n);
          f.Show();
          this.Hide();
      }

      private void button1_Click(object sender, EventArgs e)
      {
          richTextBox1.Enabled = true;
      }

      private void button3_Click(object sender, EventArgs e)
      {
          string ailments = richTextBox1.Text;

          connect();
          cmd = new OracleCommand();
          cmd.Connection = con;

          cmd.CommandText = "update patient_medical set prev_ailments=:pb1 where patient_id=:pdn";

          OracleParameter pa1 = new OracleParameter();
          pa1.ParameterName = "pb1";
          pa1.DbType = DbType.String;
          pa1.Value = ailments;

          OracleParameter pa = new OracleParameter();
          pa.ParameterName = "pdn";
          pa.DbType = DbType.String;
          pa.Value = i;

          cmd.Parameters.Add(pa1);
          cmd.Parameters.Add(pa);
          cmd.ExecuteNonQuery();
          MessageBox.Show("updated");

          con.Close();
        
          
        /*  else
          {
              cmd.CommandText = "insert into patient_medical values (:pb1,:pb2,:pb3)";
              cmd.CommandType = CommandType.Text;

              OracleParameter pa1 = new OracleParameter();
              pa1.ParameterName = "pb1";
              pa1.DbType = DbType.String;
              pa1.Value = i;

              OracleParameter pa2 = new OracleParameter();
              pa2.ParameterName = "pb2";
              pa2.DbType = DbType.String;
              pa2.Value = ailments;

              OracleParameter pa3 = new OracleParameter();
              pa3.ParameterName = "pb3";
              pa3.DbType = DbType.String;
              pa3.Value = 2001;




              cmd.Parameters.Add(pa1);
              cmd.Parameters.Add(pa2);
              cmd.Parameters.Add(pa3);

              cmd.ExecuteNonQuery();

              MessageBox.Show("updated");
          }*/

          con.Close();
      }

     
    }
}
