using System;
using UnityEngine;

public class UnlockMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        UnlockMenuState.OnEnterEvent += UnlockMenuStateOnEnterEvent;
        UnlockMenuState.OnExitEvent += UnlockMenuStateOnExitEvent;
    }

    private void OnDisable()
    {
        UnlockMenuState.OnEnterEvent -= UnlockMenuStateOnEnterEvent;
        UnlockMenuState.OnExitEvent -= UnlockMenuStateOnExitEvent;
    }

    private void UnlockMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void UnlockMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
}
