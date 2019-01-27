using TMPro;
using UnityEngine;
using Variables;

public class GameOverScreen : MonoBehaviour
{
    #region Private Variables

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private IntVariable _scoreData;
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

    #endregion Public Methods

    public void Display()
    {
        _scoreText.text = $"Score: {_scoreData.Value}";
        _canvas.enabled = true;
    }
}