using UnityEngine;

namespace GlobalGameJam2019
{
    public class SafeZone : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void OnTriggerEnter2D(Collider2D other)
	    {
		    var player = other.GetComponent<Player>();
		    if (player) player.ComboBreak();
	    }

	    #endregion MonoBehaviour
	
		#region Private Methods
		#endregion Private Methods
	
		#region Public Methods
		#endregion Public Methods
    }
}
