using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_II
{
    /// <summary>
    /// 飞机对象的父类
    /// </summary>
    abstract class PlaneFather:EntityAll
    {
        private Image imgPlane;//存储飞机的图片

        /// <summary>
                               /// 飞机的共有属性，飞机的图，名，飞机图x坐标，飞机图y坐标，高，宽，速度，生命，种类
                               /// </summary>
                               /// <param name="img"></param>
                               /// <param name="name"></param>
                               /// <param name="x"></param>
                               /// <param name="y"></param>
                               /// <param name="height"></param>
                               /// <param name="width"></param>
                               /// <param name="speed"></param>
                               /// <param name="life"></param>
                               /// <param name="vari"></param>

        public PlaneFather(Image img,int x,int y,int speed,int life,Variety vari)
            :base("Setihex2017",x,y,img.Height,img.Width,speed,life,vari)
        {
            this.imgPlane = img;
        }
        abstract public void isDie();//判断死亡状态，两者各不相同，让子类重写
    }
}
