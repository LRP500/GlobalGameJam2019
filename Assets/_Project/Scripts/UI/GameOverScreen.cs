using TMPro;
using UnityEngine;
using Variables;

public class GameOverScreen : MonoBehaviour
{
    #region Private Variables

    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private IntVariable _playerScore;
    [SerializeField] private Canvas _canvas;

    #endregion Private Variables

    #region MonoBehaviour

    private void Awake()
    {
        _canvas.enabled = false;
    }

    #endregion MonoBehaviour

    #region Private Methods

    #endregion Private Methods

    #region Public Methods
    
    public void Display(int highscore)
    {
        _highScoreText.text = $"Best: {highscore:n0}".Replace(",", " ");
        _playerScoreText.text = $"Score: {_playerScore.Value:n0}".Replace(",", " ");
        _canvas.enabled = true;
    }

    #endregion Public Methods

}