using System.Collections;
using Cinemachine;
using ScriptableObjects;
using UnityEngine;
using Variables;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private float _weight;
    
    [MinMaxRange(1, 100)]
    public FloatRange _size = new FloatRange(0, 0);

    [Space]
    [SerializeField]
    private IntVariable _playerScore;

    [SerializeField] private ParticleSystem _particles;

    [SerializeField] private GameObjectReference _spawnController;
    
    private CircleCollider2D _collider;
    
    private void Start()
    {
        var scale = Random.Range(_size.Min, _size.Max);
        transform.localScale = new Vector3(scale, scale, 0);
        _collider = gameObject.AddComponent<CircleCollider2D>();
        _collider.isTrigger = true;
    }

    public void Destroy()
    {
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        _spawnController.Value.GetComponent<SpawnController>().InstanciateSingle();
        _particles.Play();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
    public float GetWeight()
    {
        return _collider.radius * _weight;
    }
}
