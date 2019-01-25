using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // Public variables
    public GameObject spriteToSpawn;
    public CircleCollider2D spawnArea;
    public uint numberOfSprites = 10;

    // Private variables
    private uint currentNumOfSprites = 0;

    // Spawns numberOfSprites spriteToSpawn game objects
    void SpawnObjects()
    {
        for (uint i = currentNumOfSprites; i < numberOfSprites; i++)
        {
            Instantiate(spriteToSpawn, Random.insideUnitCircle * spawnArea.radius, Quaternion.identity, this.transform);
            currentNumOfSprites++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
