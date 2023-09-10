using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenuGUI : MonoBehaviour, IInitializable
{
    [SerializeField] private Button _pauseButton;
    
    public void Initial()
    {
        gameObject.SetActive(false);
        GamePlayState.OnEnterEvent += GamePlayStateOnEnterEvent;
        GamePlayState.OnExitEvent += GamePlayStateOnExitEvent;
    }

    private void OnDestroy()
    {
        GamePlayState.OnEnterEvent -= GamePlayStateOnEnterEvent;
        GamePlayState.OnExitEvent -= GamePlayStateOnExitEvent;
    }

    private void GamePlayStateOnExitEvent()
    {
        gameObject.SetActive(false);
        _pauseButton.interactable = false;
    }

    private void GamePlayStateOnEnterEvent()
    {
        gameObject.SetActive(true);
        _pauseButton.interactable = true;
    }
}
