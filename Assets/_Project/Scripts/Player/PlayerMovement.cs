using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translationX = Input.GetAxis("Horizontal") * _speed;
        float translationY = Input.GetAxis("Vertical") * _speed;

        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;

        transform.Translate(translationX, translationY, 0);
    }
}