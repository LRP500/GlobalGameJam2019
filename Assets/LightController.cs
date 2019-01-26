using UnityEngine;
using Variables;

[RequireComponent(typeof(CircleCollider2D))]
public class LightController : MonoBehaviour
{
    [SerializeField]
    private float _weight;
    
    [MinMaxRange(1, 100)]
    public FloatRange _size = new FloatRange(0, 0);

    [Space]
    [SerializeField]
    private IntVariable _playerScore;

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
