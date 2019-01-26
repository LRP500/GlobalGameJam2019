using Cinemachine;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class MaskController : MonoBehaviour
    {
        [SerializeField] private CinemachineImpulseSource _shake;
        [SerializeField] private ParticleSystem _particules;

        private void Awake()
        {
            _shake = GetComponent<CinemachineImpulseSource>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                _particules.transform.position = other.transform.position;
                _particules.Play();
                
                _shake.GenerateImpulse();
                player.EnableRepulsion();
            }
        }
    }
}
