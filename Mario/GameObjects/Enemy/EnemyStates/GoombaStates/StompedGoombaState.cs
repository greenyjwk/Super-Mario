using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedGoombaState : EnemyState
    {
        int count = EnemyUtil.goombaAppear;
        public StompedGoombaState(IEnemy enemy) :base(enemy)
        {
        }

     
        public override bool IsGoomba()
        {
            return true;
        }
        public override void Update()
        {
            count++;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count < EnemyUtil.goombaDisappear)
            {
                EnemySprite.Draw(spriteBatch, location);
            }
            else
            {
                GameObjectManager.Instance.GameObjectList.Remove(Enemy);
            }
        }



    }
}

