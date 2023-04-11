using Signals.Buttons;
using UnityEngine;
using Zenject;

public class SignalsInstaller : Installer<SignalsInstaller>
{
    public override void InstallBindings()
    {
        BindButtonsSignals();
    }

    private void BindButtonsSignals()
    {
        Container.DeclareSignal<StartGameSignal>();
    }
}