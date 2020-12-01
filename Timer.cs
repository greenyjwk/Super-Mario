using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Timers;
using Mario.HeadUpDesign;
using Game1;

namespace Mario
{
    static class Timer
    {
      
        public static int Time { get; set; } = TimerUtil.MaxTimer;
        private static int counter = TimerUtil.Zero;
        private static bool timeRunning = false;
        private static readonly int maxTime = TimerUtil.MaxTimer;
        public static void ResetTimer()
        {
            Time = maxTime;
            timeRunning = false;
        }


        public static void StartTimer()
        {
            timeRunning = true;
        }

        public static void StopTimer()
        {
            timeRunning = false;
        }
        public static void SetTimeRunning(bool flag)
        {
            if (flag)
                timeRunning = true;
            else
                timeRunning = false;
        }
        public static void TimerCheckingTime(GameTime gameTime)
        {
                if (timeRunning)
                {
                    counter += gameTime.ElapsedGameTime.Milliseconds;
                    if (counter >= TimerUtil.DecreaseRate)
                    {
                        Time--;
                        counter = TimerUtil.Zero;
                    }
                    if (Time == TimerUtil.Zero && (!GameObjectManager.Instance.Mario.IsAtEnd()))
                    {
                        ResetTimer();
                        GameObjectManager.Instance.Mario.TakeDamage();
                }
            }
        }
      
        public static void ExtendTime(int multiplyTime)
        {
            Time += TimerUtil.ExtentTime * multiplyTime;
            if (Time > TimerUtil.MaxTimer)
                Time = TimerUtil.MaxTimer;
        }
    }
}
