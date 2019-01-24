using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(menuName = "Variables/Float")]
    public class FloatVariable : Variable<float>
    {
        public void Add(float value)
        {
            Value += value;
        }

        public void Add(FloatVariable variable)
        {
            Value += variable.Value;
        }
    }
}
