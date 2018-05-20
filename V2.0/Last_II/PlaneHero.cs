using Last_II.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Last_II
{
    /// <summary>
    /// 本机对象类
    /// </summary>
    class PlaneHero : PlaneFather
    {
        public bool isLeft, isRight, isUp, isDown,isFire;//判断方向的四个值，再加上发射子弹的值
        private static Image imgPlane = Resources.hero1;
        /// <summary>
        /// 要初始化的它的x坐标,y坐标，速度，生命，对象种类，其他属性继承飞机父类PlnaeFther，还有上帝实体类EntityAll
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        /// <param name="life"></param>
        /// <param name="vari"></param>
        public PlaneHero(int x,int y,int speed,int life,Variety vari) : 
            base(imgPlane, x, y, speed, life, vari)
        {
        }
        public override void Draw(Graphics g)
        {
          base. Move();//这里的Move只是让它的坐标限制在窗体内
            g.DrawImage(imgPlane, this.X , this.Y);
        }
        /// <summary>
        /// 抬起按键时直接响应结束，用键盘事件类的参数与窗口相互绑定
        /// </summary>
        /// <param name="e"></param>
        public void Move_KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                   isLeft = false;
                    break;
                case Keys.D:
                    isRight = false;
                    break;
                case Keys.W:
                    isUp = false;
                    break;
                case Keys.S:
                    isDown = false;
                    break;
                case Keys.J:
                    isFire = false;
                    break;
            }
        }
        /// <summary>
        /// 按下时对应的动作，用键盘事件类的参数与窗口相互绑定
        /// </summary>
        /// <param name="e"></param>
        public void Move_KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    isLeft = true;
                    break;
                case Keys.D:
                    isRight = true;
                    break;
                case Keys.W:
                    isUp = true;
                    break;
                case Keys.S:
                    isDown = true;
                    break;
                case Keys.J:
                    isFire = true;
                    break;

            }
        }
        public void update()
        {
            //处理各方向的移动,更新位置坐标,
            if (isLeft) this.move_left(Speed);
            if (isRight) this.move_right(Speed);
            if (isUp) this.move_up(Speed);
            if (isDown) this.move_down(Speed);
            //让它开炮
            if (isFire) this.HeroFire();

        }

        private void move_left(int speed)
        {
           
                this.X -= speed;
        }
        private void move_right(int speed)
        {
          
                this.X += speed;
        }
        private void move_up(int speed)
        {
         
                this.Y -= speed;
        }
        private void move_down(int speed)
        {
     
                this.Y += speed;
        }
        int i = 0;
        private void HeroFire()
        {
            
            if (i == 5) { 
                Single.GetsingleObj().AddEntity(new HeroBullet(this, 3, 2));
                i -= 5;
            }
            i++;
        }

        public override void isDie()
        {

            Single.GetsingleObj().PH.Life-= 1;//敌人打一下就把生命减一血，当然不会直接死啦

        }

    }
}
