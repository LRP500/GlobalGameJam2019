using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D collider;

    public Transform prefab;
    public float scale = 1.0f;

    public float thrust = 300.0f;
    public float speed = 300.0f;

    public float minScale = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { }

    void SetScale(float newScale) {
        scale = newScale;
        transform.localScale = new Vector3(scale, scale, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Protector")
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;

            Vector3 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector3 side = Vector3.Cross(dir, -transform.right);
            Vector3 cross = Vector3.Cross(dir, side);

            Vector3 normal = cross.normalized;

            if (scale > minScale) {
                Transform clone = Instantiate(prefab, new Vector3(x, y, -1), Quaternion.identity);
                clone.gameObject.GetComponent<AsteroidController>().SetScale(scale / 2);
                clone.gameObject.GetComponent<Rigidbody2D>().velocity = normal * thrust;
                float mass = clone.gameObject.GetComponent<Rigidbody2D>().mass;
                clone.gameObject.GetComponent<Rigidbody2D>().mass = mass / 2;

                Transform clone2 = Instantiate(prefab, new Vector3(x, y, -1), Quaternion.identity);
                clone2.gameObject.GetComponent<AsteroidController>().SetScale(scale / 2);
                clone2.gameObject.GetComponent<Rigidbody2D>().velocity = -normal * thrust;
                mass = clone2.gameObject.GetComponent<Rigidbody2D>().mass;
                clone2.gameObject.GetComponent<Rigidbody2D>().mass = mass / 2;
            }
            this.Destroy();
        }
    }

    void Destroy() {
        Destroy(gameObject);
    }
}
