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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.disableRepulsion();
            }
	    }

	    private void OnTriggerExit2D(Collider2D other)
	    {
		    if (other.GetComponent<Player>() != null) _void.enabled = true;
	    }

	    #endregion MonoBehaviour
	
		#region Private Methods
		#endregion Private Methods
	
		#region Public Methods
		#endregion Public Methods
    }
}
