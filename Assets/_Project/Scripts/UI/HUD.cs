using TMPro;
using UnityEngine;
using Variables;

public class HUD : MonoBehaviour
{
	#region Private Variables

	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private TextMeshProUGUI _comboText;

	[SerializeField] private IntVariable _score;
	[SerializeField] private IntVariable _combo;

	#endregion Private Variables

	#region MonoBehaviour

	private void Update()
	{
		_scoreText.text = $"{_score.Value:n0}".Replace(",", " ");
		_comboText.text = "." + _combo.Value;
	}

	#endregion MonoBehaviour

	#region Private Methods

	#endregion Private Methods

	#region Public Methods

	#endregion Public Methods
}