using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float thrust;

    public Collider2D trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            body.AddForce(-Vector3.right * thrust);
        }
        if (Input.GetKeyDown("right")) {
            body.AddForce(Vector3.right * thrust);
        }
        if (Input.GetKeyDown("up")) {
            body.AddForce(Vector3.up * thrust);
        }
        if (Input.GetKeyDown("down")) {
            body.AddForce(-Vector3.up * thrust);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Void") {
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
            Vector3 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = - velocity;
        }
    }
}
