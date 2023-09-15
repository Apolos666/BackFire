using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectionManager : MonoBehaviour
{
    [Header("Lists of map player can play")]
    [SerializeField] private List<GameObject> _mapLists = new List<GameObject>();

    [Header("Listening on void channels")] 
    [SerializeField] private VoidEventChannelSO _prevMap;
    [SerializeField] private VoidEventChannelSO _nextMap;

    [Header("Control Buttons")] 
    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;

    private static int _indexOfCurrentMap = 0;
    public static int IndexOfCurrentMap => _indexOfCurrentMap;
    private int _prevIndexOfCurrentMap = 0;

    private void Awake()
    {
        _mapLists.First().SetActive(true);
        _prevButton.interactable = false;
    }

    private void OnEnable()
    {
        _prevMap.OnChangedRequest += OnPrevMap_ButtonClick;
        _nextMap.OnChangedRequest += OnNextMap_ButtonClick;
    }

    private void OnDisable()
    {
        _prevMap.OnChangedRequest -= OnPrevMap_ButtonClick;
        _nextMap.OnChangedRequest -= OnNextMap_ButtonClick;
    }

    private void OnNextMap_ButtonClick()
    {
        _prevIndexOfCurrentMap = _indexOfCurrentMap;
        _indexOfCurrentMap++;
        ShowMap();

        if (_indexOfCurrentMap == _mapLists.Count - 1)
            _nextButton.interactable = false;

        if (_prevButton.interactable) return;
            _prevButton.interactable = true;
    }

    private void OnPrevMap_ButtonClick()
    {
        _prevIndexOfCurrentMap = _indexOfCurrentMap;
        _indexOfCurrentMap--;
        ShowMap();

        if (_indexOfCurrentMap == 0)
            _prevButton.interactable = false;

        if (_nextButton.interactable) return;
        _nextButton.interactable = true;
    }

    private void ShowMap()
    {
        _mapLists[_prevIndexOfCurrentMap].SetActive(false);
        _mapLists[_indexOfCurrentMap].SetActive(true);
    }
}
