using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _friction = 0.9f;

    private Rigidbody2D rigidbody;
    private Vector3 prevSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        prevSpeed = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravity = new Vector3(-transform.position.x, -transform.position.y, 0);
        gravity.Normalize();
        gravity *= _gravity;
        Vector3 translation = new Vector3(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed, 0);
        Vector3 speed = (gravity + translation + (prevSpeed * _friction));
        Vector3 friction = -gravity * _friction;

        transform.Translate(speed);
        //rigidbody.AddForce(friction);
        prevSpeed = speed;
    }
}