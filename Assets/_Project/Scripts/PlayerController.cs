using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;

    public float maxSpeed;

    public Collider2D trigger;

  private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        return ;
        Vector3 velocity = body.velocity;
        if (velocity.magnitude > maxSpeed) {
            body.velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            body.AddForce(-Vector3.right * thrust);
            //body.velocity = Vector3.ClampMagnitude(-Vector3.right, thrust);
        }
        if (Input.GetKeyDown("right")) {
            body.AddForce(Vector3.right * thrust);
            //body.velocity = Vector3.ClampMagnitude(Vector3.right, thrust);
        }
        if (Input.GetKeyDown("up")) {
            body.AddForce(Vector3.up * thrust);
            //body.velocity = Vector3.ClampMagnitude(Vector3.up, thrust);
        }
        if (Input.GetKeyDown("down")) {
            body.AddForce(-Vector3.up * thrust);
            //body.velocity = Vector3.ClampMagnitude(-Vector3.up, thrust);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Void") {
            Vector3 velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
            //transform.position = new Vector3(transform.position.x, transform.position.y, -7);
            gameObject.GetComponent<Rigidbody2D>().velocity = -velocity * 2;
            //Vector3 point = other.gameObject.GetComponent<Collider2D>().Close(transform.position);
            //Debug.Log(point);
        }
    }
}
