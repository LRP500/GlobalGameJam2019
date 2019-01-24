using UnityEngine;

namespace Variables
{
	[CreateAssetMenu(menuName = "Variables/Vector2")]
	public class Vector2Variable : Variable<Vector2>
	{
		public void Add(Vector2 value)
		{
			Value += value;
		}

		public void Add(Vector2Variable variable)
		{
			Value += variable.Value;
		}
	}
}
