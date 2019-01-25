using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_enemy : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
