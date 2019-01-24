using System;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class BoolReference : Reference<bool>
	{
		public BoolVariable VariableReference;

		public override Variable<bool> Variable => VariableReference;
	}
}
