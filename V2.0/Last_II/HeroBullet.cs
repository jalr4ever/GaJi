using Last_II.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_II
{
    /// <summary>
    /// 本机子弹类
    /// </summary>
    
    class HeroBullet:Bullet
    {
        //还是一样，表示出本机子弹的图片
        private static Image ImgHeroBullect = Resources.bullet1;
        public HeroBullet(PlaneFather pf,int power,int speed) : base(ImgHeroBullect, pf, power, speed*3, "BestHeroBullet")
        {
            //由于在继承Bullet已经给本机子弹矫正，这里不需要矫正
        }

    }
}
