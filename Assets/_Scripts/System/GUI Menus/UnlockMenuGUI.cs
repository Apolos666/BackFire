using System;
using UnityEngine;
using UnityEngine.UI;

public class UnlockMenuGUI : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _preparationGUI;
    [SerializeField] private Button _unlockMenuButton;
    
    public void Initial()
    {
        _preparationGUI.SetActive(false);
        UnlockMenuState.OnEnterEvent += UnlockMenuStateOnEnterEvent;
        UnlockMenuState.OnExitEvent += UnlockMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        UnlockMenuState.OnEnterEvent -= UnlockMenuStateOnEnterEvent;
        UnlockMenuState.OnExitEvent -= UnlockMenuStateOnExitEvent;
    }

    private void UnlockMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
        _preparationGUI.SetActive(false);
        _unlockMenuButton.interactable = true;
    }

    private void UnlockMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
        _preparationGUI.SetActive(true);
        _unlockMenuButton.interactable = false;
    }
}
