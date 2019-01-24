using System;
using UnityEngine;
using Variables;

namespace ScriptableObjects.References
{
	[Serializable]
	public class Vector3Reference : Reference<Vector3>
	{
		public Vector3Variable VariableReference;

		public override Variable<Vector3> Variable => VariableReference;
	}
}
