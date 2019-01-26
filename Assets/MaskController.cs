using Cinemachine;
using ScriptableObjects;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class MaskController : MonoBehaviour
    {
        [SerializeField] private CinemachineImpulseSource _shake;
        [SerializeField] private ParticleSystem _particules;
        [SerializeField] private float _repulsionForce = 200;
        
        private void Awake()
        {
            _shake = GetComponent<CinemachineImpulseSource>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                var dir = Vector2.zero - (Vector2)player.transform.position;
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                rb.AddForce(dir.normalized * _repulsionForce, ForceMode2D.Impulse);

                JuiceThatShitUp(other.transform.position);
            }
        }
        
        private void JuiceThatShitUp(Vector3 position)
        {
            _particules.transform.position = position;
            _particules.Play();
            _shake.GenerateImpulse();
        }
    }
}
