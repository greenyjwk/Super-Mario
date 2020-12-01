using Game1;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class MarioFactory:DynamicGameObjectFactory
	{
		private static MarioFactory instance = new MarioFactory();
		public static MarioFactory Instance { get => instance;}
		public MarioFactory():base()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof(IMario), GetMario }
			};
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Dictionary<Type, Tuple<Texture2D, int, int>>>
			{
				{typeof(NormalMarioPowerupState), new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioLeftIdle),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioLeftJump),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioLeftRunning),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioRightIdle),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioRightJump),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioRightRunning),1,3) }
				} },
				{typeof(SuperMarioPowerupState), new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftCrouchingMarioMovementState), new Tuple<Texture2D,int,int>( content.Load<Texture2D>(SpriteString.SuperMarioLeftCrouch),1,1) },
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioLeftIdle),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioLeftJump),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioLeftRunning),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioRightIdle),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioRightJump),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioRightRunning),1,3) },
					{typeof(RightCrouchingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SuperMarioRightCrouch),1,1 )}
				} },
				{typeof(FireMarioPowerupState),new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftCrouchingMarioMovementState), new Tuple<Texture2D,int,int>( content.Load<Texture2D>(SpriteString.FireMarioLeftCrouch),1,1) },
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioLeftIdle),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioLeftJump),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioLeftRunning),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioRightIdle),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioRightJump),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioRightRunning),1,3) },
					{typeof(RightCrouchingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.FireMarioRightCrouch),1,1 )}
				}  },
				{typeof(DeadMarioPowerupState),new Dictionary<Type, Tuple<Texture2D,int,int>>()
				{
					{typeof(DeadMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.NormalMarioDead),1,1) }
				} },
               


            };
		}
		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}

		
		
	}
}
