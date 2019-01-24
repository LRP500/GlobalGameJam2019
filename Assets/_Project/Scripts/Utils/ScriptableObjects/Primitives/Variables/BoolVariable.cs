using UnityEngine;

namespace Variables
{
	[CreateAssetMenu(menuName = "Variables/Bool")]
	public class BoolVariable : Variable<bool>
	{
		public void Or(bool value)
		{
			Value |= value;
		}

		public void Or(BoolVariable variable)
		{
			Value |= variable.Value;
		}
		
		public void And(bool value)
		{
			Value &= value;
		}

		public void And(BoolVariable variable)
		{
			Value &= variable.Value;
		}
	}
}
