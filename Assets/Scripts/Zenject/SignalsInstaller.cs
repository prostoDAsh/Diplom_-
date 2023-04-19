using Signals.Buttons;
using Signals.Keys;
using Zenject;

public class SignalsInstaller : Installer<SignalsInstaller>
{
    public override void InstallBindings()
    {
        BindingButtonsSignals();
        BindingKeysSignals();
    }

    private void BindingKeysSignals()
    {
        Container.DeclareSignal<StopGameSignal>();
    }

    private void BindingButtonsSignals()
    {
        Container.DeclareSignal<StartNewGameSignal>();
        Container.DeclareSignal<StartGameSignal>();
        Container.DeclareSignal<ContinueGameSignal>();
        Container.DeclareSignal<StartNewGameSignal>();
        Container.DeclareSignal<RestartGameSignal>();
        Container.DeclareSignal<ReturnMenuSignal>();
    }
}