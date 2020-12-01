using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class ActiveMiniBossState : EnemyState
	{
		public ActiveMiniBossState(IEnemy enemy) : base(enemy)
		{
		}

	
        public override void ThrowGoomba()
        {
            GameObjectManager.Instance.GameObjectList.Add(new Goomba(Enemy.Position));
        }



    }
}
