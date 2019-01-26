using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LightController : MonoBehaviour
{
    [SerializeField] private float _weight;

    [MinMaxRange(4, 25)] public FloatRange _size = new FloatRange(4, 20);
    
    private CircleCollider2D _collider;
    
    private void Start()
    {
        var scale = Random.Range(_size.Min, _size.Max);
        transform.localScale = new Vector3(scale, scale, 0);
        _collider = gameObject.AddComponent<CircleCollider2D>();
        _collider.isTrigger = true;
    }

    public float GetWeight()
    {
        return _collider.radius * _weight;
    }
}
