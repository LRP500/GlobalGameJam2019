using ScriptableObjects;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spriteToSpawn;
    public CircleCollider2D spawnArea;
    public GameObject _voidArea;
    public GameObjectReference _runtimeReference;
    
    private void Start()
    {
        _runtimeReference.SetValue(gameObject);
        InstanciateSingle();
    }

    private void Update()
    {
        spawnArea.radius = _voidArea.transform.localScale.x / 3f;
    }

    public void InstanciateSingle()
    {
        Instantiate(spriteToSpawn,
            Random.insideUnitCircle * (spawnArea.radius * 0.9f),
            Quaternion.identity, transform);
    }
}
