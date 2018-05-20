using Last_II.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_II
{
    class PlaneEnemy:PlaneFather
    {
       private static Random r = new Random();//用于敌人的初始化
        private static Image EnemyImg1 = Resources.enemy1;
        private static Image EnemyImg2 = Resources.enemy2;
        private static Image EnemyImg3 = Resources.enemy3;
        int j;                //为了改变敌机左右移动状态设置的变量
        public PlaneEnemy(int x, int y, int type)
    : base(getEnemyType(type),x, y, getEnemySpeed(type),getEnemyLife(type),Variety.Enemy)
        {
            this.EnemyType = type;
            if (this.X < 400) {
                j = 0;
            }
            else {
                j = 1;
            }

            if (type == 2) {
                Speed -= 4;
            }

        }
        public int EnemyType
        {
            get;
            set;
        }
        public static Image getEnemyType(int type)
        {
            switch (type)
            {
                case 1:
                    return EnemyImg1;
                case 2:
                    return EnemyImg2;
                case 3:
                    return EnemyImg3;
            }
            return null;
        }
        public static int getEnemyLife(int type)
        {
            switch (type)
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                    return 7;
            }
            return 0;
        }
        public static int getEnemySpeed(int type)
        {
            switch (type)
            {
                case 1:
                    return 5;//5
                case 2:
                    return 6;//6
                case 3:
                    return 7;//7
            }
            return 0;
        }
        public override void Draw(Graphics g)
        {
            this.Move();
            switch (this.EnemyType) {   //PlaneEnemy(r.Next(0, this.Width), r.Next(-80, 0) * i, r.Next(1, 3))
                case 1:
                    g.DrawImage(EnemyImg2, this.X, this.Y);//999
                    break;
                case 2:
                    g.DrawImage(EnemyImg1, this.X, this.Y);
                    break;
                case 3:
                    g.DrawImage(EnemyImg3, this.X, this.Y);
                    break;
            }

        }
        int r0 = new Random().Next(1, 5);
        
        public override void Move()
        {
          
            //base.Move();
            switch (this.Vari)
            {   

                case Variety.Enemy:
                
                    this.Y += this.Speed /2;    //敌机向前
                    if (j == 0) {
                        if (r0 > 3) {
                            this.X += 3;
                            if (this.X > 970) {//888
                                j = 1;
                            }
                            break;
                        }
                        else {
                            this.X -= 3;
                            if (this.X < 0) {//888
                                j = 1;
                            }
                            break;
                        }

                    }


                    if (j == 1) {
                        if (r0 > 3) {
                            this.X -= 3;
                            if (this.X <0) {//888
                                j = 0;
                            }
                            break;
                        }
                        else {
                            this.X += 3;
                            if (this.X > 970) {//888
                                j = 0;
                            }
                            break;
                        }

                    }
                    break;
            }

            if (this.Y >= 900) {
                
                Single.GetsingleObj().RemoveEntity(this);
            }
            //百分之十的概率发射子弹
            if (r.Next(0, 100) > 90) {
                this.Fire();
            }

        }

        //控制子弹间隔的参数
        int i = 10;
        public void Fire()
        {
 

            if (i == 10) {
                Single.GetsingleObj().AddEntity(new EnemyBullet(this, 4, 2));
                i -= 10;
            }
            i++;//累加器
            
    }
        public override void isDie()
        {
          Single.GetsingleObj().RemoveEntity(this);
            if (this.Life <= 0)
            {
                //敌人飞机坠毁 应该将敌人飞机从游戏中移除
               
                
                //敌人发生了爆炸 给玩家加分
                //需要根据不同的敌人类型 添加不同的分数
                switch (this.EnemyType)
                {
                    case 1:
                        //获得单例中记录玩家分数的属性
                        Single.GetsingleObj().Score += 100;
                        break;
                    case 2:
                        Single.GetsingleObj().Score += 200;
                        break;
                    case 3:
                        Single.GetsingleObj().Score += 300;
                        break;
                }
            }
        }
    }
}
