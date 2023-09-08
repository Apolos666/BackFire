using System;
using UnityEngine;

public class MapSelectionMenuGUI : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _preparationGUI;
    
    public void Initial()
    {
        gameObject.SetActive(false);
        MapSelectionState.OnEnterEvent += MapSelectionStateOnEnterEvent;
        MapSelectionState.OnExitEvent += MapSelectionStateOnExitEvent;
    }

    private void OnDestroy()
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
       _preparationGUI.SetActive(false);
    }
}
