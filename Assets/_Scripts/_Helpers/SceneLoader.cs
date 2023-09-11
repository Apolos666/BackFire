using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool IsLoaded = false;

    public static TaskCompletionSource<bool> _sceneLoadedTask = new TaskCompletionSource<bool>();

    private void Start()
    {
        var thisScene = SceneManager.GetActiveScene();

        // load all scenes
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // skip if is current scene since we don't want it twice
            if(thisScene.buildIndex == i) continue;

            // Skip if scene is already loaded
            if (!SceneManager.GetSceneByName("GUI Scene").IsValid())
            {
                StartCoroutine(UrgentTest());
                break;
            }
        }
    }

    private IEnumerator UrgentTest()
    {
        var asyncOperation = SceneManager.LoadSceneAsync("GUI Scene", LoadSceneMode.Additive);
        
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
                asyncOperation.allowSceneActivation = true;
            
            yield return null;
        }

        IsLoaded = true;
        _sceneLoadedTask.SetResult(true);
    }
}
