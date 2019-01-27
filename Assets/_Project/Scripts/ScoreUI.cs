using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace GlobalGameJam2019
{
    public class ScoreUI : MonoBehaviour
    {
		#region Private Variables

	    [SerializeField] private TextMeshProUGUI _scoreText;
	    [SerializeField] private float _sourceRadius = 10;
	    [SerializeField] private float _displayTime = 2f;

	    private StringBuilder _builder;

	    private Vector3 _scale = Vector3.one;
	    
	    #endregion Private Variables

	    #region MonoBehaviour

	    private void Awake()
	    {
		    _builder = new StringBuilder();
		    _scoreText.enabled = false;
		    _scoreText.transform.localScale = _scale;
	    }
	    
	    #endregion MonoBehaviour

	    #region Private Methods

	    private IEnumerator DisplayScore(Vector3 source)
	    {
		    _scoreText.enabled = true;
		    Vector2 position = (Vector2)source + (Random.insideUnitCircle * _sourceRadius);
		    _scoreText.gameObject.transform.position = position;

		    yield return new WaitForSeconds(_displayTime);
		    
		    _scoreText.enabled = false;
	    }
	    
	    #endregion Private Methods

	    #region Public Methods

	    public void Display(int score, int combo, Vector3 source)
	    {
		    var scale = _scale + (_scale * (combo / 20f));
		    _scoreText.transform.localScale = new Vector3(
			    Mathf.Clamp(scale.x, 1, 10), Mathf.Clamp(scale.y, 1, 10), scale.z);
		    _builder.Clear();
		    _builder.AppendFormat("x{0}", combo);
		    _scoreText.text = _builder.ToString();
		    StartCoroutine(DisplayScore(source));
	    }
	    
	    #endregion Public Methods
    }
}
