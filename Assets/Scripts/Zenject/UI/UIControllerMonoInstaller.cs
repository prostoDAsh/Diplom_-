using UI;
using Zenject;

public class UIControllerMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindingPanels();
        Container.Bind<UIController>().FromInstance(GetComponent<UIController>()).AsSingle();
    }

    private void BindingPanels()
    {
        Container.Bind<StopPanel>().FromInstance(GetComponentInChildren<StopPanel>(true)).AsSingle();
        Container.Bind<MenuPanel>().FromInstance(GetComponentInChildren<MenuPanel>(true)).AsSingle().NonLazy();
        Container.Bind<GamePanel>().FromInstance(GetComponentInChildren<GamePanel>(true)).AsSingle();
        Container.Bind<WinPanel>().FromInstance(GetComponentInChildren<WinPanel>(true)).AsSingle();
        Container.Bind<FailPanel>().FromInstance(GetComponentInChildren<FailPanel>(true)).AsSingle();
    }
}