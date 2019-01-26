using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spriteToSpawn;
    public CircleCollider2D spawnArea;
    public CircleCollider2D safeArea;
    public GameObject _voidArea;
    public GameObjectReference _runtimeReference;

    private List<GameObject> _spheres =  new List<GameObject>();
    
    [Range(0, 1)] public float _doubleSpawnProbability = .3f;
    [Range(0, 1)] public float _randomSpawn = .01f;

    private void Start()
    {
        _runtimeReference.SetValue(gameObject);
        InstanciateSingle();
    }

    private void Update()
    {
        spawnArea.radius = _voidArea.transform.localScale.x / 2f;
        if (Random.value < _randomSpawn) InstanciateSingle();
    }

    public void DestroySphere(LightController sphere)
    {
        if (_spheres.Count != 1)
        {
            _spheres.Remove(sphere.gameObject);
            Destroy(sphere.gameObject);
        }
    }
    
    public void InstanciateSingle()
    {
        var max = (spawnArea.radius * 0.9f);
        var min = (safeArea.radius + safeArea.radius * 0.5f);
        var sphere = Instantiate(spriteToSpawn,
            Random.insideUnitCircle * ((max-min) + min),
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
