using Game1;
using Mario.BlockStates;
using Mario.Factory;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass
{
    public static class EnemyUtil 
    {
        public const int goombaDisappear = 15;
        public const int goombaAppear = 0;
        public const int bossOffset = 9999;
        public const int miniBossLife = 5;
        public const int miniBossZeroLife = 0;
        public const int DelayInitial = 0;
        public const int DelayRange = 100;
        public static Vector2 Util { get => new Vector2(5, 0); }

    }
}
