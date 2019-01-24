using System;
using UnityEngine;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class Vector2Reference : Reference<Vector2>
	{
		public Vector2Variable VariableReference;

		public override Variable<Vector2> Variable => VariableReference;
	}
}
