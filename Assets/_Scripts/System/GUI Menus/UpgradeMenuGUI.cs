using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuGUI : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _preparationGUI;
    [SerializeField] private Button _upgradeMenuButton;
    
    public void Initial()
    {
        _preparationGUI.SetActive(false);
        UpgradeMenuState.OnEnterEvent += UpgradeMenuStateOnEnterEvent;
        UpgradeMenuState.OnExitEvent += UpgradeMenuStateOnExitEvent;
    }
    
    private void OnDestroy()
    {
        UpgradeMenuState.OnEnterEvent -= UpgradeMenuStateOnEnterEvent;
        UpgradeMenuState.OnExitEvent -= UpgradeMenuStateOnExitEvent;
    }

    private void UpgradeMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
        _preparationGUI.SetActive(false);
        _upgradeMenuButton.interactable = true;
    }

    private void UpgradeMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
        _preparationGUI.SetActive(true);
        _upgradeMenuButton.interactable = false;
    }

    
}
