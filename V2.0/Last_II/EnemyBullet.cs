using Last_II.Properties;
using System.Drawing;

namespace Last_II
{
    /// <summary>
    /// 敌机子弹类，继承于子弹类
    /// </summary>
    internal class EnemyBullet:Bullet
    {
        private static Image imgEnemyBullet = Resources.bullet;//一样把图先存在字段imgEnemyBullet里
        /// <summary>
        /// 初始化子弹时要知道的参数是飞机的类型，速度，威力值
        /// </summary>
        /// <param name="pf"></param>
        /// <param name="speed"></param>
        /// <param name="power"></param>
        public EnemyBullet(PlaneFather pf, int speed, int power):base(imgEnemyBullet,pf,power,speed, "BULLET-EnemyBullet")
        {
            //敌机跟机各不同，矫正坐标要在各自的类中改
            //这里让敌机的子弹坐标跟着其自己的前面
          Y = pf.Y + pf.Height / 2+20;
          X = pf.X + pf.Width / 2-10;

        }
    }
}