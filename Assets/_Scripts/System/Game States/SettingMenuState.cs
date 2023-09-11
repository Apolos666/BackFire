using System;
using UnityEngine;

public class SettingMenuState : IState
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

        Time.timeScale = 0f;
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
        
        Time.timeScale = 1f;
    }
}
