using System;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class IntReference: Reference<int>
	{
		public IntVariable VariableReference;

		public override Variable<int> Variable => VariableReference;
	}
}
