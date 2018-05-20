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
using Microsoft.VisualBasic;

namespace Last_II
{
    public partial class StartOption : Form
    {
        //全局变量随机数
        private static Random r = new Random();
     // private static int rr = new Random().Next(1, 3);
        public StartOption()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//使之位于屏幕中间
            InitializeStartGame();
        }
        
        private void InitializeStartGame()
        {
            Single.GetsingleObj().AddEntity(new Background(0, 0));//背景
            
           
            Single.GetsingleObj().AddEntity(new PlaneHero(800, 850, 7, 15, Variety.Hero));//本机
        }

        private void StartOption_Load(object sender, EventArgs e)
        {
            //设置双缓冲绘图
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void StartOption_Paint(object sender, PaintEventArgs e)
        {
            Single.GetsingleObj().Draw(e.Graphics);//绘制所有的内容

            string herolife = "玩家生命： " + Single.GetsingleObj().PH.Life.ToString();
            ////绘制玩家生命
            e.Graphics.DrawString(herolife, new Font("宋体", 20, FontStyle.Bold), Brushes.Black, new Point(800, 0));

            string score = "分数值： "+Single.GetsingleObj().Score.ToString();
            //绘制玩家的分数
            e.Graphics.DrawString(score, new Font("微软雅黑", 20, FontStyle.Bold), Brushes.Black, new Point(0, 0));




        }
        /// <summary>
        /// 定时器的动作，更新本机的动作，检测碰撞，获取当前敌机集合数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {

            if (Single.GetsingleObj().PH.Life == 0)
            {
                //Single.GetsingleObj().PH = null;
               // GC.Collect();

                this.Dispose();

                string score = Single.GetsingleObj().Score.ToString();//分数存储

                string name = Interaction.InputBox("请输入名字", "哈哈，死了啊 ！！开不开心，意不意外？输入名字吧", "姓名", -1, -1);

                string connstring = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=D:\Project\C#Project\Last_II_15\Last_II\pl.mdf;Integrated Security=True;Connect Timeout=30";

                SqlConnection conn = new SqlConnection(connstring);

                conn.Open();//打开数据库

                string sql = "INSERT INTO [dbo].[so] ([名字],[分数]) VALUES (N'" + name + "','" + score + "')";

                SqlCommand cmd = new SqlCommand(sql, conn);//存入数据库

                cmd.ExecuteNonQuery();

                conn.Close();//关闭数据库

                new ScoreOption().Show();

                this.Hide();

            }
            this.Invalidate();
            Single.GetsingleObj().PH.update();//本机动作更新
            Single.GetsingleObj().isCrash();//碰撞检测
            Single.GetsingleObj().isCrashII();
            int count = Single.GetsingleObj().listPlaneEnemy.Count;//获取敌机数量
            if (count <= 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    Single.GetsingleObj().AddEntity(new PlaneEnemy(r.Next(0, this.Width), r.Next(-20, 0) * i, r.Next(1, 3)));//两种飞机
                      //不应该每次都出现最大的那个飞机，应该有一个几率出现
                    if (r.Next(0, 100) > 70) {
                        //百分之三十的几率出现大飞机
                        Single.GetsingleObj().AddEntity(new PlaneEnemy(r.Next(0, this.Width), r.Next(-100, 0) * i, 3));
                    }
                }              
            }
        }
        //以下两个事件响应PlaneHero类的移动动作的函数
        private void StartOption_KeyDown(object sender, KeyEventArgs e)
        {
            Single.GetsingleObj().PH.Move_KeyDown(e);
        }

        private void StartOption_KeyUp(object sender, KeyEventArgs e)
        {
            Single.GetsingleObj().PH.Move_KeyUp(e);
        }

        private void StartOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
