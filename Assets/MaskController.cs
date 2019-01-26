using System.Collections;
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
        [SerializeField] private float _inputFreezeDelay = .05f;

        private void Awake()
        {
            _shake = GetComponent<CinemachineImpulseSource>();
        }

        IEnumerator CollideWithPlayer(PlayerController player)
        {
            player.EnableMaskCollision();
            yield return new WaitForSeconds(_inputFreezeDelay);
            player.DisableMaskCollision();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                var dir = Vector2.zero - (Vector2)player.transform.position;
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                rb.AddForce(dir.normalized * _repulsionForce, ForceMode2D.Impulse);

                // No more out
                Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                position.Normalize();
                position *= transform.localScale.x / 2;
                player.transform.position = position;

                JuiceThatShitUp(other.transform.position);
                StartCoroutine(CollideWithPlayer(player));
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
