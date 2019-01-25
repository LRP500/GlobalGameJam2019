using UnityEngine;

namespace GlobalGameJam2019
{
    public class Player : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void OnTriggerEnter2D(Collider2D other)
	    {
		    LightController lc = other.GetComponent<LightController>();

		    if (lc)
		    {
			    float weight = lc.GetWeight();
				_void.Expand(weight);
			    Destroy(other.gameObject);
		    }
	    }

	    #endregion MonoBehaviour
	
		#region Private Methods
		#endregion Private Methods
	
		#region Public Methods
		#endregion Public Methods
    }
}
