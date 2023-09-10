using System;
using UnityEngine;

public class DeathMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        gameObject.SetActive(false);
        DeathMenuState.OnEnterEvent += DeathMenuStateOnEnterEvent;
        DeathMenuState.OnExitEvent += DeathMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        DeathMenuState.OnEnterEvent += DeathMenuStateOnEnterEvent;
        DeathMenuState.OnExitEvent += DeathMenuStateOnExitEvent;
    }

    private void DeathMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void DeathMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
}
