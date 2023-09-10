using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObstacle : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _OnPlayerDeath;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            _OnPlayerDeath.RaiseEvent();
        }
    }
}
