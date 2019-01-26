using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spriteToSpawn;
    public CircleCollider2D spawnArea;
    public GameObject _voidArea;
    public GameObjectReference _runtimeReference;

    private List<GameObject> _spheres =  new List<GameObject>();
    
    [Range(0, 1)] public float _doubleSpawnProbability = .3f;

    
    private void Start()
    {
        _runtimeReference.SetValue(gameObject);
        InstanciateSingle();
    }

    private void Update()
    {
        spawnArea.radius = _voidArea.transform.localScale.x / 3f;
    }

    public void DestroySphere(LightController sphere)
    {
        if (_spheres.Count > 1)
        {
            _spheres.Remove(sphere.gameObject);
            Destroy(sphere.gameObject);
        }
    }
    
    public void InstanciateSingle()
    {
        var sphere = Instantiate(spriteToSpawn,
            Random.insideUnitCircle * (spawnArea.radius * 0.9f),
            Quaternion.identity, transform);
        _spheres.Add(sphere);

        if (Random.value < _doubleSpawnProbability)
        {
            sphere = Instantiate(spriteToSpawn,
                Random.insideUnitCircle * (spawnArea.radius * 0.9f),
                Quaternion.identity, transform);
            _spheres.Add(sphere);
        }
    }
}
