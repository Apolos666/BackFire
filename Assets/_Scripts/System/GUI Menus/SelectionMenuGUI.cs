using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        SelectionMenuState.OnEnterEvent += SelectionMenuStateOnEnterEvent;
        SelectionMenuState.OnExitEvent += SelectionMenuStateOnExitEvent;
    }

    private void OnDisable()
    {
        SelectionMenuState.OnEnterEvent -= SelectionMenuStateOnEnterEvent;
        SelectionMenuState.OnExitEvent -= SelectionMenuStateOnExitEvent;
    }

    private void SelectionMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void SelectionMenuStateOnEnterEvent()
    {
        gameObject.SetActive(true);
    }
}
