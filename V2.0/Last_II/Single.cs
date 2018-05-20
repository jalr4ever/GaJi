using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Last_II
{
    /// <summary>
    /// 单例类，用该单列类与窗体类相联系，让对象的使用内容封装在一个类中，并在窗体类中调用，减少代码量
    /// </summary>
    class Single
    {
        //单例模式的三个步骤，构造函数私有化，全局唯一对象，用一个静态函数返回一个对象
        private Single() { }
        private static Single singleObj = null;
        public static Single GetsingleObj()
        {
            if (singleObj == null)
                return singleObj = new Single();
            else
                return singleObj;
        }
        public int Score//记录分数的属性
        {
            set;
            get;
        }

        public Background BG//该对象类型的属性存储唯一的背景
        {
            set;
            get;
        }
        public PlaneHero PH//该对象类型的属性储存唯一本机
        {
            set;
            get;
        }
        List<HeroBullet> listHeroBullet =new List<HeroBullet>();//用一个集合然后限定它为hero子弹类型
        List<EnemyBullet> listEnemyBullet = new List<EnemyBullet>();//集合储存敌人子弹
       public List<PlaneEnemy> listPlaneEnemy = new List<PlaneEnemy>();//集合储存敌人
        public void AddEntity(EntityAll EA)//添加实体对象
        {
            if(EA is Background)
            {
                this.BG = EA as Background;
            }
            if(EA is PlaneHero)
            {
                this.PH = EA as PlaneHero;
            }
            if(EA is HeroBullet)
            {
                this.listHeroBullet.Add(EA as HeroBullet);//如果是子弹，则添加到子弹集合
            }
            if(EA is EnemyBullet)
            {
                this.listEnemyBullet.Add(EA as EnemyBullet);
            }
            if(EA is PlaneEnemy)
            {
                this.listPlaneEnemy.Add(EA as PlaneEnemy);
            }
        }
        public void RemoveEntity(EntityAll EA)//移除实体对象
        {
            if(EA is HeroBullet)
            {
                this.listHeroBullet.Remove(EA as HeroBullet);
            }
            if(EA is EnemyBullet)
            {
                this.listEnemyBullet.Remove(EA as EnemyBullet);
            }
            if(EA is PlaneEnemy)
            {
                this.listPlaneEnemy.Remove(EA as PlaneEnemy);
            }
        }

        public void Draw(Graphics g)//绘图，包含游戏对象所有的绘图动作
        {
            this.BG.Draw(g);
            this.PH.Draw(g);
            for (int i = 0; i < listHeroBullet.Count; i++)//无限绘出本机子弹
            {
                listHeroBullet[i].Draw(g);
            }
            for (int i = 0; i < listEnemyBullet.Count; i++)//无限绘出敌人子弹
            {
                listEnemyBullet[i].Draw(g);
            }
            for (int i = 0; i <listPlaneEnemy.Count; i++)//无限绘出敌人
            {
               listPlaneEnemy[i].Draw(g);
            }
        }
        //还要碰撞测试唔，因为子弹的生命周期到它碰到实体才结束
        public void isCrashII()
        {


            //敌人子弹对本机
            for (int i = 0; i < listEnemyBullet.Count; i++)
            {
                if (listEnemyBullet[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    //让玩家减血 但不死亡
                    listEnemyBullet.Remove(listEnemyBullet[i]);
                    this.PH.isDie();
                    
                    //再把子弹移除
              
                    break;
                }
            }
        }
        public void isCrash()//碰撞测试，包含测试后的工作
        {      
            /*
            //另一个版本的碰撞测试
           for (int i = 0; i < listPlaneEnemy.Count; i++)
           {
           bool isCrashed = false;
           if (Math.Abs(this.PH.X -  listPlaneEnemy[i].X) < (this.PH.Width / 4 +  listPlaneEnemy[i].Width) / 2 && Math.Abs(this.PH.Y -  listPlaneEnemy[i].Y) < (this.PH.Height - 30 +  listPlaneEnemy[i].Height) / 2)
           {
           isCrashed = true;
           }
           if (isCrashed)
           {
                       listPlaneEnemy[i].Life = 0;

                    listPlaneEnemy[i].isDie();
           return;
           }
           }*/
           
  
            //敌人对本机
            for (int i = 0; i < listPlaneEnemy.Count; i++)
                {
                    if (listPlaneEnemy[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                    {
     
                    listPlaneEnemy[i].Life = 0;
                    this.PH.isDie();//判断自己是否死亡
                    listPlaneEnemy[i].isDie();

                    break;
                    }
                }
       
            //本机子弹对敌人,二重循环，细节实现是用系统自带的ntersectsWith判断
            for (int i = 0; i < listHeroBullet.Count; i++)
            {
                for (int j = 0; j < listPlaneEnemy.Count; j++)
                {
                    if (listHeroBullet[i].GetRectangle().IntersectsWith(listPlaneEnemy[j].GetRectangle()))
                    {
                        //玩家的子弹打到了敌人的身上
                        //敌人的生命值减少
                          listPlaneEnemy[j].Life -= listHeroBullet[i].Power;
                     
                        //生命值减少后 应该判断敌人是否死亡
                        listPlaneEnemy[j].isDie();
                        //玩家子弹打到了敌人身上后 应该将玩家子弹销毁
                        listHeroBullet.Remove(listHeroBullet[i]);
                        break;
                    }
                }
            }
        }
        }
    }
