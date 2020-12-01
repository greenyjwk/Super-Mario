using Mario.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
   public sealed class LevelCounter
    {
        private static LevelCounter instance = new LevelCounter();
        public static LevelCounter Instance { get => instance; set => instance = value; }
        public int Level { get; set; }
        private LevelCounter()
        {
            Level = LevelUtil.minLevel;
        }
        public int CurrentLevel()
        {
            return Level;
        }
        public void LevelUp()
        {
            Level++;
        }
        public void ResetLevel()
        {
            Level = LevelUtil.minLevel;
        }
    }
}
