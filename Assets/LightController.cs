using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightController : MonoBehaviour
{
    // Public variables
    public UnityEvent<float> _event;

    // Private variables
    private CircleCollider2D circleCollider = null;

    // Start is called before the first frame update
    void Start()
    {
        this.circleCollider = this.GetComponent<CircleCollider2D>();
        if (this.circleCollider == null)
        {
            Debug.LogError("No CircleCollider2D found.", this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _event.Invoke(this.circleCollider.radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
