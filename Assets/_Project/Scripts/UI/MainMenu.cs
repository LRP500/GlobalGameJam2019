using UnityEngine;

namespace GlobalGameJam2019
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _titleMenu;
        [SerializeField] private GameObject _settingsMenu;

        public bool LockCursor;
        
        private void Awake()
        {
            NavigateToTitle();

            if (LockCursor)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void NavigateToSettings()
        {
            _titleMenu.SetActive(false);
            _settingsMenu.SetActive(true);
        }
    
        public void NavigateToTitle()
        {
            _settingsMenu.SetActive(false);
            _titleMenu.SetActive(true);
        }
    }    
}
