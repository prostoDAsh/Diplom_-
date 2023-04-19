using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container); // "подключение" SignalBus
        ProjectInstaller.Install(Container);
    }
}