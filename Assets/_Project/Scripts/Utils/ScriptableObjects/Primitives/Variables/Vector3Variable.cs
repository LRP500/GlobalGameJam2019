using UnityEngine;

namespace Variables
{
	[CreateAssetMenu(menuName = "Variables/Vector3")]
	public class Vector3Variable : Variable<Vector3>
	{
		public void Add(Vector3 value)
		{
			Value += value;
		}

		public void Add(Vector3Variable variable)
		{
			Value += variable.Value;
		}
	}
}
