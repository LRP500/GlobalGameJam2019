using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            if (_event) _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (_event) _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            _response?.Invoke();
        }
    }
}