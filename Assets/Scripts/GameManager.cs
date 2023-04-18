using System;
using UnityEngine;
using Zenject;

public class GameManager : IInitializable, IDisposable
{
    public void Initialize()
    {
        Debug.Log("Initialize");
    }
    
    public void Dispose()
    {
        Debug.Log("Dispose");
    }
    
}
