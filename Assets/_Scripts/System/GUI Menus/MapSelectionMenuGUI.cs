using System;
using UnityEngine;

public class MapSelectionMenuGUI : MonoBehaviour, IInitializable
{
    public void Initial()
    {
        MapSelectionState.OnEnterEvent += MapSelectionStateOnEnterEvent;
        MapSelectionState.OnExitEvent += MapSelectionStateOnExitEvent;
    }

    private void OnDisable()
    {
        MapSelectionState.OnEnterEvent -= MapSelectionStateOnEnterEvent;
        MapSelectionState.OnExitEvent -= MapSelectionStateOnExitEvent;
    }

    private void MapSelectionStateOnExitEvent()
    {
        gameObject.SetActive(false);
    }

    private void MapSelectionStateOnEnterEvent()
    {
       gameObject.SetActive(true);
    }
}
