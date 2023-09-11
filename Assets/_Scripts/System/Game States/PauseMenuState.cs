using System;
using UnityEngine;

public class PauseMenuState : IState
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

        Time.timeScale = 0;
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
        
        Time.timeScale = 1;
    }
}
