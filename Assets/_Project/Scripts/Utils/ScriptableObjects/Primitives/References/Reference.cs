using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace ScriptableObjects.References
{
    public abstract class Reference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public virtual Variable<T> Variable => null;

        public Reference() {}

        public Reference(T value) : this()
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public T Value
        {
            get { return UseConstant ? ConstantValue : Variable; }
            set 
            {
                if (UseConstant) ConstantValue = value;
                else Variable.SetValue(value);
            }
        }


        public static implicit operator T(Reference<T> reference)
        {
            return reference.Value;
        }
    }
}
