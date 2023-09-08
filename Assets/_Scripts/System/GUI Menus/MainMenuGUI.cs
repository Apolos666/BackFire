using System;
using UnityEngine;

public class MainMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        MainMenuState.OnEnterEvent += MainMenuStateOnEnterEvent; 
        MainMenuState.OnExitEvent += MainMenuStateOnExitEvent;
    }
    
    private void OnDisable()
    {
        MainMenuState.OnEnterEvent -= MainMenuStateOnEnterEvent; 
        MainMenuState.OnExitEvent -= MainMenuStateOnExitEvent;
    }

    private void MainMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void MainMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
}
