

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float thrust;

    private void Update()
    {
        if (Input.GetKeyDown("left")) body.AddForce(-Vector3.right * thrust);
        if (Input.GetKeyDown("right")) body.AddForce(Vector3.right * thrust);
        if (Input.GetKeyDown("up")) body.AddForce(Vector3.up * thrust);
        if (Input.GetKeyDown("down")) body.AddForce(-Vector3.up * thrust);
    }
}
