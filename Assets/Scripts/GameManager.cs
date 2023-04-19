using System;
using Signals.Keys;
using UnityEngine;
using Zenject;

public class GameManager : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;

    public GameManager(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Initialize()
    {
       Debug.Log("Initialize GameManager");
    }

    public void Dispose()
    {
        Debug.Log("Dispose GameManager");
    }
}
