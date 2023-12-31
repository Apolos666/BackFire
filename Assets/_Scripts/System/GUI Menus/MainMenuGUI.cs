using System;
using UnityEngine;

public class MainMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        MainMenuState.OnEnterEvent += MainMenuStateOnEnterEvent; 
        MainMenuState.OnExitEvent += MainMenuStateOnExitEvent;
    }
    
    private void OnDestroy()
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
        LoadingScreenGUI.Instance.UnLoadScene(Helper.GetSelectedMap(MapSelectionManager.IndexOfCurrentMap));
        
        gameObject.SetActive(true);
    }
}
