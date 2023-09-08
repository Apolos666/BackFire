using System;
using UnityEngine;

public class SettingMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        gameObject.SetActive(false);
        SettingMenuState.OnEnterEvent += SettingMenuStateOnEnterEvent;
        SettingMenuState.OnExitEvent += SettingMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        SettingMenuState.OnEnterEvent -= SettingMenuStateOnEnterEvent;
        SettingMenuState.OnExitEvent -= SettingMenuStateOnExitEvent;
    }

    private void SettingMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void SettingMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
}
