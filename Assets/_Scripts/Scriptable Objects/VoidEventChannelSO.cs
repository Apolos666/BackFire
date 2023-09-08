using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Channels/Void Event")]
public class VoidEventChannelSO : ScriptableObject
{
    public Action OnChangedRequest;

    public void RaiseEvent()
    {
        OnChangedRequest?.Invoke();
    }
}
