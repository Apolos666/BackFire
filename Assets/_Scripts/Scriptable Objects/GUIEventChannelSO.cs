using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Event Channels/GUI Event")]
public class GUIEventChannelSO : ScriptableObject
{
    public Action<bool> OnGUIChangedRequest;

    public void RaiseEvent(bool changedRequest)
    {
        OnGUIChangedRequest?.Invoke(changedRequest);
    }
}
