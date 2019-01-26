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

            var sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(0.08627451f, 0.509804f, 0.9843138f, 0.09411765f);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(0.08627451f, 0.509804f, 0.9843138f, 0.03921569f);
        }

        #endregion MonoBehaviour

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}
