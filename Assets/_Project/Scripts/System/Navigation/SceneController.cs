using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference _startingScene;
    [SerializeField] private GameObjectReference _runtimeReference;

    private void Awake()
    {
        _runtimeReference.SetValue(gameObject);
    }

    private IEnumerator Start()
    {
        yield return LoadSceneAndSetActive(_startingScene.SceneName);
    }

    public void LoadScene(string sceneName, bool unloadPrevious)
    {
        StartCoroutine(unloadPrevious ? SwitchScenes(sceneName) : LoadAdditiveScene(sceneName));
    }

    private IEnumerator SwitchScenes(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
    }
		
    private IEnumerator LoadAdditiveScene(string sceneName)
    {
        var originalScene = SceneManager.GetActiveScene();
        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
        originalScene.GetRootGameObjects()[0].SetActive(false);
    }
    
    private static IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        var targetScene = SceneManager.GetSceneByName(sceneName);
        if (targetScene.isLoaded)
        {
            SceneManager.SetActiveScene(targetScene);
            targetScene.GetRootGameObjects()[0].SetActive(true);
        }
        else
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            targetScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(targetScene);
        }
    }

    public void ReloadCurrentScene()
    {
        StartCoroutine(UnloadAndReloadScene());
    }

    private IEnumerator UnloadAndReloadScene()
    {
        string sceneToReload = SceneManager.GetActiveScene().name;
        yield return SceneManager.UnloadSceneAsync(sceneToReload);
        yield return StartCoroutine(LoadSceneAndSetActive(sceneToReload));
    }
}
