using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 300f;
    [SerializeField] private float _gravity = 200f;

    private Rigidbody2D rigidbody;
    private bool repulsionSetted = true;
    private bool startMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void EnableRepulsion()
    {
        repulsionSetted = true;
    }

    public void DisableRepulsion()
    {
        repulsionSetted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.01 || System.Math.Abs(Input.GetAxis("Vertical")) > 0.01)
        {
            startMove = true;
        }
        else if (System.Math.Abs(transform.position.x) < 5 && System.Math.Abs(transform.position.y) < 5)
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = new Vector3(0, 0, transform.position.z);
            startMove = false;
        }

        if (startMove)
        {
            Vector3 gravity = new Vector3(-transform.position.x, -transform.position.y, 0);
            gravity.Normalize();
            gravity *= _gravity;
            Vector3 translation = new Vector3(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed, 0);
            Vector3 speed = (gravity + translation);

            if (repulsionSetted)
            {
                speed = gravity;
            }
            rigidbody.velocity = speed;
        }
    }
}