using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.CameraClasses;
using Mario.Classes.BackgroundClasses;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects;
using Mario.GameObjects.Block;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mario.XMLRead
{
    public sealed class LevelLoader
    {
		private readonly IList<IGameObject> projectileList = new List<IGameObject>();
		public IList<IGameObject> ProjectileList { get => projectileList;  }
		private static LevelLoader instance = new LevelLoader();
	
		public static LevelLoader Instance { get => instance; set => instance = value; }
        private static IList<int> NumberList = new List<int>();

        static readonly XmlSerializer pipeSerializer = new XmlSerializer(typeof(List<PipeXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer blockSerializer = new XmlSerializer(typeof(List<BlockXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer enemySerializer = new XmlSerializer(typeof(List<EnemyXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer itemSerializer = new XmlSerializer(typeof(List<ItemXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer playerSerializer = new XmlSerializer(typeof(List<PlayerXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer backSerializer = new XmlSerializer(typeof(List<BackgroundXML>), new XmlRootAttribute("chunk"));
        static readonly XmlSerializer projectileSerializer = new XmlSerializer(typeof(List<ProjectileXML>), new XmlRootAttribute("chunk"));


		private Dictionary<string, XmlSerializer> xmlSerializersByType;
		public Dictionary<string, XmlSerializer> XmlSerializersByType { get => xmlSerializersByType; set => xmlSerializersByType = value; }

		private readonly Dictionary<Type, Func<XmlNode,int, IList<IGameObject>>> LoadFunctionByType = new Dictionary<Type, Func<XmlNode,int, IList<IGameObject>>>
		{
            {typeof(IPipe), LoadPipe },
            {typeof(IBlock),LoadBlock },
			{typeof(IItem), LoadItem },
			{typeof(IEnemy), LoadEnemy },
			{typeof(IBackground), LoadBackground },
			{typeof(IMario), LoadPlayer },
            {typeof(IProjectile), LoadProjectile }
        };
         private LevelLoader()
        {
        }

		private IList<IGameObject> CreateSubListByType(XmlNode chunkNode, Type gameObjInterfaceType, int offset)
		{
			return LoadFunctionByType[gameObjInterfaceType](chunkNode, offset);
		}
		private int AddChunkToLevel(XmlNode chunkNode, int offset)
		{
			foreach(Type gameObjType in LoadFunctionByType.Keys)
			{
				GameObjectManager.Instance.GameObjectList.AddListByType(gameObjType, CreateSubListByType(chunkNode,gameObjType,offset));
			}
			return offset += (int)CameraUtil.resolutionWidth;
		}
        public void LoadFile(string file)
        {
			
			XmlDocument levelFile = new XmlDocument();
			levelFile.Load(file);


			int offset = 0;
			XmlNode chunkNode = levelFile.SelectSingleNode("//chunk[@type='start']");
			offset = AddChunkToLevel(chunkNode, offset);
			GameObjectManager.Instance.GameObjectList.DisplayElementsToConsole();
			//load start

			NumberList = RandomNumber();
			Debug.WriteLine(NumberList.Count.ToString());
			foreach(int id in NumberList)
			{
				string xmlSelectString = "//chunk[@type='overworld' and @id='" + id.ToString() + "']";
				Debug.WriteLine(xmlSelectString + " starting at offset " + offset);
				chunkNode = levelFile.SelectSingleNode(xmlSelectString);
				if(chunkNode == null)
				{
					Debug.WriteLine("Chunk of id: " + id + " is not an overworld chunk. Cannot be part of procedural generation");
					
				}
				else
				{
					
					offset = AddChunkToLevel(chunkNode, offset);
				}
			}

			chunkNode = levelFile.SelectSingleNode("//chunk[@type='floor']");
			AddChunkToLevel(chunkNode, LevelLoaderUtil.zero);

			chunkNode = levelFile.SelectSingleNode("//chunk[@type='end']");
			offset = AddChunkToLevel(chunkNode, offset);

			//level ends here, but start readded as a kind of facade, to give the illusion of continuity
			chunkNode = levelFile.SelectSingleNode("//chunk[@type='start']");
			offset = AddChunkToLevel(chunkNode, offset);

			chunkNode = levelFile.SelectSingleNode("//chunk[@type='underground']");
			AddChunkToLevel(chunkNode, LevelLoaderUtil.zero);
		}
		public static IList<IGameObject> LoadPipe(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<PipeXML> myPipeObject = (IList<PipeXML>)pipeSerializer.Deserialize(nodeReader);
			IList<IGameObject> pipeList = new List<IGameObject>();
			foreach (PipeXML pipe in myPipeObject)
			{
				if (GetType(pipe.BlockType).Equals(typeof(Pipe)))
				{
					pipeList.Add(BlockFactory.Instance.GetGameObject(GetType("Pipe"), new Vector2(pipe.XLocation + findOffSet, pipe.YLocation)));
					((IPipe)pipeList.Last<IGameObject>()).SetToUnderground(pipe.IsToUnderground);
				}

			}
			return pipeList;
		}
        public static IList<IGameObject> LoadBlock(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<BlockXML> myBlockObject = (IList<BlockXML>)blockSerializer.Deserialize(nodeReader);
            IList< IGameObject > blockList = new List<IGameObject>();
            foreach (BlockXML block in myBlockObject)
            {
                if (!GetType(block.BlockType).Equals(typeof(FloorBlockState)) && !GetType(block.BlockType).Equals(typeof(UnbreakableBlockState)))
                {
                    blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet, block.YLocation)));
                    ((IBlock)blockList.Last<IGameObject>()).ItemContained = block.ItemContains;
                }
                else if (GetType(block.BlockType).Equals(typeof(FloorBlockState)))
                {
                    
                    Rectangle floorLocationBox = new Rectangle(block.XLocation,block.YLocation,block.Length*32 ,block.Height*32);
                    GameObjectManager.Instance.FloorBoxPositions.Add(floorLocationBox);
                    int count = LevelLoaderUtil.zero;
                    int count2 = LevelLoaderUtil.zero;
                    int startLocation = block.XLocation;
                    while (count < block.Height)
                    {
                        while (count2 < block.Length)
                        {
                            blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation, block.YLocation)));
                            block.XLocation += LevelLoaderUtil.blockOffset;
                            count2++;
                        }
                        block.YLocation = block.YLocation + LevelLoaderUtil.blockOffset;
                        count++;
                        count2 = LevelLoaderUtil.zero;
                        block.XLocation = startLocation;
                    }
                }
                else
                {
                    if (block.Height > LevelLoaderUtil.zero)
                    {
                        int count = block.Length;
                        int differentBetween = block.Length - block.Height;

                        while (count > differentBetween)
                        {
                            int startX = block.XLocation;
                            for (int i = LevelLoaderUtil.zero; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet * CameraUtil.resolutionWidth, block.YLocation)));
                                block.XLocation = block.XLocation + LevelLoaderUtil.blockOffset;
                            }
                            block.YLocation = block.YLocation - LevelLoaderUtil.blockOffset;
                            block.XLocation = startX + LevelLoaderUtil.blockOffset;
                            count--;
                        }
                    }
                    else
                    {
                        int count = block.Length;
                        int differentBetween = block.Length + block.Height;

                        while (count > differentBetween)
                        {
                            int startX = block.XLocation;
                            for (int i = LevelLoaderUtil.zero; i < count; i++)
                            {
                                blockList.Add(BlockFactory.Instance.GetGameObject(GetType(block.BlockType), new Vector2(block.XLocation + findOffSet * CameraUtil.resolutionWidth, block.YLocation)));
                                block.XLocation = block.XLocation + LevelLoaderUtil.blockOffset;
                            }
                            block.YLocation = block.YLocation - LevelLoaderUtil.blockOffset;
                            block.XLocation = startX;
                            count--;
                        }
                    }
                }
            }
			return blockList;
        }
        public static IList<IGameObject> LoadEnemy(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<EnemyXML> myEnemyObject = (IList<EnemyXML>)enemySerializer.Deserialize(nodeReader);
			IList<IGameObject> enemyList = new List<IGameObject>();
            foreach (EnemyXML enemy in myEnemyObject)
			{
                enemyList.Add(EnemyFactory.Instance.GetGameObject(GetType(enemy.EnemyType), new Vector2(enemy.XLocation+findOffSet, enemy.YLocation)));
            }
			return enemyList;
        }
        public static IList<IGameObject> LoadItem(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<ItemXML> myItemObject = (IList<ItemXML>)itemSerializer.Deserialize(nodeReader);

			IList<IGameObject> itemList = new List<IGameObject>();
            foreach (ItemXML item in myItemObject)
            { 
                itemList.Add(ItemFactory.Instance.GetGameObject(GetType(item.GameObjectType), new Vector2(item.XLocation+findOffSet, item.YLocation)));
            }
			return itemList;
        }  
        public static IList<IGameObject> LoadBackground(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<BackgroundXML> myBackgroundObject = (IList<BackgroundXML>)backSerializer.Deserialize(nodeReader);
			IList<IGameObject> backgroundList = new List<IGameObject>();
            foreach (BackgroundXML back in myBackgroundObject)
            {
                if (back.BackgroundType.Equals("Flag")){
					GameObjectManager.Instance.EndOfLevelXPosition = back.XLocation+findOffSet;
				}
				backgroundList.Add(BackgroundFactory.Instance.GetBackgroundObject(back.BackgroundType, new Vector2( back.XLocation+findOffSet, back.YLocation)));
            }
			return backgroundList;
        }
        public static IList<IGameObject> LoadProjectile(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<ProjectileXML> myProjectileObject = (IList<ProjectileXML>)projectileSerializer.Deserialize(nodeReader);
            foreach (ProjectileXML projectile in myProjectileObject)
            {
                Instance.ProjectileList.Add(ProjectileFactory.Instance.GetGameObject(GetType(projectile.projectileType), new Vector2(projectile.XLocation, projectile.YLocation)));
            }
            return Instance.ProjectileList;
        }
        public static IList<IGameObject> LoadPlayer(XmlNode chunkNode, int findOffSet)
        {
			XmlNodeReader nodeReader = new XmlNodeReader(chunkNode);
			IList<PlayerXML> myPlayerObject = (IList<PlayerXML>)playerSerializer.Deserialize(nodeReader);
            IList<IGameObject> marioList = new List<IGameObject>();
            foreach (PlayerXML player in myPlayerObject)
            {
                marioList.Add(MarioFactory.Instance.GetGameObject(typeof(IMario), new Vector2(player.XLocation, player.YLocation)));

            }
            return marioList;
        }
		private static readonly IDictionary<string, Type> typeDictionary = new Dictionary<string, Type>
            {
                {typeof(IMario).Name, typeof(IMario) },
                {typeof(IBlock).Name, typeof(IBlock) },
                {typeof(IBackground).Name,typeof(IBackground) },
                {typeof(IEnemy).Name, typeof(IEnemy) },
                {typeof(FloorBlockState).Name, typeof(FloorBlockState) },
                {typeof(HiddenBlockState).Name, typeof(HiddenBlockState) },
                {typeof(Pipe).Name, typeof(Pipe) },
                {typeof(QuestionBlockState).Name, typeof(QuestionBlockState) },
                {typeof(UnbreakableBlockState).Name,typeof(UnbreakableBlockState) },
                {typeof(BrickBlockState).Name, typeof(BrickBlockState) },

                {typeof(Koopa).Name, typeof(Koopa) },
                {typeof(Goomba).Name, typeof(Goomba) },
                {typeof(MiniBoss).Name,   typeof(MiniBoss)},
				{typeof(Coin).Name, typeof(Coin) },
				{typeof(FireFlower).Name, typeof(FireFlower) },
				{typeof(MagicMushroom).Name, typeof(MagicMushroom) },
				{typeof(OneUpMushroom).Name,typeof(OneUpMushroom) },
				{typeof(Starman).Name, typeof(Starman) },
                {typeof(UnderGroundCoin).Name, typeof(UnderGroundCoin) },


                {typeof(Mario).Name, typeof(Mario) },

				{typeof(Fireball).Name, typeof(Fireball) }
			};
		public static Type GetType(string typeName)
		{
			try
			{
				return typeDictionary[typeName];
			}catch(System.Collections.Generic.KeyNotFoundException )
			{
				Debug.WriteLine(typeName + " is not a valid type");
			}
			return null;
		}
        //move to somewhere else late
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public List<int> RandomNumber()
        {
            Random rand = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    number = rand.Next(2,8);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            return listNumbers;
        }

    }
}