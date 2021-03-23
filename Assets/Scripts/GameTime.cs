using UnityEngine;
using System;

public class GameTime : MonoBehaviour
{
    public static Action<int> OnTick;

    private int _currentTime = 0;

    private void Start() 
    {
        InvokeRepeating(nameof(Tick), 1f, 1f);
    }

    private void Tick()
    {
        _currentTime++;
        OnTick?.Invoke(_currentTime);
    }
}
