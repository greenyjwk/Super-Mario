using Game1;
using Mario.GameObjects.Block;
using Mario.Interfaces.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Mario.Collections
{
	//collection is structured to be dependent on features of IGameObject interface. Cannot be managed for a generic type of object
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface")]
	public class GameObjectList : IEnumerable
	{
        private static IDictionary<Type, List<IGameObject>> gameObjectListsByType;

		public GameObjectList()
		{
     
        }
        public void Initial()
        {
            gameObjectListsByType = new Dictionary<Type, List<IGameObject>>{
                {typeof(IPipe), new List<IGameObject>() },
                {typeof(IBackground), new List<IGameObject>() },
                {typeof(IItem),new List<IGameObject>() },
                {typeof(IBlock), new List<IGameObject>() },
                {typeof(IProjectile), new List<IGameObject>() },
                {typeof(IEnemy), new List<IGameObject>() },
                {typeof(IMario),new List<IGameObject>() }
            };
        }
        public void DisplayElementsToConsole()
		{
			Debug.WriteLine("Entries in  list: " + gameObjectListsByType.Count);
			foreach (KeyValuePair<Type, List<IGameObject>> pair in gameObjectListsByType)
			{
				Debug.WriteLine(pair.Key.ToString() + ", " + pair.Value.Count);
			}
		}
		public void Add(IGameObject obj)
		{
			Type gameObjectInheritorType = typeof(IGameObject);
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(obj.GetType()))
				{
					gameObjectInheritorType = typeListPair.Key;
					break;
				}
			}
			gameObjectListsByType[gameObjectInheritorType].Add(obj);
		}

		public void AddListByType(Type T, IList<IGameObject> gameObjectList)
		{
			gameObjectListsByType[T].AddRange(gameObjectList);
		}
		public void Remove(IGameObject obj)
		{
			Type gameObjectInheritorType = typeof(IGameObject);
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(obj.GetType())) {
					gameObjectInheritorType = typeListPair.Key;
					break;
				}
			}
			gameObjectListsByType[gameObjectInheritorType].Remove(obj);
		}

		//requires specific IGameObject subinterface
		public int Count(Type T)
		{
			return gameObjectListsByType[T].Count;
		}
		public IGameObject GetGameObject(IGameObject target)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					
						return typeListPair.Value[typeListPair.Value.IndexOf(target)];
					
				}
			}
			return null;
		}
		public void SetGameObject(IGameObject target, IGameObject value)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					
						typeListPair.Value[typeListPair.Value.IndexOf(target)] = value;
				
				}
			}
		}

		public bool HasObject(IGameObject target)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					
						return typeListPair.Value.IndexOf(target)>0 ;
					
				}
			}
			return false;
		}
		public IGameObject SwapGameObject(IGameObject target, IGameObject value)
		{
			IGameObject temp = GetGameObject(target);
			SetGameObject(target, value);
			return temp;
		}
		public IGameObject Peek(Type T)
		{
			IGameObject obj = null;
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(T))
				{
					
						obj = gameObjectListsByType[typeListPair.Key][0];
						break;
					
					
				}
			}
			return obj;
		}
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public IGameObject GameObjectEnumeratorInterfaceOfValue(Type value)
        {
            IGameObject obj = null;
            foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
            {
                for (int i= 0;i< gameObjectListsByType[typeListPair.Key].Count;i++)
                if (typeListPair.Key.IsAssignableFrom(value)&& value.Equals(gameObjectListsByType[typeListPair.Key][i].GetType()))
                {

                        obj = gameObjectListsByType[typeListPair.Key][i];
                        break;
                }
            }
            return obj;
        }
        public override string ToString()
		{
			return base.ToString();
		}
		public void SetSingleton(Type T, IGameObject obj)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(T))
				{
					
						gameObjectListsByType[typeListPair.Key][0] = obj;
						break;
					
				}
			}
		}
		public IEnumerator GetEnumerator()
		{
			return new GameObjectEnumerator();
		}

		public IEnumerator GetEnumeratorByType(Type T)
		{
			if (!typeof(IGameObject).IsAssignableFrom(T))
			{
				Debug.WriteLine("nonvalid enum type");
			}
			return new GameObjectEnumeratorByType(T);
		}

		//see head of class document for why this document needs to be strongly typed
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1038:EnumeratorsShouldBeStronglyTyped")]
		public class GameObjectEnumerator : IEnumerator
		{
			int currentIndex;
			IEnumerator<KeyValuePair<Type,List<IGameObject>>> gameObjectTypesEnumerator;
			public GameObjectEnumerator()
			{
				gameObjectTypesEnumerator = gameObjectListsByType.GetEnumerator();
				if (gameObjectTypesEnumerator.MoveNext())
				{
					currentIndex = gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count;
				}
			}
			public object Current => gameObjectListsByType[(gameObjectTypesEnumerator.Current.Key)][currentIndex];

			public bool MoveNext()
			{
				bool hasNext;
				do
				{
					hasNext = false;
					do
					{
						currentIndex--;
					} while (currentIndex >= gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count);
					if (currentIndex < 0)
					{
						hasNext = gameObjectTypesEnumerator.MoveNext();
						if (!hasNext)
						{
							return false;
						}
						currentIndex = gameObjectListsByType[(gameObjectTypesEnumerator.Current.Key)].Count;
					}
				}while (hasNext);
				return true;
			}

			public void Reset()
			{
				currentIndex = gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count;
                gameObjectTypesEnumerator.Reset();
            }

		}
		//see head of document for reason why document must be strongly typed
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1038:EnumeratorsShouldBeStronglyTyped")]
		public class GameObjectEnumeratorByType : IEnumerator
		{
			
			private int currentIndex;
			private readonly Type type;

			public GameObjectEnumeratorByType(Type type)
			{
				this.type = type;
				this.currentIndex = gameObjectListsByType[type].Count;
			}
          

            public object Current
			{
				get
				{
					try
					{
						return gameObjectListsByType[type][currentIndex];
					}
					catch (ArgumentOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}

			public bool MoveNext()
			{
				do
				{
					currentIndex--;
				} while (currentIndex >= gameObjectListsByType[type].Count);
				return (currentIndex >= 0);
			}

			public void Reset()
			{
				currentIndex = gameObjectListsByType[type].Count;
			}
		}

	}


}
