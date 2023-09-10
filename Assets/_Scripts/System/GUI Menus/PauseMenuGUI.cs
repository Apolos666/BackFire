using System;
using UnityEngine;

public class PauseMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        gameObject.SetActive(false);
        PauseMenuState.OnEnterEvent += PauseMenuStateOnEnterEvent;
        PauseMenuState.OnExitEvent += PauseMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        PauseMenuState.OnEnterEvent -= PauseMenuStateOnEnterEvent;
        PauseMenuState.OnExitEvent -= PauseMenuStateOnExitEvent;
    }

    private void PauseMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void PauseMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
    
    
}
