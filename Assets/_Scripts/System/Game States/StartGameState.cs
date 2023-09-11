using System;
using UnityEngine;

public class StartGameState : IState
{
    public static event Action OnEnterEvent;
    public static event Action OnExitEvent;

    private string _sceneName;

    private GameManager _gameManager;
    private GameObject _mainCamera;

    public StartGameState(GameManager gameManager, GameObject mainCamera)
    {
        _gameManager = gameManager;
        _mainCamera = mainCamera;
    }

    public void Tick()
    {
        Debug.Log($"State: {this.GetType()}");
    }

    public void OnEnter()
    {
        OnEnterEvent?.Invoke();

        _sceneName = Helper.GetSelectedMap(MapSelectionManager.IndexOfCurrentMap);
        
        LoadingScreenGUI.Instance.UnLoadScene(_sceneName);
        
        LoadingScreenGUI.Instance.StartLoadScene(_sceneName);

        _mainCamera.SetActive(false);
        
        _gameManager.SetGamePlayState();
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
    }
}
