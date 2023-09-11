using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenGUI : MonoBehaviour, IInitializable
{
    private static LoadingScreenGUI _instance;
    public static LoadingScreenGUI Instance => _instance;
    
    [SerializeField] private TextMeshProUGUI _progressPercentText;
    [SerializeField] private Image _progressBar;

    private Coroutine _currentCoroutine;

    [SerializeField] private GUIEventChannelSO _mainMenuEvent;

    public void Initial()
    {
        gameObject.SetActive(false);
        
        if (_instance != null)
            Destroy(this);
        else
        {
            _instance = this;
        }
    }

    public void StartLoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        
        _currentCoroutine = StartCoroutine(StartLoadSceneCoroutine(sceneName));
    }

    private IEnumerator StartLoadSceneCoroutine(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            _progressBar.fillAmount = Mathf.Lerp(0, 1, asyncOperation.progress);
            _progressPercentText.text = (asyncOperation.progress * 100).ToString();
            
            if (asyncOperation.progress >= 0.9f)
                asyncOperation.allowSceneActivation = true;
            
            yield return null;
        }

        Scene currentScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(currentScene);

        gameObject.SetActive(false);
    }

    public void UnLoadScene(string sceneName)
    {
        bool hasGameplayScene = SceneManager.GetActiveScene().name == sceneName;

        if (hasGameplayScene)
            SceneManager.UnloadSceneAsync(sceneName);
        else
            Debug.Log("Currently there is no such scene active");
    }
}
