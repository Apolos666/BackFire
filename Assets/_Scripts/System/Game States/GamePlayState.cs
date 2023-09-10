using System;
using UnityEngine;

public class GamePlayState : IState
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
        // Bắn event có truyền đối số nếu mình đã xem quảng cáo, đại loại thế
        // Bên Game scene thì mình sẽ reset lại vị trí cho người chơi
    }

    public void OnExit()
    {
        OnExitEvent?.Invoke();
    }
}
