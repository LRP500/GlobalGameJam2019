using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class SceneNavigation : MonoBehaviour
{
    [SerializeField] private GameObjectReference _navigationController;
    [SerializeField] private SceneReference _next;
    [SerializeField] private bool _unloadPrevious;

    public UnityEvent BeforeSceneUnload;
    public UnityEvent AfterSceneLoad;

    private bool _isLoading;
    
    public void Navigate()
    {
        if (_isLoading) return;
        if (_navigationController.Value == null) return;
        var controller = _navigationController.Value.GetComponent<SceneController>();
        if (controller == null) return;

        BeforeSceneUnload?.Invoke();
        _isLoading = true;
        controller.LoadScene(_next.SceneName, _unloadPrevious);
        AfterSceneLoad?.Invoke();
    }
}
