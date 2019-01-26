using UnityEngine;

namespace GlobalGameJam2019
{
    public class Void : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private GameObject _mask;
	    [SerializeField] private float _shrinkSpeed;

		#endregion Private Variables
	
		#region MonoBehaviour

	    private void Update()
	    {
		    if (Input.GetKeyDown(KeyCode.Space)) Expand(10, 1);
		    Shrink();

		    _shrinkSpeed += Time.deltaTime;
	    }

	    #endregion MonoBehaviour
	
		#region Private Methods
		#endregion Private Methods
	
		#region Public Methods

	    public Vector3 GetMaskScale() { return _mask.transform.localScale; }

	    private void Shrink()
	    {
		    Vector3 scale = _mask.transform.localScale;
		    scale.x -= _shrinkSpeed * Time.deltaTime;
		    scale.y -= _shrinkSpeed * Time.deltaTime;
		    _mask.transform.localScale = scale;		    
	    }
	    
	    public void Expand(float value, float ratio)
	    {
		    Vector3 scale = _mask.transform.localScale;
		    scale.x += value + ratio;
		    scale.y += value + ratio;
		    _mask.transform.localScale = scale;
	    }
	    
		#endregion Public Methods
    }
}
