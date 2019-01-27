using Extensions;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class SafeZone : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;

	    private Color _color;
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void Awake()
	    {
		    _color = GetComponent<SpriteRenderer>().color;
	    }

	    private void OnTriggerEnter2D(Collider2D other)
	    {
            var sprite = GetComponent<SpriteRenderer>();
		    Color newColor = _color;
		    newColor.a *= 2;
	        sprite.color = newColor;
	    }

        private void OnTriggerExit2D(Collider2D other)
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.color = _color;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();
            if (player)
            {
                player.ComboBreak();
            }
        }

        #endregion MonoBehaviour

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}
