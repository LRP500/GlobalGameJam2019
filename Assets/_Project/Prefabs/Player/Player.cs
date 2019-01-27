using UnityEngine;
using Variables;

namespace GlobalGameJam2019
{
    public class Player : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private Void _void;
	    [SerializeField] private ScoreUI _scoreUi;
	    [SerializeField] private IntVariable _score;
	    [SerializeField] private IntVariable _combo;
        [SerializeField] private SimpleAudioEvent _event;

	    private int _prevCombo = 1;
	    
		#endregion Private Variables
	
		#region MonoBehaviour

	    private void Start()
	    {
		    _score.SetValue(0);
		    _combo.SetValue(1);
	    }

	    private void OnTriggerEnter2D(Collider2D other)
	    {
		    LightController lc = other.GetComponent<LightController>();

		    if (lc)
		    {
			    float weight = lc.GetWeight();
				_void.Expand(weight, _combo);

			    _score.SetValue(_score + (int)other.transform.localScale.x * _combo);
			    _scoreUi.Display(_score, _combo, other.transform.position);
			    _combo.SetValue(_combo + 1);
                _prevCombo = _combo.Value;

			    lc.Destroy();
		    }
	    }

        #endregion MonoBehaviour

        #region Private Methods
        #endregion Private Methods

        #region Public Methods

        public void ComboBreak()
	    {
            if (_prevCombo != _combo.Value)
            {
                _event.Play(GetComponent<AudioSource>());
                _prevCombo = _combo.Value;
            }
            _combo.SetValue(1);
        }

        #endregion Public Methods
    }
}
