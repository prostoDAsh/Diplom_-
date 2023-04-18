using UnityEngine;
using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container); // "подключение" SignalBus

        Container.BindInterfacesTo<ProjectInstaller>().AsSingle();
    }
}