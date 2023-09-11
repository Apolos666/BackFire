using System;
using UnityEngine;

public class MainMenuState : IState
{
    public static event Action OnEnterEvent;
    public static event Action OnExitEvent;

    private GameManager _gameManager;
    private GameObject _mainCamera;

    public MainMenuState(GameManager gameManager, GameObject mainCamera)
    {
        _gameManager = gameManager;
        _mainCamera = mainCamera;
    }
    
    public void Tick()
    {
        Debug.Log($"State: {this.GetType()}");
    }

    public async void OnEnter()
    {
        await SceneLoader._sceneLoadedTask.Task;
        
        OnEnterEvent?.Invoke();
        
        _mainCamera.SetActive(true);
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
    }
}
