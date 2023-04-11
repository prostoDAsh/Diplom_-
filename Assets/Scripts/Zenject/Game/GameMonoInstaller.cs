using UnityEngine;
using Zenject;

public class GameMonoInstaller : MonoInstaller
{
    public override void InstallBindings() // сюда складываем Монобехи 
    {
        GameInstaller.Install(Container); // Установка GameInstaller"а 
        SignalsInstaller.Install(Container);
    }
}