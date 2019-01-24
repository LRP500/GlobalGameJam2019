using UnityEngine;

namespace ScriptableObjects.Events
{
    public class EventRaiser : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;

        public void RaiseEvent()
        {
            if (_event) _event.Raise();
        }
    }    
}
