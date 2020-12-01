using Mario.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
   public sealed class LifeCounter
    {
        private static LifeCounter instance = new LifeCounter();
        public static LifeCounter Instance { get => instance; set => instance = value; }
        public int Life { get; set; }
        private LifeCounter()
        {
            Life = LifeUtil.maxLife;
        }
        public int LifeRemains()
        {
            return Life;
        }
        public void DecreaseLife()
        {
            Life--;
        }
        public void IncreaseLife()
        {
            if(Life<3)
            Life++;
        }
        public void ResetLife()
        {
            Life = LifeUtil.maxLife;
        }
        public void SetLifeZero()
        {
            Life = LifeUtil.minLife;
        }
    }
}
