using Cinemachine;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class MaskController : MonoBehaviour
    {
        [SerializeField] private CinemachineImpulseSource _shake;

        private void Awake()
        {
            _shake = GetComponent<CinemachineImpulseSource>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                _shake.GenerateImpulse();
                player.EnableRepulsion();
            }
        }
    }
}
