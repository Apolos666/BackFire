using UnityEngine;
using UnityEngine.UI;

public class SelectionMenuGUI : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject _preparationGUI;
    [SerializeField] private Button _selectionMenuButton;
    
    public void Initial()
    {
        _preparationGUI.SetActive(false);
        SelectionMenuState.OnEnterEvent += SelectionMenuStateOnEnterEvent;
        SelectionMenuState.OnExitEvent += SelectionMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        SelectionMenuState.OnEnterEvent -= SelectionMenuStateOnEnterEvent;
        SelectionMenuState.OnExitEvent -= SelectionMenuStateOnExitEvent;
    }

    private void SelectionMenuStateOnExitEvent()
    {
        gameObject.SetActive(false);
        _preparationGUI.SetActive(false);
        _selectionMenuButton.interactable = true;
    }

    private void SelectionMenuStateOnEnterEvent()
    {
        LoadingScreenGUI.Instance.UnLoadScene(Helper.GetSelectedMap(MapSelectionManager.IndexOfCurrentMap));
        
        gameObject.SetActive(true);
        _preparationGUI.SetActive(true);
        _selectionMenuButton.interactable = false;
    }
}
