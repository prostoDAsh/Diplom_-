using System;
using UnityEngine;
using Zenject;

public class ProjectInstaller : IInitializable, IDisposable
{
    public void Initialize()
    {
        Debug.Log("ProjectInstaller Init");
    }

    public void Dispose()
    {
        Debug.Log("ProjectInstaller Dis");
    }
}