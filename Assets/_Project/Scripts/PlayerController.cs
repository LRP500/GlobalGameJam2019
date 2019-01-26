

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float thrust;
    public float speed;
    public ParticleSystem ps;

    private void Update()
    {
       // if (Input.GetKeyDown("left")) body.AddForce(-Vector3.right * thrust);
       // if (Input.GetKeyDown("right")) body.AddForce(Vector3.right * thrust);
       // if (Input.GetKeyDown("up")) body.AddForce(Vector3.up * thrust);
       // if (Input.GetKeyDown("down")) body.AddForce(-Vector3.up * thrust);

        Vector3 translation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        translation.Normalize();
        body.AddForce(translation * speed);

        ParticleSystem.MainModule ma = ps.main;

        Debug.Log("Speed + " + body.velocity.magnitude);

        ma.startColor = new Color(body.velocity.magnitude / 300, 0, 0, 1.0f);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            Vector3 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = - velocity;
        }
    }
}
