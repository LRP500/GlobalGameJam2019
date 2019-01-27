

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float thrust;

    private bool maskCollision = false;
    private bool gamepadEnabled = false;

    private bool jump = false;
    private bool prevJump = false;

    public void EnableMaskCollision()
    {
        maskCollision = true;
    }

    public void DisableMaskCollision()
    {
        maskCollision = false;
    }

    private void Start()
    {
        gamepadEnabled = Input.GetJoystickNames().Length > 0;
    }

    private void Update()
    {
        if (!gamepadEnabled)
        {
            if (!maskCollision)
            {
                if (Input.GetKeyDown("left")) body.AddForce(-Vector3.right * thrust);
                if (Input.GetKeyDown("right")) body.AddForce(Vector3.right * thrust);
                if (Input.GetKeyDown("up")) body.AddForce(Vector3.up * thrust);
                if (Input.GetKeyDown("down")) body.AddForce(-Vector3.up * thrust);
            }
        }
        else
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            jump = Input.GetAxis("Jump") > 0;
            if (prevJump != jump)
            {
                var dir = new Vector2(h, v) * thrust;
                body.AddForce(dir);
            }
            prevJump = jump;
        }
    }
}
