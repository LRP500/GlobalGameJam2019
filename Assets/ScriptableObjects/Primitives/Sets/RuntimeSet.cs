using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Sets
{	
	public abstract class RuntimeSet<T> : ScriptableObject
	{
		[SerializeField]
		private List<T> _items = new List<T>();

		public List<T> Items => _items;

		public void Add(T thing)
		{
			if (!_items.Contains(thing))
			{
				_items.Add(thing);
			}
		}

		public void Remove(T thing)
		{
			if (_items.Contains(thing))
			{
				_items.Remove(thing);
			}
		}
	}
}
