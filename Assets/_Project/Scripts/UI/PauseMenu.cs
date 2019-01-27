using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObjectReference _sceneController;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;

    public bool LockCursor;

    private bool _isPaused;

    private void Awake()
    {
        _canvas.enabled = false;
        if (LockCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        NavigateToMain();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                if (_settingsMenu.activeInHierarchy)
                {
                    NavigateToMain();
                }
                else ResumeGame();
            }
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _canvas.enabled = _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _canvas.enabled = _isPaused = false;
    }

    public void Restart()
    {
        _sceneController.Value.GetComponent<SceneController>().ReloadCurrentScene();
        Time.timeScale = 1;
    }
    
    public void NavigateToSettings()
    {
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    
    public void NavigateToMain()
    {
        _settingsMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }
}
