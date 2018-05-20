using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_II
{
    /// <summary>
    /// 上帝实体类，包含着所有游戏中所有对象的共性抽取
    /// </summary>
    public enum Variety
    {
        //涉及的对象种类
        Enemy,
        Hero,
        Background
    }
    abstract class EntityAll
    {
        public EntityAll(String name,int x,int y,int height,int width,int speed, int life,Variety vari)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
            this.Speed = speed;
            this.Life = life;
            this.Vari = vari;             
        }
       
        /// <summary>
        /// 游戏对象的共有属性:名字，X坐标，Y坐标，高度，宽度，速度，生命值，种类
        /// </summary>
       
        #region 共有属性

        public string Name
        {
            set;
            get;
        }
        public int X
        {
            set;
            get;
        }
        public int Y
        {
            set;
            get;
        }
        public int Height
        {
            set;
            get;
        }
        public int Width
        {
            set;
            get;
        }
        public int Speed
        {
            set;
            get;
        }
        public int Life
        {
            set;
            get;
        }
        public Variety Vari
        {
            set;
            get;
        }
        #endregion 

        /// <summary>
        /// 游戏对象的的共有动作:绘图，移动
        /// </summary>
        abstract public void Draw(Graphics g);//绘图，方式各不相同，让子类去重写
        public virtual void Move()//让子类重写或者继承
        {
            #region 将实体对象限制在窗体内,很蛋疼的是窗口并不是按照其Size属性的1440X900？！！
            if (this.X <= 0)
            {
                this.X = 0;
            }
            if (this.X >=980)
            {
                this.X =980;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.Y >=553)
            {
                this.Y =553;
            }
            #endregion
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y,this.Width,this.Height);
        }


    }
}