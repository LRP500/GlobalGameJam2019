using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Public variables
    public GameObject spriteToSpawn;
    public CircleCollider2D spawnArea;
    public uint _maxCount = 10;

    public GameObject _voidArea;
    
    private List<GameObject> _lights = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _maxCount; i++)
        {
            InstanciateSingle();
        }
    }

    private void Update()
    {
        spawnArea.radius = _voidArea.transform.localScale.x / 3f;
        
        foreach (GameObject lightObject in _lights)
        {
            if (lightObject == null)
            {
                _lights.Remove(lightObject);
                InstanciateSingle();
                return;
            }
        }
    }

    private void InstanciateSingle()
    {
        var instance = Instantiate(spriteToSpawn, Random.insideUnitCircle * spawnArea.radius,
            Quaternion.identity, transform);
        _lights.Add(instance);
    }
}
