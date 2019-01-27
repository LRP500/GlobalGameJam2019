using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Variables;

namespace GlobalGameJam2019
{
    public class GameManager : MonoBehaviour
    {
        private const string _saveFileName = "HighScore.secure";

        #region Private Variables

        [SerializeField] private Void _void;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private IntVariable _playerScore;
        
        private string _saveDataPath;
        private SaveData _save;
        
        #endregion Private Variables

        #region MonoBehaviour

        private void Awake()
        {
            LoadHighScore();
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (EndGameConditions()) GameOver();
        }

        #endregion MonoBehaviour

        #region Private Methods

        private bool EndGameConditions()
        {
            return _void.GetMaskScale().x < _playerTransform.localScale.x &&
                   _void.GetMaskScale().y < _playerTransform.localScale.y;
        }
        
        #endregion Private Methods

        #region Public Methods

        public void GameOver()
        {
            if (_playerScore.Value > _save.HighScore)
            {
                _save.HighScore = _playerScore.Value;
                RecordHighScore();
            }

            _gameOverScreen.Display(_save.HighScore);
            Time.timeScale = 0;
        }

        public void RecordHighScore()
        {
            if (Directory.Exists(_saveDataPath) == false)
                Directory.CreateDirectory(_saveDataPath);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(_saveDataPath + _saveFileName);
            bf.Serialize(file, _save);
            file.Close();
        }

        public void LoadHighScore()
        {
            _saveDataPath = Application.dataPath + "/Save/";
            if (File.Exists(_saveDataPath + _saveFileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(_saveDataPath + _saveFileName, FileMode.Open);
                _save = (SaveData)bf.Deserialize(file);
                file.Close();
                
                Debug.Log("Highscore saved");
            }
            else
            {
                Debug.LogWarning("No existing save data found. Creating save data...");
                _save = new SaveData();
            }
        }
        
        #endregion Public Methods
    }

    [Serializable]
    public class SaveData
    {
        public int HighScore;

        public SaveData() { HighScore = 0; }
    }
}
