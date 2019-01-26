using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 300f;
    [SerializeField] private float _gravity = 200f;

    private Rigidbody2D rigidbody;
    private bool repulsionSetted = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector3 speed = new Vector3(1, 1, 1);
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