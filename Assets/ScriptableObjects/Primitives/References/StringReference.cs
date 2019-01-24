using System;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class StringReference : Reference<string>
	{
		public StringVariable VariableReference;

		public override Variable<string> Variable => VariableReference;
	}
}
