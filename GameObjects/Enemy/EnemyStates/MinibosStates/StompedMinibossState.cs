using Game1;
using Mario.AbstractClass;
using Mario.GameObjects;
using Mario.HeadUpDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedMiniBossState : EnemyState
    {
        int count = EnemyUtil.goombaAppear;
        public StompedMiniBossState(IEnemy enemy) :base(enemy)
        {
           
        }

        public override void Update()
        {
            count++;
            Enemy.gravityManagement.Update();

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count < EnemyUtil.goombaDisappear)
            {
                EnemySprite.Draw(spriteBatch, location);
            }
            else
            {
                Enemy.Position -= Vector2.UnitX* EnemyUtil.bossOffset;
            }
        }
    }
}
