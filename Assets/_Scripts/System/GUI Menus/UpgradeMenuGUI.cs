using System;
using UnityEngine;

public class UpgradeMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        UpgradeMenuState.OnEnterEvent += UpgradeMenuStateOnEnterEvent;
        UpgradeMenuState.OnExitEvent += UpgradeMenuStateOnExitEvent;
    }
    
    private void OnDisable()
    {
        UpgradeMenuState.OnEnterEvent -= UpgradeMenuStateOnEnterEvent;
        UpgradeMenuState.OnExitEvent -= UpgradeMenuStateOnExitEvent;
    }

    private void UpgradeMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void UpgradeMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }

    
}
