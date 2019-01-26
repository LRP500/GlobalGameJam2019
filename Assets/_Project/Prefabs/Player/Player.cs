using Cinemachine;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class Player : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;
	    [SerializeField] private ScoreUI _scoreUi;
	    
	    private int _score = 0;
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void OnTriggerEnter2D(Collider2D other)
	    {
		    LightController lc = other.GetComponent<LightController>();

		    if (lc)
		    {
			    float weight = lc.GetWeight();
				_void.Expand(weight);
			    
			    _score += (int)other.transform.localScale.x;
			    _scoreUi.Display(_score, other.transform.position);
			    
			    lc.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
			    
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
