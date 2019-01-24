using System;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class FloatReference : Reference<float>
	{
		public FloatVariable VariableReference;

		public override Variable<float> Variable => VariableReference;
	}
}