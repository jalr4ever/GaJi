using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Last_II
{
    public partial class ScoreOption : Form
    {
        public ScoreOption()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//位于屏幕中间
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //跳转会主界面
            new MainOption().Show();
            this.Hide();
        }

        private void ScoreOption_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //连接打开数据库的三步
            string connstring = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=D:\Project\C#Project\Last_II_15\Last_II\pl.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(connstring);

            conn.Open();

            
            //定义SQL语句
            string sql = "select * from so order by 分数 desc ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            //使用DataTable将数据库内容输出到窗体
            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //连接打开数据库的三步
            string connstring = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=D:\Project\C#Project\Last_II_15\Last_II\pl.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(connstring);

            conn.Open();

            //清空数据库的数据语句
            string sql = "truncate table [dbo].[so] ";


            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            new MainOption().Show();

            this.Hide();

        }

        private void ScoreOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
