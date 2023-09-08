using System;
using UnityEngine;

public class SelectionMenuState : IState
{
    public static event Action OnEnterEvent;
    public static event Action OnExitEvent;
    
    public void Tick()
    {
        Debug.Log($"State: {this.GetType()}");
    }

    public void OnEnter()
    {
        OnEnterEvent?.Invoke();
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
    }
}
