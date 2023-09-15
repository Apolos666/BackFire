using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectionItems : MonoBehaviour
{
    [Header("Control Buttons")] 
    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Image _currentItemImage;
    
    private static int _indexOfCurrentGun = 0;
    public static int IndexOfCurrentGun => _indexOfCurrentGun;
    
    
    // làm tiếp từ đây, lấy dữ liệu từ cái indexofCurrentGun rồi truyền nó cho cái game play scene

    private void Start()
    {
        print(Inventory.InventoryItems.First());
        _currentItemImage.sprite = Inventory.InventoryItems.First().Sprite;
        _prevButton.interactable = false;
        if (_indexOfCurrentGun == Inventory.InventoryItems.Count - 1)
            _nextButton.interactable = false;
        Inventory.OnChangedInventory += RenderSelection;
    }

    private void RenderSelection()
    {
        if (_indexOfCurrentGun == Inventory.InventoryItems.Count - 1)
            _nextButton.interactable = false;
        else
            _nextButton.interactable = true;
        
        if (_indexOfCurrentGun == 0)
            _prevButton.interactable = false;
        else
            _prevButton.interactable = true;
        
    }


    public void OnNextGun_ButtonClick()
    {
        _indexOfCurrentGun++;
        ShowGun();

        if (_indexOfCurrentGun == Inventory.InventoryItems.Count - 1)
            _nextButton.interactable = false;

        if (_prevButton.interactable) return;
        _prevButton.interactable = true;
    }

    public void OnPrevGun_ButtonClick()
    {
        _indexOfCurrentGun--;
        ShowGun();

        if (_indexOfCurrentGun == 0)
            _prevButton.interactable = false;

        if (_nextButton.interactable) return;
        _nextButton.interactable = true;
    }

    private void ShowGun()
    {
        _currentItemImage.sprite = Inventory.InventoryItems[_indexOfCurrentGun].Sprite;
    }
}
