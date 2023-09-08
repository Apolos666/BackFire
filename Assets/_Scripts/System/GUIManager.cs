using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _GUIGameObjectLists = new List<GameObject>();
    private List<IInitializable> _GUILists = new List<IInitializable>(); 

    private void Awake()
    {
        #region Add GUI objects and call initial function in each one

        _GUIGameObjectLists.ForEach(guiGameObject => 
            _GUILists.Add(guiGameObject.GetComponent<IInitializable>())
        );
        
        _GUILists.ForEach(gui => gui.Initial());

        #endregion
        
    }
}
