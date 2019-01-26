﻿using UnityEngine;

namespace GlobalGameJam2019
{
    public class Player : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;
	    [SerializeField] private ScoreUI _scoreUi;

	    private int _score;
	    private int _combo = 1; 
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void OnTriggerEnter2D(Collider2D other)
	    {
		    LightController lc = other.GetComponent<LightController>();

		    if (lc)
		    {
			    float weight = lc.GetWeight();
				_void.Expand(weight, _combo);

			    _score += (int)other.transform.localScale.x;
			    _scoreUi.Display(_score, _combo, other.transform.position);

			    _combo += 1;

			    lc.Destroy();
		    }
	    }

	    #endregion MonoBehaviour
	
		#region Private Methods
		#endregion Private Methods
	
		#region Public Methods

	    public void ComboBreak()
	    {
		    _combo = 1;
	    }
	    
		#endregion Public Methods
    }
}
