using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _shrinkSpeed;
    void Start()
    {
        
    }

  void FixedUpdate()
  {
    Vector3 scale = transform.localScale;
    scale.x -= _shrinkSpeed * Time.deltaTime;
    scale.y -= _shrinkSpeed * Time.deltaTime;
    transform.localScale = scale;
  }
}
