using Zenject;

public class ProjectInstaller : Installer<ProjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
    }
}