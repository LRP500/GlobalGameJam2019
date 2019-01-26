using System.Collections;
using TMPro;
using UnityEngine;
using Variables;

namespace GlobalGameJam2019
{
    public class ScoreUI : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private TextMeshProUGUI _scoreText;
	    [SerializeField] private float _sourceRadius = 10;
	    [SerializeField] private float _displayTime = 2f;

	    #endregion Private Variables

	    #region MonoBehaviour

	    #endregion MonoBehaviour

	    #region Private Methods

	    private void Awake()
	    {
		    _scoreText.enabled = false;
	    }

	    private IEnumerator DisplayScore(Vector3 source)
	    {
		    _scoreText.enabled = true;
		    Vector2 position = (Vector2)source + (Random.insideUnitCircle * _sourceRadius);
		    _scoreText.gameObject.transform.position = Camera.main.WorldToScreenPoint(position);
		    yield return new WaitForSeconds(_displayTime);
		    _scoreText.enabled = false;
	    }
	    
	    #endregion Private Methods

	    #region Public Methods

	    public void Display(int score, Vector3 source)
	    {
		    _scoreText.text = score.ToString();
		    StartCoroutine(DisplayScore(source));
	    }
	    
	    #endregion Public Methods
    }
}
