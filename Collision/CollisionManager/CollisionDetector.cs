using Mario.Collision.FireballCollisionHandler;
using Mario.Collision.ItemCollisionHandler;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Game1;
using Mario.Collision.EnemyCollisionHandler;
using Mario.Factory;
using Mario.BlockStates;
using Mario.GameObjects.Block;
using Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler;
using Mario.EnemyStates.GoombaStates;
using Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler;
using Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler;
using Mario.ItemClasses;
using Mario.HeadUpDesign;
using Mario.Collections;
using System.Collections;

namespace Mario.Collision.CollisionManager
{
	class CollisionDetector
	{

		private static readonly CollisionDetector instance = new CollisionDetector();
		public static CollisionDetector Instance { get => instance; }
		private GameObjectList GameObjectListsByType { get => GameObjectManager.Instance.GameObjectList;}
		private IList<Rectangle> FloorBoxPosition { get => GameObjectManager.Instance.FloorBoxPositions; }

		private ICamera CameraMario { get => GameObjectManager.Instance.CameraMario; }
		private IMario Mario { get => GameObjectManager.Instance.Mario; }
       
		public void Update()
		{
			IMario mario = (IMario)GameObjectListsByType.Peek(typeof(IMario));
            Direction collisionFound;
            Rectangle intersection;
            IBlockCollisionHandler blockHandler;
            IBlockCollisionHandler pipeHandler;
            IItemCollisionHandler itemHandler;
            IEnemyCollisionHandler enemyHandler;
            IMarioCollisionHandler marioHandler;
            IProjectileCollisionHandler projectileCollisionHandler;
            CollisionUtility collisionDetecter = new CollisionUtility();
            collisionFound = collisionDetecter.Collision(mario.Box, CameraMario.InnerBox);
            intersection = collisionDetecter.Intersection;

            if (!collisionFound.Equals(Direction.None))
			{
				mario.Position += Vector2.UnitY * intersection.Width;
            }

			foreach (Rectangle floorBox in FloorBoxPosition)
			{
                if (!CameraMario.IsOffSideOfScreen(floorBox))
                {
                    IEnumerator gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IProjectile));

                    while (gameObjectEnumerator.MoveNext())
                    {

                        IProjectile projectile = (IProjectile)gameObjectEnumerator.Current;
                        if (!CameraMario.IsOffSideOfScreen(projectile.Box))
                        {
                            collisionFound = collisionDetecter.Collision(projectile.Box, floorBox);
                            intersection = collisionDetecter.Intersection;
                            projectileCollisionHandler = new FireballBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), Vector2.Zero), intersection, collisionFound);
                            projectileCollisionHandler.HandleCollision(projectile);
                        }
                    }
                    gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IItem));
                    while (gameObjectEnumerator.MoveNext())
                    {
                        IItem item = (IItem)gameObjectEnumerator.Current;
                        if (!CameraMario.IsOffSideOfScreen(item.Box))
                        {
                            collisionFound = collisionDetecter.Collision(item.Box, floorBox);
                            intersection = collisionDetecter.Intersection;
                            itemHandler = new ItemBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), Vector2.Zero), intersection, collisionFound);
                            itemHandler.HandleCollision(item);
                        }
                    }
                    gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IEnemy));
                    while (gameObjectEnumerator.MoveNext())
                    {
                        IEnemy enemy = (IEnemy)gameObjectEnumerator.Current;
                        if (!CameraMario.IsOffSideOfScreen(enemy.Box))
                        {
                            if (!enemy.IsFlipped())
                            {
                                collisionFound = collisionDetecter.Collision(enemy.Box, floorBox);
                                intersection = collisionDetecter.Intersection;
                                enemyHandler = new EnemyBlockCollisionHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), Vector2.Zero), intersection, collisionFound);
                                enemyHandler.HandleCollision(enemy);
                            }
                        }
                    }
                    if (mario.IsActive())
                    {
                        collisionFound = collisionDetecter.Collision(Mario.Box, floorBox);
                        intersection = collisionDetecter.Intersection;
                        blockHandler = new BlockHandler();
                        blockHandler.HandleCollision((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), Vector2.Zero), Mario, collisionFound);
                        CallMarioBlockHandler((IBlock)BlockFactory.Instance.GetGameObject(typeof(BrickBlockState), Vector2.Zero), collisionFound, intersection);
                    }
                }
			}

			IEnumerator projectileEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IProjectile));
			while (projectileEnumerator.MoveNext())
			{
				IProjectile projectile = (IProjectile)projectileEnumerator.Current;
                if (!CameraMario.IsOffSideOfScreen(projectile.Box))
                {
                    IEnumerator gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IBlock));
                    while (gameObjectEnumerator.MoveNext())
                    {
                        IBlock block = (IBlock)gameObjectEnumerator.Current;
                        collisionFound = collisionDetecter.Collision(projectile.Box, block.Box);
                        intersection = collisionDetecter.Intersection;
                        projectileCollisionHandler = new FireballBlockCollisionHandler(block, intersection, collisionFound);
                        projectileCollisionHandler.HandleCollision(projectile);
                    }

                    gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IPipe));
                    while (gameObjectEnumerator.MoveNext())
                    {
                        IPipe pipe = (IPipe)gameObjectEnumerator.Current;
                       
                            collisionFound = collisionDetecter.Collision(projectile.Box, pipe.Box);
                            intersection = collisionDetecter.Intersection;

                            projectileCollisionHandler = new FireballBlockCollisionHandler(pipe, intersection, collisionFound);
                            projectileCollisionHandler.HandleCollision(projectile);
                    }

                    gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IEnemy));
                    while (gameObjectEnumerator.MoveNext())
                    {
                        IEnemy enemy = (IEnemy)gameObjectEnumerator.Current;
                        if (!CameraMario.IsOffSideOfScreen(enemy.Box))
                        {
                            projectileCollisionHandler = new FireballEnemyCollisionHandler();
                            collisionFound = collisionDetecter.Collision(enemy.Box, projectile.Box);
                            enemyHandler = new EnemyProjectileCollisionHandler();
                            if (collisionFound != Direction.None)
                            {
                                enemyHandler.HandleCollision(enemy);
                                projectileCollisionHandler.HandleCollision(projectile);

                            }
                        }
                    }
                }
			}

			IEnumerator itemEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IItem));
			while (itemEnumerator.MoveNext())
			{
				IItem item = (IItem)itemEnumerator.Current;
                    if (!CameraMario.IsOffSideOfScreen(item.Box))
                    {
                        collisionFound = collisionDetecter.Collision(Mario.Box, item.Box);
                        if (collisionFound != Direction.None && Mario.IsActive())
                        {
                            intersection = collisionDetecter.Intersection;
                            itemHandler = new ItemMarioCollisionHandler();
                            itemHandler.HandleCollision(item);
                            CallMarioItemHandler(item, collisionFound);
                        }
                        IEnumerator gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IBlock));
                        while (gameObjectEnumerator.MoveNext())
                        {
                            IBlock block = (IBlock)gameObjectEnumerator.Current;
                          
                                if (!(block.BlockState is HiddenBlockState)&& !CameraMario.IsOffSideOfScreen(block.Box))
                                {
                                    collisionFound = collisionDetecter.Collision(item.Box, block.Box);
                                    intersection = collisionDetecter.Intersection;
                                    itemHandler = new ItemBlockCollisionHandler(block, intersection, collisionFound);
                                    itemHandler.HandleCollision(item);
                                }
                            
                        }

                        gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IPipe));
                        while (gameObjectEnumerator.MoveNext())
                        {
                            IPipe pipe = (IPipe)gameObjectEnumerator.Current;
                            collisionFound = collisionDetecter.Collision(item.Box, pipe.Box);
                            intersection = collisionDetecter.Intersection;
                            itemHandler = new ItemBlockCollisionHandler(pipe, intersection, collisionFound);
                            itemHandler.HandleCollision(item);

                        }
                    }
                
			}
			IEnumerator blockEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IBlock));
			while (blockEnumerator.MoveNext())
			{
				IBlock block = (IBlock)blockEnumerator.Current;
                if (!CameraMario.IsOffSideOfScreen(block.Box))
                {
                    collisionFound = collisionDetecter.Collision(Mario.Box, block.Box);
                    if (Mario.IsActive())
                    {
                        intersection = collisionDetecter.Intersection;
                        blockHandler = new BlockHandler();
                        blockHandler.HandleCollision(block, Mario, collisionFound);
                        CallMarioBlockHandler(block, collisionFound, intersection);
                    }
                }
			}

			IEnumerator enemyEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IEnemy));
			while (enemyEnumerator.MoveNext()) {
				IEnemy enemy = (IEnemy)enemyEnumerator.Current;
               
                    if (!enemy.IsFlipped()&& !CameraMario.IsOffSideOfScreen(enemy.Box))
                    {
                        collisionFound = collisionDetecter.Collision(Mario.Box, enemy.Box);
                        if (Mario.IsActive() && !(enemy.EnemyState is StompedGoombaState))
                        {
                            enemyHandler = new EnemyMarioCollisionHandler(Mario, collisionFound);
                            intersection = collisionDetecter.Intersection;
                            enemyHandler.HandleCollision(enemy);
                            marioHandler = new MarioEnemyCollisionHandler(enemy, intersection);
                            marioHandler.HandleCollision(Mario, collisionFound);

                        }
                        IEnumerator gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IBlock));
                        while (gameObjectEnumerator.MoveNext())
                        {
                            IBlock block = (IBlock)gameObjectEnumerator.Current;
                            if (!CameraMario.IsOffSideOfScreen(block.Box))
                            {
                                if (!(block.BlockState is HiddenBlockState))
                                {
                                    collisionFound = collisionDetecter.Collision(enemy.Box, block.Box);
                                    intersection = collisionDetecter.Intersection;
                                    enemyHandler = new EnemyBlockCollisionHandler(block, intersection, collisionFound);
                                    enemyHandler.HandleCollision(enemy);
                                }
                            }
                        }

                        gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IPipe));
                        while (gameObjectEnumerator.MoveNext())
                        {
                            IPipe pipe = (IPipe)gameObjectEnumerator.Current;
                           
                                collisionFound = collisionDetecter.Collision(enemy.Box, pipe.Box);
                                intersection = collisionDetecter.Intersection;
                                enemyHandler = new EnemyBlockCollisionHandler(pipe, intersection, collisionFound);
                                enemyHandler.HandleCollision(enemy);
                            
                        }

                        gameObjectEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IEnemy));
                        while (gameObjectEnumerator.MoveNext())
                        {
                            IEnemy goomba = (IEnemy)gameObjectEnumerator.Current;
                            if (!CameraMario.IsOffSideOfScreen(goomba.Box))
                            {
                                if (enemy.IsKoopa() && goomba.IsGoomba())
                                {
                                    collisionFound = collisionDetecter.Collision(enemy.Box, goomba.Box);
                                    intersection = collisionDetecter.Intersection;
                                    enemyHandler = new EnemyEnemyCollisionHandler(goomba, intersection, collisionFound);
                                    enemyHandler.HandleCollision(enemy);
                                }
                            }
                        }
                    }
                
			}
			IEnumerator pipeEnumerator = GameObjectListsByType.GetEnumeratorByType(typeof(IPipe));
			while (pipeEnumerator.MoveNext())
			{
				IPipe pipe = (IPipe)pipeEnumerator.Current;
               
                    collisionFound = collisionDetecter.Collision(Mario.Box, pipe.Box);
                    if (collisionFound != Direction.None && Mario.IsActive())
                    {

                        intersection = collisionDetecter.Intersection;
                        CallMarioBlockHandler(pipe, collisionFound, intersection);

                    }
                    if (pipe.ToUnderground)
                    {
                        pipeHandler = new PipeHandler();
                        pipeHandler.HandleCollision(pipe, Mario, collisionFound);
                    }
                
			}

			float difference = (float)(Mario.Position.X - GameObjectManager.Instance.CameraMario.Location.X);
			if (difference <= CollisionUtil.differenceFive && difference >= CollisionUtil.differenceZero)
			{
				mario.Position += Vector2.UnitY * difference;
            }
		}

		public void CallMarioItemHandler(IItem item, Direction collisionFound)
		{
            IMarioCollisionHandler marioHandler;
			if (item is FireFlower)
			{

				marioHandler = new MarioFireFlowerCollisionHandler();
			}
			else if (item is Starman)
			{

				marioHandler = new MarioStarmanCollisionHandler();

			}
			else if (item is MagicMushroom)
			{

				marioHandler = new MarioMagicMushroomCollisionHandler();
			}
            else if (item is OneUpMushroom)
            {
                marioHandler = new OneUpMushroomCollisionHandler();
            }
            else
			{
				marioHandler = null;
			}

			if (marioHandler != null)
			{
				marioHandler.HandleCollision(Mario, collisionFound);
			}
            if (item is Coin)
            {
                CoinSystem.Instance.AddCoin();
            }
            else if (item is UnderGroundCoin)
            {
                CoinSystem.Instance.AddCoin();
                Timer.ExtendTime(TimerUtil.Three);
                FloatingTimeBar.CreateNewTimeAnimation(item, TimerUtil.Three*TimerUtil.ExtentTime);
            }
            else
            {
                ScoringSystem.Instance.AddPointsForCollectingItem(item);
            }
     
		}
		public void CallMarioBlockHandler(IBlock block, Direction collisionFound, Rectangle intersection)
		{
			IMarioCollisionHandler marioHandler;
			if (block.BlockState is HiddenBlockState)
			{
				marioHandler = new MarioHiddenBlockHandler(intersection);
			}
			else
			{
				marioHandler = new MarioBlockHandler(intersection);
			}

			marioHandler.HandleCollision(Mario, collisionFound);

		}
       
	}
}
