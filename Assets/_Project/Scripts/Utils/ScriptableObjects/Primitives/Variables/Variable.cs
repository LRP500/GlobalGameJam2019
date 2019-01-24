using UnityEngine;

namespace Variables
{
	public abstract class Variable<T> : ScriptableObject
	{
	#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription;
	#endif

		[SerializeField] private T _value;
		public T Value { get { return _value; } protected set { _value = value; } }

		public System.Action<T> OnValueChange = null;
		
		public virtual void SetValue(T value)
		{
			Value = value;
			OnValueChange?.Invoke(Value);
		}

		public virtual void SetValue(Variable<T> variable)
		{
			Value = variable.Value;
			OnValueChange?.Invoke(Value);
		}
				
		public static implicit operator T(Variable<T> variable)
		{
			return variable == null ? default(T) : variable.Value;
		}
	}
}