using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Last_II.Properties;
namespace Last_II
{
    /// <summary>
    /// 背景类，这里只是载入一张图，并绘制出来
    /// </summary>
    class Background:EntityAll
    {
        private static Image imgBG = Resources.background;//载入背景图片
        /// <summary>
        /// 真正有点卵用的是传了x，y，图的宽，高都是用img的自带属性传的，
        /// 关于Variety种类是四个枚举之一是为了方便拓展建的
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Background(int x,int y):base("Background-= =!!!",x,y,imgBG.Height,imgBG.Width,0,0,Variety.Background)
        {
            //构造函数
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgBG, this.X, this.Y);//把背景绘制
        }
    }
}
