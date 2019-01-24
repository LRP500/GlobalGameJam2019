using UnityEngine;

namespace Variables
{
	[CreateAssetMenu(menuName = "Variables/Int")]
	public class IntVariable : Variable<int>
	{
		public void Add(int value)
		{
			Value += value;
		}

		public void Add(IntVariable variable)
		{
			Value += variable.Value;
		}
	}
}
