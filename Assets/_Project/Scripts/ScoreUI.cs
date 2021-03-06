﻿using System.Collections;
using System.Text;
using Extensions;
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
	    [SerializeField] private TextMeshProUGUI _comboBreak;

	    private StringBuilder _builder;

	    private Vector3 _scale = Vector3.one;
	    
	    #endregion Private Variables

	    #region MonoBehaviour

	    private void Awake()
	    {
		    _builder = new StringBuilder();
		    _scoreText.enabled = false;
		    _scoreText.transform.localScale = _scale;

		    if (_comboBreak)
		    {
			    _comboBreak.transform.rotation = Quaternion.identity;			    
				_comboBreak.enabled = false;
		    }
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
			    Mathf.Clamp(scale.x, 1, 5), Mathf.Clamp(scale.y, 1, 5), scale.z);
		    _builder.Clear();
		    _builder.AppendFormat("x{0}", combo);
		    _scoreText.text = _builder.ToString();
		    StartCoroutine(DisplayScore(source));
	    }

	    public void DisplayComboBreak()
	    {
		    if (_comboBreak.enabled == false)
		    {
			    Vector3 rotation = _comboBreak.transform.localEulerAngles;
			    rotation.z = Random.Range(-60, 60);
			    _comboBreak.transform.localEulerAngles = rotation;
			    _comboBreak.transform.position = Random.insideUnitCircle * 50;
			    _comboBreak.fontSize = Random.Range(180, 200);
			    StartCoroutine(ComboBreak());			    
		    }
	    }

	    private IEnumerator ComboBreak()
	    {
		    _comboBreak.enabled = true;
		    yield return new WaitForSeconds(Random.Range(.5f, 1));
		    _comboBreak.enabled = false;
	    }

	    #endregion Public Methods
    }
}
