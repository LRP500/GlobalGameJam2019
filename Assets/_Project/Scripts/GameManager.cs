using UnityEngine;
using UnityEngine.Events;

namespace GlobalGameJam2019
{
    public class GameManager : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private Void _void;
        [SerializeField] private SafeZone _safeZone;
        [SerializeField] private GameObject _gameOverScreen;
        
        #endregion Private Variables

        #region MonoBehaviour

        private void Awake()
        {
            Time.timeScale = 1;
            _gameOverScreen.SetActive(false);
        }

        private void Update()
        {
            if (EndGameConditions()) GameOver();
        }

        #endregion MonoBehaviour

        #region Private Methods

        private bool EndGameConditions()
        {
            return _void.GetMaskScale().x < _safeZone.transform.localScale.x &&
                   _void.GetMaskScale().y < _safeZone.transform.localScale.y;
        }
        
        #endregion Private Methods

        #region Public Methods

        public void GameOver()
        {
            _gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

        #endregion Public Methods
    }
}
