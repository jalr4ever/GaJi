using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_II
{
    /// <summary>
    /// 子弹类，封装了子弹的共有属性
    /// </summary>
    class Bullet:EntityAll
    {
        private Image BulletImg;//储存子弹图片
        
        public int Power//子弹的特有属性，与Life对应相互作用
        {
            set;
            get;
        }
        /// <summary>
        /// 子弹的共有属性，图，所属飞机，速度，名，x坐标，y坐标，高，宽，生命，种类
        /// 子弹的x,y坐标与飞机的x,y坐标相绑定，并且有一定的位移偏差，子弹的高与宽都用Image对象的
        /// 属性传进去了，生命直接赋给它零
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pf"></param>
        /// <param name="power"></param>
        /// <param name="speed"></param>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="life"></param>
        /// <param name="vari"></param>
        public Bullet(Image img,PlaneFather pf,int power,int speed,string name)
            :base(name, (pf.X+pf.Width/2), (pf.Y + pf.Height / 2) -50,img. Height,img.Width,speed,0,pf.Vari)
        {
            //把对应的子弹，威力值赋给要实例化的子对象(本机子弹或敌机子弹)
            this.BulletImg = img;
            this.Power = power;
        }
        public override void Draw(Graphics g)
        {
            this.Move();//表示让它的坐标逻辑位置
            g.DrawImage(BulletImg, this.X, this.Y);
        }
        public override void Move()//子弹不需要限制在窗口，就重写了
        {
            switch (this.Vari)//判断飞机的种类，赋予不同的移动方式
            {
                case Variety.Enemy://敌机子弹向下
                    this.Y += Speed;
                    break;
                case Variety.Hero:
                    this.Y -= Speed;//本机子弹向上
                    this.X = this.X;
                    break;
            }
            //子弹发出后 控制一下子弹的坐标
            if (this.Y <= 0)
            {
                this.Y = -100;
            }
            if (this.Y >= 1050)
            {
                Single.GetsingleObj().RemoveEntity(this);
                //在游戏中移除子弹对象
            }
        }
    }
}
